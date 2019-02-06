#include "stdafx.h"
#include "monsterloop.h"

using namespace std;

// A gift from C# we get from calling TransferData()
MonsterloopData mData;
UINT8* results;

// A constructor for Piece that converts a BasicPiece into a Piece
// Skill id is replaced with its array index in reqs
Piece::Piece(const BasicPiece& p, const Req* reqs, const int rsize)
{
	s1 = arrayContainsId(reqs, rsize, p.s1);
	s2 = arrayContainsId(reqs, rsize, p.s2);
	r1 = (s1 == -1) ? 0 : p.r1;
	r2 = (s2 == -1) ? 0 : p.r2;
	gem.g = p.gem;

	// Swap to ensure s1 null ==> s2 null
	if (s1 == -1 && s2 != -1)
	{
		s1 = s2;
		r1 = r2;
		s2 = -1;
		r2 = 0;
	}

	score = r1 + r2 + gem.level.g1 + gem.level.g2 + gem.level.g3;
}

// Poor linear search, but should be ok since Reqs' size is always small
// Sorting reqs will enable dichotomic search but I'm not sure if we gain much from this. Worth a try tho.
int arrayContainsId(const Req* reqs, const int rsize, const int id)
{
	for (int i = 0; i < rsize; ++i)
	{
		if (reqs[i].split.id == id) return i;
	}
	return -1;
}

// BasicPieces are concatenated in mData.pieces. This function extracts a range (helms, chests, etc.) and converts them to Piece
void _preparePieces(const Req* reqs, const int rsize, Piece*& newArray, const int start, const int end)
{
	int c = 0;
	for (int i = start; i < end; ++i)
	{
		newArray[c++] = Piece(mData.pieces[i], reqs, rsize);
	}
}

void _prepareCharms(const Req* reqs, const int rsize, map<int, BasicCharm> &v)
{
	int n = mData.nCharms;
	while (n --> 0)
	{
		BasicCharm c = mData.charms[n];
		int index1 = arrayContainsId(reqs, rsize, c.s1);
		int index2 = c.s2 == 0 ? -1 : arrayContainsId(reqs, rsize, c.s2);
		if (index1 != -1 || index2 != -1)
		{
			c.s1 = index1;
			c.s2 = index2;
			v[n] = c;
		}
	}
}

// See _changePiece as it's the same thing
void _changeCharm(const BasicCharm& charm, int& score, int* const ranks, const int rsize, bool add)
{
	if (add)
	{
		if (charm.s1 != -1)
		{
			ranks[charm.s1] -= charm.r1;
			score += charm.r1;
		}
		if (charm.s2 != -1)
		{
			ranks[charm.s2] -= charm.r2;
			score += charm.r2;
		}
	}
	else
	{
		if (charm.s1 != -1)
		{
			ranks[charm.s1] += charm.r1;
			score -= charm.r1;
		}
		if (charm.s2 != -1)
		{
			ranks[charm.s2] += charm.r2;
			score -= charm.r2;
		}
	}
}

// Operations to be done before and after each loop. Every time we change a piece of gear (when entering a loop)
// we update the global score, slots, and filled ranks. Before exiting the loop and using another piece, we need
// to restore the values to their previous state. From testing, it seems faster to recompute them rather than
// storing a backup of these values.
void _changePiece(const Piece& piece, int& score, Gem& slots, int* const ranks, const int rsize, bool add)
{
	if (add)
	{
		score += piece.score;
		slots.g += piece.gem.g;
		if (piece.s1 != -1)
		{
			ranks[piece.s1] -= piece.r1;
			if (piece.s2 != -1)
			{
				ranks[piece.s2] -= piece.r2;
			}
		}
	}
	else
	{
		score -= piece.score;
		slots.g -= piece.gem.g;
		if (piece.s1 != -1)
		{
			ranks[piece.s1] += piece.r1;
			if (piece.s2 != -1)
			{
				ranks[piece.s2] += piece.r2;
			}
		}
	}
}

// Loops on data to find armors that fulfill the request
int doFind(const Req* reqs, const int rsize, const int weaponSlots)
{
	// Compute the target score
	Gem gemSlots(weaponSlots);
	int targetScore = -gemSlots.score();
	for (int i = 0; i < rsize; ++i)
	{
		targetScore += reqs[i].split.rank;
	}
	// Very fast check that too many skill ranks have been requested
	if (targetScore > maxScore[0])
	{
		return 0;
	}

	// Initialize ranks to the required ranks
	int * const ranks = new int[rsize];
	for (int i = 0; i < rsize; ++i)
	{
		ranks[i] = reqs[i].split.rank;
	}
	
	// Should make things faster. Every useless skills on any piece of armor is replaced with 0
	// Any charms that does not contain a useful skill is removed
	int hl = mData.nHelms;
	int cl = mData.nChests;
	int gl = mData.nGloves;
	int wl = mData.nWaists;
	int ll = mData.nLegs;

	map<int, BasicCharm> charms;
	Piece* ha = new Piece[hl];
	Piece* ca = new Piece[cl];
	Piece* ga = new Piece[gl];
	Piece* wa = new Piece[wl];
	Piece* la = new Piece[ll];

	_prepareCharms(reqs, rsize, charms);
	int startIndex = 0;
	_preparePieces(reqs, rsize, ha, startIndex, startIndex + hl);
	startIndex += hl;
	_preparePieces(reqs, rsize, ca, startIndex, startIndex + cl);
	startIndex += cl;
	_preparePieces(reqs, rsize, ga, startIndex, startIndex + gl);
	startIndex += gl;
	_preparePieces(reqs, rsize, wa, startIndex, startIndex + wl);
	startIndex += wl;
	_preparePieces(reqs, rsize, la, startIndex, startIndex + ll);

	int score = 0;
	int found = 0;
	int rg1, rg2, rg3;
	int resultIndex = 0;

	// loop on charms
	for (const auto &pair : charms)
	{
		if (pair.second.score() + maxScore[1] < targetScore) continue;
		_changeCharm(pair.second, score, ranks, rsize, true);

		// loop on helms
		for (int i = 0; i < hl; ++i)
		{
			if (score + ha[i].score + maxScore[2] < targetScore) continue;
			_changePiece(ha[i], score, gemSlots, ranks, rsize, true);

			// loop on chests
			for (int j = 0; j < cl; ++j)
			{
				if (score + ca[j].score + maxScore[3] < targetScore) continue;
				_changePiece(ca[j], score, gemSlots, ranks, rsize, true);

				// loop on gloves
				for (int k = 0; k < gl; ++k)
				{
					if (score + ga[k].score + maxScore[4] < targetScore) continue;
					_changePiece(ga[k], score, gemSlots, ranks, rsize, true);

					// loop on waists
					for (int l = 0; l < wl; ++l)
					{
						if (score + wa[l].score + maxScore[5] < targetScore) continue;
						_changePiece(wa[l], score, gemSlots, ranks, rsize, true);

						// loop on legs
						for (int m = 0; m < ll; ++m)
						{
							if (score + la[m].score < targetScore) continue;
							_changePiece(la[m], score, gemSlots, ranks, rsize, true);

							//// Heart of loop

							// We've removed requested ranks thanks to what the gear provides
							// The remaining ranks will be use gems
							rg1 = gemSlots.level.g1;
							rg2 = gemSlots.level.g2;
							rg3 = gemSlots.level.g3;

							for (int n = 0; n < rsize; ++n)
							{
								if (ranks[n] > 0)
								{
									switch (reqs[n].split.gemLevel)
									{
									case 0:
										// we're missing a skill but no gem exists, it's a fail
										goto missingGem;
									case 1:
										rg1 -= ranks[n];
										break;

									case 2:
										rg2 -= ranks[n];
										break;

									case 3:
										rg3 -= ranks[n];
										break;
									}
								}
							}
							// Do we have enough gem slots for those remaining ranks?
							if (rg3 >= 0)
							{
								rg2 += rg3;
								if (rg2 >= 0)
								{
									rg1 += rg2;
									if (rg1 >= 0)
									{
										if (++found > mData.maxResults)
										{
											found = -1;
											goto outloop;
										}
										results[resultIndex++] = (UINT8)pair.first;
										results[resultIndex++] = (UINT8)i;
										results[resultIndex++] = (UINT8)j;
										results[resultIndex++] = (UINT8)k;
										results[resultIndex++] = (UINT8)l;
										results[resultIndex++] = (UINT8)m;
									}
								}
							}

							//// end Heart of loop
							missingGem:
							_changePiece(la[m], score, gemSlots, ranks, rsize, false);

						} // end loop legs
						_changePiece(wa[l], score, gemSlots, ranks, rsize, false);

					} // end loop waists
					_changePiece(ga[k], score, gemSlots, ranks, rsize, false);

				} // end loop gloves
				_changePiece(ca[j], score, gemSlots, ranks, rsize, false);

			} // end loop chests
			_changePiece(ha[i], score, gemSlots, ranks, rsize, false);

		} // end loop helms
		_changeCharm(pair.second, score, ranks, rsize, false);

	} // end loop charms
	
	outloop:

	delete[] ranks;
	delete[] ha;
	delete[] ca;
	delete[] ga;
	delete[] wa;
	delete[] la;

	return found;
}

int MONSTERLOOP_API __stdcall FindArmors(const int* r, const int rsize, const int weaponSlots)
{
	Req* reqs = new Req[rsize];
	for (int i = 0; i < rsize; ++i)
	{
		reqs[i] = Req(r[i]);
	}
	int res = doFind(reqs, rsize, weaponSlots);
	delete[] reqs;
	return res;
}

// Get the sizes for all armor types, and a pointer to the array of BasicPiece that we'll keep to process all requests
void MONSTERLOOP_API __stdcall TransferData(const MonsterloopData data, UINT8* theResults)
{
	mData = data;
	results = theResults;
}