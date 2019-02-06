namespace MonsterGear
{
    partial class ResultControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultControl));
            this.countLabel = new System.Windows.Forms.Label();
            this.prevButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.bonusScoreLabel = new System.Windows.Forms.Label();
            this.bonusSkillsLabel = new System.Windows.Forms.Label();
            this.bonusSlotsLabel = new System.Windows.Forms.Label();
            this.requiredGemsLabel = new System.Windows.Forms.Label();
            this.requiredGemsList = new System.Windows.Forms.ListView();
            this.bonusSkillsList = new System.Windows.Forms.ListView();
            this.bonusSlotsList = new System.Windows.Forms.ListView();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.armorPhysical = new System.Windows.Forms.Label();
            this.armorFire = new System.Windows.Forms.Label();
            this.armorWater = new System.Windows.Forms.Label();
            this.armorLightning = new System.Windows.Forms.Label();
            this.armorIce = new System.Windows.Forms.Label();
            this.armorDragon = new System.Windows.Forms.Label();
            this.pieceTable = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pieceTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.Location = new System.Drawing.Point(284, 446);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(35, 13);
            this.countLabel.TabIndex = 2;
            this.countLabel.Text = "label3";
            // 
            // prevButton
            // 
            this.prevButton.Location = new System.Drawing.Point(248, 441);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(30, 23);
            this.prevButton.TabIndex = 3;
            this.prevButton.Text = "<";
            this.prevButton.UseVisualStyleBackColor = true;
            this.prevButton.Click += new System.EventHandler(this.previousClicked);
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(325, 441);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(30, 23);
            this.nextButton.TabIndex = 4;
            this.nextButton.Text = ">";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Bonus Score :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Bonus Skills :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(148, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Bonus Slots :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(274, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Required Gems :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bonusScoreLabel
            // 
            this.bonusScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bonusScoreLabel.Location = new System.Drawing.Point(94, 10);
            this.bonusScoreLabel.Name = "bonusScoreLabel";
            this.bonusScoreLabel.Size = new System.Drawing.Size(22, 13);
            this.bonusScoreLabel.TabIndex = 6;
            this.bonusScoreLabel.Text = "0";
            this.bonusScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bonusScoreLabel.Click += new System.EventHandler(this.bonusScoreLabel_Click);
            // 
            // bonusSkillsLabel
            // 
            this.bonusSkillsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bonusSkillsLabel.Location = new System.Drawing.Point(94, 34);
            this.bonusSkillsLabel.Name = "bonusSkillsLabel";
            this.bonusSkillsLabel.Size = new System.Drawing.Size(22, 13);
            this.bonusSkillsLabel.TabIndex = 6;
            this.bonusSkillsLabel.Text = "0";
            this.bonusSkillsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bonusSlotsLabel
            // 
            this.bonusSlotsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bonusSlotsLabel.Location = new System.Drawing.Point(226, 34);
            this.bonusSlotsLabel.Name = "bonusSlotsLabel";
            this.bonusSlotsLabel.Size = new System.Drawing.Size(22, 13);
            this.bonusSlotsLabel.TabIndex = 6;
            this.bonusSlotsLabel.Text = "0";
            this.bonusSlotsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // requiredGemsLabel
            // 
            this.requiredGemsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requiredGemsLabel.Location = new System.Drawing.Point(371, 34);
            this.requiredGemsLabel.Name = "requiredGemsLabel";
            this.requiredGemsLabel.Size = new System.Drawing.Size(22, 13);
            this.requiredGemsLabel.TabIndex = 6;
            this.requiredGemsLabel.Text = "0";
            this.requiredGemsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // requiredGemsList
            // 
            this.requiredGemsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.requiredGemsList.Location = new System.Drawing.Point(277, 50);
            this.requiredGemsList.Name = "requiredGemsList";
            this.requiredGemsList.Size = new System.Drawing.Size(116, 134);
            this.requiredGemsList.TabIndex = 7;
            this.requiredGemsList.UseCompatibleStateImageBehavior = false;
            this.requiredGemsList.View = System.Windows.Forms.View.List;
            // 
            // bonusSkillsList
            // 
            this.bonusSkillsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bonusSkillsList.Location = new System.Drawing.Point(10, 50);
            this.bonusSkillsList.Name = "bonusSkillsList";
            this.bonusSkillsList.Size = new System.Drawing.Size(121, 134);
            this.bonusSkillsList.TabIndex = 7;
            this.bonusSkillsList.UseCompatibleStateImageBehavior = false;
            this.bonusSkillsList.View = System.Windows.Forms.View.List;
            // 
            // bonusSlotsList
            // 
            this.bonusSlotsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bonusSlotsList.Location = new System.Drawing.Point(151, 50);
            this.bonusSlotsList.Name = "bonusSlotsList";
            this.bonusSlotsList.Size = new System.Drawing.Size(107, 134);
            this.bonusSlotsList.TabIndex = 7;
            this.bonusSlotsList.UseCompatibleStateImageBehavior = false;
            this.bonusSlotsList.View = System.Windows.Forms.View.List;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(410, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Total Armor";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(413, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Physical";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(413, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Fire";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(413, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Water";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(413, 114);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Lightning";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(413, 132);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(22, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "Ice";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(413, 150);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "Dragon";
            // 
            // armorPhysical
            // 
            this.armorPhysical.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.armorPhysical.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.armorPhysical.Location = new System.Drawing.Point(465, 60);
            this.armorPhysical.Name = "armorPhysical";
            this.armorPhysical.Size = new System.Drawing.Size(41, 13);
            this.armorPhysical.TabIndex = 8;
            this.armorPhysical.Text = "0";
            this.armorPhysical.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // armorFire
            // 
            this.armorFire.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.armorFire.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.armorFire.Location = new System.Drawing.Point(465, 78);
            this.armorFire.Name = "armorFire";
            this.armorFire.Size = new System.Drawing.Size(41, 13);
            this.armorFire.TabIndex = 8;
            this.armorFire.Text = "0";
            this.armorFire.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // armorWater
            // 
            this.armorWater.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.armorWater.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.armorWater.Location = new System.Drawing.Point(465, 96);
            this.armorWater.Name = "armorWater";
            this.armorWater.Size = new System.Drawing.Size(41, 13);
            this.armorWater.TabIndex = 8;
            this.armorWater.Text = "0";
            this.armorWater.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // armorLightning
            // 
            this.armorLightning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.armorLightning.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.armorLightning.Location = new System.Drawing.Point(465, 114);
            this.armorLightning.Name = "armorLightning";
            this.armorLightning.Size = new System.Drawing.Size(41, 13);
            this.armorLightning.TabIndex = 8;
            this.armorLightning.Text = "0";
            this.armorLightning.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // armorIce
            // 
            this.armorIce.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.armorIce.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.armorIce.Location = new System.Drawing.Point(465, 132);
            this.armorIce.Name = "armorIce";
            this.armorIce.Size = new System.Drawing.Size(41, 13);
            this.armorIce.TabIndex = 8;
            this.armorIce.Text = "0";
            this.armorIce.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // armorDragon
            // 
            this.armorDragon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.armorDragon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.armorDragon.Location = new System.Drawing.Point(465, 150);
            this.armorDragon.Name = "armorDragon";
            this.armorDragon.Size = new System.Drawing.Size(41, 13);
            this.armorDragon.TabIndex = 8;
            this.armorDragon.Text = "0";
            this.armorDragon.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pieceTable
            // 
            this.pieceTable.ColumnCount = 4;
            this.pieceTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.pieceTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.pieceTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.pieceTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.pieceTable.Controls.Add(this.pictureBox1, 0, 0);
            this.pieceTable.Controls.Add(this.pictureBox2, 0, 1);
            this.pieceTable.Controls.Add(this.pictureBox3, 0, 2);
            this.pieceTable.Controls.Add(this.pictureBox4, 2, 0);
            this.pieceTable.Controls.Add(this.pictureBox5, 2, 1);
            this.pieceTable.Controls.Add(this.pictureBox6, 2, 2);
            this.pieceTable.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.pieceTable.Location = new System.Drawing.Point(10, 208);
            this.pieceTable.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.pieceTable.Name = "pieceTable";
            this.pieceTable.RowCount = 3;
            this.pieceTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.pieceTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.pieceTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.pieceTable.Size = new System.Drawing.Size(524, 203);
            this.pieceTable.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 65);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 64);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(0, 130);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(64, 64);
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(265, 0);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(64, 64);
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(265, 65);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(64, 64);
            this.pictureBox5.TabIndex = 0;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(265, 130);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(64, 64);
            this.pictureBox6.TabIndex = 0;
            this.pictureBox6.TabStop = false;
            // 
            // ResultControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pieceTable);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.armorDragon);
            this.Controls.Add(this.armorIce);
            this.Controls.Add(this.armorLightning);
            this.Controls.Add(this.armorWater);
            this.Controls.Add(this.armorFire);
            this.Controls.Add(this.armorPhysical);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.bonusSlotsList);
            this.Controls.Add(this.bonusSkillsList);
            this.Controls.Add(this.requiredGemsList);
            this.Controls.Add(this.requiredGemsLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bonusSlotsLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bonusSkillsLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bonusScoreLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.prevButton);
            this.Controls.Add(this.countLabel);
            this.Name = "ResultControl";
            this.Size = new System.Drawing.Size(580, 480);
            this.Load += new System.EventHandler(this.ResultControl_Load);
            this.pieceTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label countLabel;
        private System.Windows.Forms.Button prevButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label bonusScoreLabel;
        private System.Windows.Forms.Label bonusSkillsLabel;
        private System.Windows.Forms.Label bonusSlotsLabel;
        private System.Windows.Forms.Label requiredGemsLabel;
        private System.Windows.Forms.ListView requiredGemsList;
        private System.Windows.Forms.ListView bonusSkillsList;
        private System.Windows.Forms.ListView bonusSlotsList;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label armorPhysical;
        private System.Windows.Forms.Label armorFire;
        private System.Windows.Forms.Label armorWater;
        private System.Windows.Forms.Label armorLightning;
        private System.Windows.Forms.Label armorIce;
        private System.Windows.Forms.Label armorDragon;
        private System.Windows.Forms.TableLayoutPanel pieceTable;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
    }
}
