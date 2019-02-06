#pragma once

/**
* Monsterloop
* As of writing, there are 5 gear category (helms, chests, etc.) and about 100 different pieces of gear per category,
* for a total combination of 100^5 (or 10^10 which is 10 billions).
* In addition, there are about 230 charms so the total combination goes banana and we are supposed to browse them all ...
*
* Monsterloop does a few tricks to dramatically reduce these combinations and find the best armor sets within a few seconds.
* 1. Remove all charms that do not contain any requested skill. There is no need to create an armor set with a charm that has
*    nothing to do with what the player requested.
* 2. Only consider the charms that have max rank. Why would we put a Earplug I charm when we can get a Earplug III instead?
* 3. Compute a targetScore for the request. This is just the sum of all ranks in the request. For example, if you request
*    Flinch Free II, Earplugs V, and Divine Blessing III, the targetScore will be 2 + 5 + 3 = 10.
* 4. Be aware of the maximum score we can get from each gear category. At the time of writing, we know that no helmet can provide
*    more than 5 skill ranks. A gear score is the sum of all its ranks AND its gem slots (as each slot provides a single rank through gems)
* 5. Now everytime we enter a loop and add a piece of gear, we can compute the current gear score and quickly check if it's possible
*    to fulfill the request considering what remains. For example, we have set a charm, a helm, and a chest; we add the score for those
*    3 pieces (let's say 8). We know the best gloves can give a maximum score of 4, waists give 4 at max, and legs may add up to 5 so
*    at this point, we know we can reach a maximum score of 8 + 4 + 4 + 5 = 21. If the targetScore (request) is bigger than that, we are
*    assured that no combination will ever fulfill it. We can skip browsing the remaining pieces of gear and proceed to the next chest.
*/

// Some constants that would need adjustment if the game introduces new gear
// (could be computed on the fly but well ...)
const int maxCharmScore  = 3;
const int maxHelmScore   = 5;
const int maxChestScore  = 5;
const int maxGlovesScore = 4;
const int maxWaistScore  = 4;
const int maxLegsScore   = 5;
const int maxScore[6] = {
	maxCharmScore + maxHelmScore + maxChestScore + maxGlovesScore + maxWaistScore + maxLegsScore,
	                maxHelmScore + maxChestScore + maxGlovesScore + maxWaistScore + maxLegsScore,
					               maxChestScore + maxGlovesScore + maxWaistScore + maxLegsScore,
								                   maxGlovesScore + maxWaistScore + maxLegsScore,
												                    maxWaistScore + maxLegsScore,
																	                maxLegsScore
};

// Counts the number of level-1 slots in g1, level-2 in g2, etc.
union Gem {
	INT32 g;
	struct {
		INT8 g1;
		INT8 g2;
		INT8 g3;
		INT8 nothing;
	} level;

	Gem() : g(0) {}
	Gem(int n) : g(n) {}
	int score() const { return level.g1 + level.g2 + level.g3; }
};

// a Req is a request, consisting of the skill id and its rank.
// Gemlevel is added for ease of computation (that's the level of the gem having that skill)
union Req
{
	INT32 i;
	struct {
		INT8 id;
		INT8 rank;
		INT8 gemLevel;
		INT8 notused;
	} split;

	Req() : i(0) {}
	Req(int n) : i(n) {}
};

// A struct for data incoming from C#
struct BasicPiece
{
	int s1;
	int s2;
	int r1;
	int r2;
	int gem;
};

struct BasicCharm
{
	INT8 s1;
	INT8 s2;
	INT8 r1;
	INT8 r2;

	int score() const { return (s1 != -1 ? r1 : 0) + (s2 != -1 ? r2 : 0); }
};

// Parameters pass to this dll
struct MonsterloopData
{
	INT32 maxResults;    // The maximum results we want; Maximum allocated size of results array
	INT32 nCharms;       // Size of charms array
	INT32 nHelms;        // Number of helms in pieces array
	INT32 nChests;       // Same with chests, etc.
	INT32 nGloves;
	INT32 nWaists;
	INT32 nLegs;
	BasicCharm* charms;  // An array of all meaningful charms for this request. Size given by nCharms
	BasicPiece* pieces;  // An array of all pieces of gear consisting of nHelms helms, followed by nChests chests, etc.
	UINT8* results;      // An already allocated array to store the results. Will be read by the dll called.
};

// Almost like BasicPiece with the following important differences:
// 1. s1 and s2 are no longer skill ids but skill index in Req[]. -1 means the skill was not requested
// 2. if s1 == -1 then s2 == -1 (avoids checking s2 if we already know s1 is null)
// 3. it has a score (according to Req[])
struct Piece
{
	int score;
	int s1;
	int s2;
	int r1;
	int r2;
	Gem gem;

	Piece() : score(0), s1(0), s2(0), r1(0), r2(0), gem() {};

	Piece(const BasicPiece& p, const Req* reqs, int rsize);
};

// Search for a given id in an array of Req
int arrayContainsId(const Req*, int, int);

// Creates an temporary list of pieces of gear using Piece rather than BasicPiece (it is Req-dependant)
void _preparePieces(const Req*, int, Piece*&, int, int);

// Same with charms
void _prepareCharms(const Req*, const int, std::map<int, BasicCharm> &);

// The function that actually performs the big loop over all pieces of gear
int doFind(const Req*, int, int);


// DLL function

#ifdef __cplusplus
extern "C" {
#endif

#ifdef MONSTERLOOP_EXPORTS  
#define MONSTERLOOP_API __declspec(dllexport)   
#else  
#define MONSTERLOOP_API __declspec(dllimport)   
#endif  
	// To be called on each request. Browses all armor combination to find those that match the request,
	// returning how many was found (-1 means results found > maxResults) and writing down pieces indexes in the result array
	int  MONSTERLOOP_API __stdcall FindArmors(const int*, const int, const int);

	// To be called only once, before any call to FindArmors(), to pass the data to the dll
	void MONSTERLOOP_API __stdcall TransferData(const MonsterloopData, UINT8*);

#ifdef __cplusplus
}
#endif