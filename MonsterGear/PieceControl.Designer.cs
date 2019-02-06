namespace MonsterGear
{
    partial class PieceControl
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
            this.setNameLabel = new System.Windows.Forms.Label();
            this.skill1Label = new System.Windows.Forms.Label();
            this.skill2Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // setNameLabel
            // 
            this.setNameLabel.AutoSize = true;
            this.setNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setNameLabel.Location = new System.Drawing.Point(3, 4);
            this.setNameLabel.Name = "setNameLabel";
            this.setNameLabel.Size = new System.Drawing.Size(41, 13);
            this.setNameLabel.TabIndex = 0;
            this.setNameLabel.Text = "label1";
            // 
            // skill1Label
            // 
            this.skill1Label.AutoSize = true;
            this.skill1Label.Location = new System.Drawing.Point(16, 18);
            this.skill1Label.Name = "skill1Label";
            this.skill1Label.Size = new System.Drawing.Size(35, 13);
            this.skill1Label.TabIndex = 0;
            this.skill1Label.Text = "label1";
            // 
            // skill2Label
            // 
            this.skill2Label.AutoSize = true;
            this.skill2Label.Location = new System.Drawing.Point(16, 31);
            this.skill2Label.Name = "skill2Label";
            this.skill2Label.Size = new System.Drawing.Size(35, 13);
            this.skill2Label.TabIndex = 0;
            this.skill2Label.Text = "label1";
            // 
            // PieceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.skill2Label);
            this.Controls.Add(this.skill1Label);
            this.Controls.Add(this.setNameLabel);
            this.Name = "PieceControl";
            this.Size = new System.Drawing.Size(200, 60);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label setNameLabel;
        private System.Windows.Forms.Label skill1Label;
        private System.Windows.Forms.Label skill2Label;
    }
}
