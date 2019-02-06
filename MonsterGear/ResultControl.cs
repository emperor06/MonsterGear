using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterGear
{
    public partial class ResultControl : UserControl
    {
        private int CurrentSet;
        private List<ArmorSet> _Armors;
        public List<ArmorSet> Armors
        {
            get
            {
                return _Armors;
            }
            set
            {
                if (value == null)
                {
                    _Armors = null;
                    this.Visible = false;
                } else
                {
                    _Armors = value;
                    CurrentSet = 0;
                    if (Armors != null && Armors.Count != 0)
                    {
                        UpdateResults();
                        this.Visible = true;
                    }
                }
                
            }
        }
        PieceControl charmControl  = new PieceControl();
        PieceControl helmControl   = new PieceControl();
        PieceControl chestControl  = new PieceControl();
        PieceControl glovesControl = new PieceControl();
        PieceControl waistControl  = new PieceControl();
        PieceControl legsControl   = new PieceControl();

        public ResultControl()
        {
            InitializeComponent();
            pieceTable.Controls.Add(charmControl,  1, 0);
            pieceTable.Controls.Add(helmControl,   1, 1);
            pieceTable.Controls.Add(chestControl,  1, 2);
            pieceTable.Controls.Add(glovesControl, 3, 0);
            pieceTable.Controls.Add(waistControl,  3, 1);
            pieceTable.Controls.Add(legsControl,   3, 2);
            this.Visible = false;
        }

        private void UpdateResults()
        {
            countLabel.Text = (CurrentSet + 1) + "/" + Armors.Count;
            ArmorSet a = Armors[CurrentSet];

            bonusScoreLabel.Text   = "" + a.bonusScore;
            bonusSkillsLabel.Text  = "" + a.bonusSkillsCount;
            bonusSlotsLabel.Text   = "" + a.bonusSlotsCount;
            requiredGemsLabel.Text = "" + a.gemsNeededCount;

            bonusSkillsList.Items.Clear();
            foreach (Skill s in a.bonusSkills.Values)
            {
                bonusSkillsList.Items.Add(s.skillId.name + " " + s.rank);
            }

            bonusSlotsList.Items.Clear();
            if (a.bonusSlots.level1 != 0)
                bonusSlotsList.Items.Add(a.bonusSlots.level1 + "x level-1");
            if (a.bonusSlots.level2 != 0)
                bonusSlotsList.Items.Add(a.bonusSlots.level2 + "x level-2");
            if (a.bonusSlots.level3 != 0)
                bonusSlotsList.Items.Add(a.bonusSlots.level3 + "x level-3");

            requiredGemsList.Items.Clear();
            foreach (Skill s in a.gemsNeeded)
            {
                requiredGemsList.Items.Add(s.rank + "x " + s.skillId.name);
            }

            armorPhysical.Text  = "" + a.Armor.physical;
            armorFire.Text      = "" + a.Armor.fire;
            armorWater.Text     = "" + a.Armor.water;
            armorLightning.Text = "" + a.Armor.lightning;
            armorIce.Text       = "" + a.Armor.ice;
            armorDragon.Text    = "" + a.Armor.dragon;

            charmControl.Piece  = a.Charm;
            helmControl.Piece   = a.Pieces[0];
            chestControl.Piece  = a.Pieces[1];
            glovesControl.Piece = a.Pieces[2];
            waistControl.Piece  = a.Pieces[3];
            legsControl.Piece   = a.Pieces[4];
            
        }

        private void previousClicked(object sender, EventArgs e)
        {
            CurrentSet = CurrentSet > 0 ? CurrentSet - 1 : Armors.Count - 1;
            UpdateResults();
        }

        private void nextClicked(object sender, EventArgs e)
        {
            CurrentSet = CurrentSet < Armors.Count - 1 ? CurrentSet + 1 : 0;
            UpdateResults();
        }

        private void ResultControl_Load(object sender, EventArgs e)
        {

        }

        private void bonusScoreLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
