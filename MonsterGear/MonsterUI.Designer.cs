namespace MonsterGear
{
    partial class MonsterUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonsterUI));
            this.skillNameText = new System.Windows.Forms.Label();
            this.skillsList = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.favoritesList = new System.Windows.Forms.ListBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.gemSlot3_Combo = new System.Windows.Forms.ComboBox();
            this.gemSlot2_Combo = new System.Windows.Forms.ComboBox();
            this.gemSlot1_Combo = new System.Windows.Forms.ComboBox();
            this.helpButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.wptext = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.resultInfo = new System.Windows.Forms.Label();
            this.skillExtraText = new System.Windows.Forms.Label();
            this.skillDescText = new System.Windows.Forms.Label();
            this.centerPanel = new System.Windows.Forms.Panel();
            this.resultPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // skillNameText
            // 
            this.skillNameText.AutoSize = true;
            this.skillNameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skillNameText.Location = new System.Drawing.Point(18, 10);
            this.skillNameText.Name = "skillNameText";
            this.skillNameText.Size = new System.Drawing.Size(51, 16);
            this.skillNameText.TabIndex = 3;
            this.skillNameText.Text = "label1";
            // 
            // skillsList
            // 
            this.skillsList.Dock = System.Windows.Forms.DockStyle.Left;
            this.skillsList.FormattingEnabled = true;
            this.skillsList.Location = new System.Drawing.Point(0, 0);
            this.skillsList.Name = "skillsList";
            this.skillsList.Size = new System.Drawing.Size(131, 318);
            this.skillsList.TabIndex = 4;
            this.skillsList.Click += new System.EventHandler(this.skillList_Clicked);
            this.skillsList.SelectedIndexChanged += new System.EventHandler(this.skillList_Changed);
            this.skillsList.DoubleClick += new System.EventHandler(this.skillList_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(140, 616);
            this.panel1.TabIndex = 5;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel9);
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 132);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(138, 484);
            this.panel5.TabIndex = 6;
            // 
            // panel9
            // 
            this.panel9.AutoSize = true;
            this.panel9.Controls.Add(this.skillsList);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(0, 166);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(131, 318);
            this.panel9.TabIndex = 7;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.label6);
            this.panel8.Controls.Add(this.label5);
            this.panel8.Controls.Add(this.favoritesList);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(138, 166);
            this.panel8.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(0, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 19);
            this.label6.TabIndex = 5;
            this.label6.Text = "Skills";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 19);
            this.label5.TabIndex = 5;
            this.label5.Text = "Favorites";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // favoritesList
            // 
            this.favoritesList.FormattingEnabled = true;
            this.favoritesList.Location = new System.Drawing.Point(0, 22);
            this.favoritesList.Name = "favoritesList";
            this.favoritesList.Size = new System.Drawing.Size(131, 121);
            this.favoritesList.TabIndex = 0;
            this.favoritesList.Click += new System.EventHandler(this.favorites_Clicked);
            this.favoritesList.SelectedIndexChanged += new System.EventHandler(this.skillList_Changed);
            this.favoritesList.DoubleClick += new System.EventHandler(this.skillList_DoubleClick);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.gemSlot3_Combo);
            this.panel4.Controls.Add(this.gemSlot2_Combo);
            this.panel4.Controls.Add(this.gemSlot1_Combo);
            this.panel4.Controls.Add(this.helpButton);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.wptext);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(140, 132);
            this.panel4.TabIndex = 5;
            // 
            // gemSlot3_Combo
            // 
            this.gemSlot3_Combo.FormattingEnabled = true;
            this.gemSlot3_Combo.Location = new System.Drawing.Point(95, 86);
            this.gemSlot3_Combo.Name = "gemSlot3_Combo";
            this.gemSlot3_Combo.Size = new System.Drawing.Size(31, 21);
            this.gemSlot3_Combo.TabIndex = 6;
            // 
            // gemSlot2_Combo
            // 
            this.gemSlot2_Combo.FormattingEnabled = true;
            this.gemSlot2_Combo.Location = new System.Drawing.Point(50, 86);
            this.gemSlot2_Combo.Name = "gemSlot2_Combo";
            this.gemSlot2_Combo.Size = new System.Drawing.Size(31, 21);
            this.gemSlot2_Combo.TabIndex = 6;
            // 
            // gemSlot1_Combo
            // 
            this.gemSlot1_Combo.FormattingEnabled = true;
            this.gemSlot1_Combo.Location = new System.Drawing.Point(6, 86);
            this.gemSlot1_Combo.Name = "gemSlot1_Combo";
            this.gemSlot1_Combo.Size = new System.Drawing.Size(31, 21);
            this.gemSlot1_Combo.TabIndex = 6;
            // 
            // helpButton
            // 
            this.helpButton.Location = new System.Drawing.Point(30, 15);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(75, 23);
            this.helpButton.TabIndex = 5;
            this.helpButton.Text = "Help";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.help_Clicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Slot #3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Slot #2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Slot #1";
            // 
            // wptext
            // 
            this.wptext.AutoSize = true;
            this.wptext.Location = new System.Drawing.Point(19, 52);
            this.wptext.Name = "wptext";
            this.wptext.Size = new System.Drawing.Size(99, 13);
            this.wptext.TabIndex = 0;
            this.wptext.Text = "Weapon Gem Slots";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkGray;
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.skillExtraText);
            this.panel2.Controls.Add(this.skillDescText);
            this.panel2.Controls.Add(this.skillNameText);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(140, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(874, 132);
            this.panel2.TabIndex = 6;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.resultInfo);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(674, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(200, 132);
            this.panel7.TabIndex = 7;
            // 
            // resultInfo
            // 
            this.resultInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultInfo.Location = new System.Drawing.Point(0, 106);
            this.resultInfo.Name = "resultInfo";
            this.resultInfo.Size = new System.Drawing.Size(197, 23);
            this.resultInfo.TabIndex = 3;
            this.resultInfo.Text = "label1";
            this.resultInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // skillExtraText
            // 
            this.skillExtraText.AutoSize = true;
            this.skillExtraText.Location = new System.Drawing.Point(320, 12);
            this.skillExtraText.Name = "skillExtraText";
            this.skillExtraText.Size = new System.Drawing.Size(35, 13);
            this.skillExtraText.TabIndex = 5;
            this.skillExtraText.Text = "label1";
            // 
            // skillDescText
            // 
            this.skillDescText.AutoSize = true;
            this.skillDescText.Location = new System.Drawing.Point(18, 36);
            this.skillDescText.Name = "skillDescText";
            this.skillDescText.Size = new System.Drawing.Size(35, 13);
            this.skillDescText.TabIndex = 4;
            this.skillDescText.Text = "label1";
            // 
            // centerPanel
            // 
            this.centerPanel.AutoScroll = true;
            this.centerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.centerPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.centerPanel.Location = new System.Drawing.Point(140, 132);
            this.centerPanel.Name = "centerPanel";
            this.centerPanel.Size = new System.Drawing.Size(282, 484);
            this.centerPanel.TabIndex = 8;
            // 
            // resultPanel
            // 
            this.resultPanel.AutoScroll = true;
            this.resultPanel.AutoSize = true;
            this.resultPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.resultPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.resultPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultPanel.Location = new System.Drawing.Point(422, 132);
            this.resultPanel.Name = "resultPanel";
            this.resultPanel.Size = new System.Drawing.Size(592, 484);
            this.resultPanel.TabIndex = 9;
            // 
            // MonsterUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 616);
            this.Controls.Add(this.resultPanel);
            this.Controls.Add(this.centerPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MonsterUI";
            this.Text = "MonsterGear";
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label skillNameText;
        private System.Windows.Forms.ListBox skillsList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label wptext;
        private System.Windows.Forms.Label skillExtraText;
        private System.Windows.Forms.Label skillDescText;
        private System.Windows.Forms.Panel centerPanel;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ListBox favoritesList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox gemSlot1_Combo;
        private System.Windows.Forms.ComboBox gemSlot3_Combo;
        private System.Windows.Forms.ComboBox gemSlot2_Combo;
        private System.Windows.Forms.Panel resultPanel;
        private System.Windows.Forms.Label resultInfo;
    }
}

