using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterGear
{
    public class Slots
    {
        public int level1 { get; set; }
        public int level2 { get; set; }
        public int level3 { get; set; }

        public Slots() : this(0, 0, 0) { }

        public Slots(int l1, int l2, int l3)
        {
            level1 = l1;
            level2 = l2;
            level3 = l3;
        }

        public int AsInt()
        {
            return level1 | level2 << 8 | level3 << 16;
        }

        public static Slots FromInt(int gem)
        {
            return new Slots(gem & 0xFF, gem >> 8 & 0xFF, gem >> 16 & 0xFF);
        }

        public static Slots operator +(Slots a, Slots b)
        {
            return new Slots(a.level1 + b.level1, a.level2 + b.level2, a.level3 + b.level3);
        }

        public static Slots operator -(Slots a, Slots b)
        {
            return new Slots(a.level1 - b.level1, a.level2 - b.level2, a.level3 - b.level3);
        }

        public void Add(int level, int amount)
        {
            switch (level)
            {
                case 1:
                    level1 += amount;
                    break;
                case 2:
                    level2 += amount;
                    break;
                case 3:
                    level3 += amount;
                    break;
            }
        }

        public void Remove(int level, int amount)
        {
            Add(level, -amount);
        }

        public int Score()
        {
            return level1 + level2 + level3;
        }
    }
}
