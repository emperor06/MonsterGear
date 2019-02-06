using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterGear
{
    public class ArmorSet
    {
        public Charm                  Charm            { get; private set; } // Or maybe use ArmorPiece for charms?
        public List<ArmorPiece>       Pieces           { get; private set; }
        public Dictionary<int, Skill> Skills           { get; private set; }
        public Slots                  GemSlots         { get; private set; }
        public Armor                  Armor            { get; private set; }
        // Bonus
        public Slots                  bonusSlots       { get; private set; }
        public Dictionary<int, Skill> bonusSkills      { get; private set; }
        public List<Skill>            gemsNeeded       { get; private set; }
        // For convenience
        public int                    bonusScore       { get; private set; }
        public int                    gemsNeededCount  { get; private set; }
        public int                    bonusSkillsCount { get; private set; }
        public int                    bonusSlotsCount  { get; private set; }

        public ArmorSet(Charm charm, ArmorPiece Helm, ArmorPiece Chest, ArmorPiece Gloves, ArmorPiece Waist, ArmorPiece Legs, List<Skill> reqs, Slots weaponSlots)
        {
            Skills = new Dictionary<int, Skill>();
            GemSlots = new Slots();
            Charm = charm;
            Pieces = new List<ArmorPiece>();
            Pieces.Add(Helm);
            Pieces.Add(Chest);
            Pieces.Add(Gloves);
            Pieces.Add(Waist);
            Pieces.Add(Legs);
            Armor = new Armor().Add(Helm.armor).Add(Chest.armor).Add(Gloves.armor).Add(Waist.armor).Add(Legs.armor);
            
            // Fills the map of skills on the whole armor set
            int charmId1 = Charm.skill1.id;
            Skill charmSkill1 = Skills.ContainsKey(charmId1) ? Skills[charmId1] : new Skill(Charm.skill1.skillId, 0);
            charmSkill1.rank += charm.skill1.rank;
            Skills[charmId1] = charmSkill1;

            if (Charm.skill2 != null)
            {
                int charmId2 = Charm.skill2.id;
                Skill charmSkill2 = Skills.ContainsKey(charmId2) ? Skills[charmId2] : new Skill(Charm.skill2.skillId, 0);
                charmSkill2.rank += charm.skill2.rank;
                Skills[charmId2] = charmSkill2;
            }

            foreach (ArmorPiece piece in Pieces)
            {
                if (piece.skill1 != null)
                {
                    int id = piece.skill1.id;
                    Skill s = Skills.ContainsKey(id) ? Skills[id] : new Skill(piece.skill1.skillId, 0);
                    s.rank += piece.skill1.rank;
                    Skills[id] = s;
                }
                if (piece.skill2 != null)
                {
                    int id = piece.skill2.id;
                    Skill s = Skills.ContainsKey(id) ? Skills[id] : new Skill(piece.skill2.skillId, 0);
                    s.rank += piece.skill2.rank;
                    Skills[id] = s;
                }
                // Sum up all decoration slots
                GemSlots += piece.slots;
            }

            ComputeBonus(reqs, weaponSlots);
        }

        private void ComputeBonus(List<Skill> reqs, Slots weaponSlots)
        {
            bonusScore       = 0;
            gemsNeededCount  = 0;
            bonusSkillsCount = 0;
            bonusSlotsCount  = 0;
            gemsNeeded = new List<Skill>();
            // Let's start with adding the weapon slots to our slots pool
            bonusSlots = GemSlots + weaponSlots;
            // And assume all skills we already have are bonuses
            bonusSkills = new Dictionary<int, Skill>(Skills);

            // Then remove the skills that were requested as they are not bonuses anymore
            foreach (Skill reqSkill in reqs)
            {
                int gems = 0;
                if (bonusSkills.ContainsKey(reqSkill.skillId.id))
                {
                    bonusSkills[reqSkill.skillId.id].rank -= reqSkill.rank;
                    if (bonusSkills[reqSkill.skillId.id].rank <= 0)
                    {
                        gems = -bonusSkills[reqSkill.skillId.id].rank;
                        bonusSkills.Remove(reqSkill.skillId.id);
                    }
                }
                else
                {
                    gems = reqSkill.rank;
                }
                // Some skills couldn't be removed because the gear lacks some ranks, let's use gems for them
                if (gems > 0)
                {
                    bonusSlots.Remove(reqSkill.skillId.gemLevel, gems);
                    gemsNeeded.Add(new Skill(reqSkill.skillId, gems));
                    gemsNeededCount += gems;
                }
            }

            foreach (var kp in bonusSkills)
            {
                bonusSkillsCount += kp.Value.rank;
            }

            // Now we need to sort out the gems problem: a level-2 gem can fit into a level-3 slot, etc.
            if (bonusSlots.level1 < 0)
            {
                bonusSlots.level2 += bonusSlots.level1;
                bonusSlots.level1 = 0;
            }
            if (bonusSlots.level2 < 0)
            {
                bonusSlots.level3 += bonusSlots.level2;
                bonusSlots.level2 = 0;
            }
            bonusSlotsCount = bonusSlots.Score();
            bonusScore = bonusSkillsCount + bonusSlotsCount;
            if (bonusSlots.level3 < 0)
            {
                // Not enough gem slots which means this ArmorSet does not even fulfill the request!
                bonusScore = -1;
                return;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Charm.name).Append(" - ");
            sb.Append(Charm.skill1.skillId.name).Append(" ").Append(Charm.skill1.rank);
            if (Charm.skill2 != null)
            {
                sb.Append(", ").Append(Charm.skill2.skillId.name).Append(" ").Append(Charm.skill2.rank);
            }
            sb.AppendLine();
            foreach (ArmorPiece piece in Pieces)
            {
                sb.Append(piece.name).Append(" - ");
                if (piece.skill1 != null)
                {
                    sb.Append(piece.skill1.skillId.name).Append(" ").Append(piece.skill1.rank).Append(", ");
                }
                if (piece.skill2 != null)
                {
                    sb.Append(piece.skill2.skillId.name).Append(" ").Append(piece.skill2.rank).Append(", ");
                }
                sb.Append("[").Append(piece.slots.level1).Append(",").Append(piece.slots.level2).Append(",").Append(piece.slots.level3).Append("]");
                sb.AppendLine();
            }
            sb.Append("Bonus: ").Append(bonusScore).AppendLine();
            sb.Append("Bonus Slots: ").Append(bonusSlotsCount).AppendLine();
            if (bonusSlots.level1 > 0)
            {
                sb.Append("    level-I slot x").Append(bonusSlots.level1).AppendLine();
            }
            if (bonusSlots.level2 > 0)
            {
                sb.Append("    level-II slot x").Append(bonusSlots.level2).AppendLine();
            }
            if (bonusSlots.level3 > 0)
            {
                sb.Append("    level-III slot x").Append(bonusSlots.level3).AppendLine();
            }
            sb.Append("Bonus Skills: ").Append(bonusSkillsCount).AppendLine();
            foreach (var kp in bonusSkills)
            {
                sb.Append("    ").Append(kp.Value.skillId.name).Append(" ").Append(kp.Value.rank).AppendLine();
            }
            sb.Append("Gems Needed: ").Append(gemsNeededCount).AppendLine();
            foreach (Skill g in gemsNeeded)
            {
                sb.Append("    ").Append(g.skillId.name).Append(" x").Append(g.rank).AppendLine();
            }
            return sb.ToString();
        }

        public string OneLineToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Score: ").Append(bonusScore).Append("\t");
            sb.Append(System.Text.RegularExpressions.Regex.Replace(Charm.name.Split()[0], @"[^0-9a-zA-Z\ ]+", "")).Append(" | ");
            foreach (ArmorPiece piece in Pieces)
            {
                sb.Append(System.Text.RegularExpressions.Regex.Replace(piece.name.Split()[0], @"[^0-9a-zA-Z\ ]+", ""));
                sb.Append(" | ");
            }
            sb.Append("\tBonus Skills: ");
            sb.Append(bonusSkillsCount);
            sb.Append(", Bonus Slots: ");
            sb.Append(bonusSlotsCount);
            sb.Append(", Gems Needed: ");
            sb.Append(gemsNeededCount);
            return sb.ToString();
        }

    }
}
