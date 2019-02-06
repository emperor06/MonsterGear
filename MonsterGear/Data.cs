using System.Runtime.InteropServices;
using System.Text;

namespace MonsterGear
{

    public struct Rank
    {
        public int    rank { get; private set; }
        public string desc { get; private set; }
    }

    // Represents a game skill: a name and a description for each of its rank.
    public class SkillId : System.IComparable<SkillId>
    {
        public int    id        { get; private set; }
        public string name      { get; private set; }
        public int    maxRank   { get; private set; }
        public int    gemLevel  { get; private set; }
        public int    charmRank { get; private set; }
        public Rank[] ranks     { get; private set; }

        public override string ToString()
        {
            return name;
        }

        public string descToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Rank r in ranks)
            {
                sb.Append(r.rank).Append(". ").Append(r.desc).AppendLine();
            }
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            SkillId item = obj as SkillId;
            return item == null ? false : item.id == id;
        }

        public override int GetHashCode()
        {
            return id;
        }

        public int CompareTo(SkillId skill)
        {
            return id.CompareTo(skill.id);
        }
    }

    // A SkillId at a given rank
    public class Skill
    {
        public  SkillId skillId { get; private set; }
        public  int     rank    { get; set; }
        private int    _id;
        public  int     id      {
            get         { return _id; }
            private set { _id = value; skillId = (value == 0) ? null : MonsterGear.GetSkillId(value); }
        }

        public Skill() { skillId = null; _id = 0; rank = 0; }

        public Skill(SkillId s, int r) { skillId = s; _id = s.id; rank = r; }

        public override string ToString()
        {
            return skillId.name + " " + rank;
        }

        public int ToReq()
        {
            System.Diagnostics.Debug.Assert(skillId != null, "ToReq() should never be called on a null skill!");
            return skillId.id | (rank << 8) | (skillId.gemLevel << 16);
        }
    }

    // Describes the protection an armor offers.
    public class Armor
    {
        public int physical  { get; private set; }
        public int fire      { get; private set; }
        public int water     { get; private set; }
        public int lightning { get; private set; }
        public int ice       { get; private set; }
        public int dragon    { get; private set; }

        public Armor Add(Armor a)
        {
            physical  += a.physical;
            fire      += a.fire;
            water     += a.water;
            lightning += a.lightning;
            ice       += a.ice;
            dragon    += a.dragon;
            return this;
        }
    }

    // A game charm/necklace, which consists of name and a couple of skills.
    public class Charm
    {
        public string name { get; protected set; }
        private Skill _skill1;
        public Skill skill1
        {
            get { return _skill1; }
            protected set { _skill1 = (value.skillId == null) ? null : value; }
        }
        private Skill _skill2;
        public Skill skill2
        {
            get { return _skill2; }
            protected set { _skill2 = (value.skillId == null) ? null : value; }
        }
    }

    // A game piece of gear which is pretty much a charm with some potential gem slots
    public class ArmorPiece : Charm
    {
        public string setName { get; private set; }
        public Armor armor { get; private set; }
        public Slots slots { get; private set; }
    }

    // For c++
    //[StructLayout(LayoutKind.Sequential, Size = 20), System.Serializable]
    struct BasicPiece
    {
        public int s1;
        public int s2;
        public int r1;
        public int r2;
        public int gem;
    }

    struct BasicCharm
    {
        public byte s1;
        public byte s2;
        public byte r1;
        public byte r2;
    }

    unsafe struct MonsterloopData
    {
        public int maxResults;
        public int nCharms;
        public int nHelms;
        public int nChests;
        public int nGloves;
        public int nWaists;
        public int nLegs;
        public BasicCharm* charms;
        public BasicPiece* pieces;
    }
}
