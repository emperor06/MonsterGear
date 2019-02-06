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
    public partial class PieceControl : UserControl
    {
        private ToolTip toolTip;
        private Charm _Piece;
        public  Charm Piece
        {
            get
            {
                return _Piece;
            }
            set
            {
                _Piece = value;
                UpdateValue();
            }
        }

        public PieceControl()
        {
            InitializeComponent();
            toolTip = new ToolTip();
        }

        public void UpdateValue()
        {
            if (Piece is ArmorPiece)
            {
                setNameLabel.Text = (Piece as ArmorPiece).setName;
                toolTip.SetToolTip(setNameLabel, Piece.name);
            }
            else
            {
                setNameLabel.Text = Piece.name;
            }
            
            skill1Label.Text = Piece.skill1 != null ? "- " + Piece.skill1.ToString() : "";
            skill2Label.Text = Piece.skill2 != null ? "- " + Piece.skill2.ToString() : "";
        }
    }
}
