namespace View
{
    partial class Welcome
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
            this.secondDiceBox = new System.Windows.Forms.TextBox();
            this.firstDiceBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.playerToPlay = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.RollDiceBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // secondDiceBox
            // 
            this.secondDiceBox.Enabled = false;
            this.secondDiceBox.Location = new System.Drawing.Point(515, 346);
            this.secondDiceBox.Name = "secondDiceBox";
            this.secondDiceBox.Size = new System.Drawing.Size(29, 20);
            this.secondDiceBox.TabIndex = 23;
            // 
            // firstDiceBox
            // 
            this.firstDiceBox.Enabled = false;
            this.firstDiceBox.Location = new System.Drawing.Point(515, 309);
            this.firstDiceBox.Name = "firstDiceBox";
            this.firstDiceBox.Size = new System.Drawing.Size(29, 20);
            this.firstDiceBox.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(330, 346);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 17);
            this.label6.TabIndex = 21;
            this.label6.Text = "Black Player Dice Result :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(330, 309);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "White Player Dice Result :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(215, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(439, 31);
            this.label1.TabIndex = 25;
            this.label1.Text = "Welcome in BACKGOMMAN Game";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(298, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(281, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "*Please Roll the Dice To Determine the First Player to Play";
            // 
            // playerToPlay
            // 
            this.playerToPlay.Enabled = false;
            this.playerToPlay.Location = new System.Drawing.Point(318, 446);
            this.playerToPlay.Name = "playerToPlay";
            this.playerToPlay.Size = new System.Drawing.Size(98, 20);
            this.playerToPlay.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(422, 447);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 17);
            this.label3.TabIndex = 28;
            this.label3.Text = "Player To Play First";
            // 
            // RollDiceBtn
            // 
            this.RollDiceBtn.Location = new System.Drawing.Point(393, 215);
            this.RollDiceBtn.Name = "RollDiceBtn";
            this.RollDiceBtn.Size = new System.Drawing.Size(84, 23);
            this.RollDiceBtn.TabIndex = 24;
            this.RollDiceBtn.Text = "Roll Dice";
            this.RollDiceBtn.UseVisualStyleBackColor = true;
            this.RollDiceBtn.Click += new System.EventHandler(this.RollDiceBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(361, 516);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 48);
            this.button1.TabIndex = 29;
            this.button1.Text = "Start the Game";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 609);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.playerToPlay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RollDiceBtn);
            this.Controls.Add(this.secondDiceBox);
            this.Controls.Add(this.firstDiceBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Name = "Welcome";
            this.Text = "Welcome";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox secondDiceBox;
        private System.Windows.Forms.TextBox firstDiceBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox playerToPlay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button RollDiceBtn;
        private System.Windows.Forms.Button button1;
    }
}