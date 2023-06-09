namespace Tetris
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.softDropTimer = new System.Windows.Forms.Timer(this.components);
            this.spaceDropTimer = new System.Windows.Forms.Timer(this.components);
            this.scorePanel = new System.Windows.Forms.Panel();
            this.levelLabel = new System.Windows.Forms.Label();
            this.levelName = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.scoreName = new System.Windows.Forms.Label();
            this.scorePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.Black;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(250, 500);
            this.mainPanel.TabIndex = 0;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // softDropTimer
            // 
            this.softDropTimer.Enabled = true;
            this.softDropTimer.Interval = 600;
            this.softDropTimer.Tick += new System.EventHandler(this.softDropTimer_Tick);
            // 
            // spaceDropTimer
            // 
            this.spaceDropTimer.Interval = 5;
            this.spaceDropTimer.Tick += new System.EventHandler(this.spaceDropTimer_Tick);
            // 
            // scorePanel
            // 
            this.scorePanel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.scorePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scorePanel.Controls.Add(this.levelLabel);
            this.scorePanel.Controls.Add(this.levelName);
            this.scorePanel.Controls.Add(this.scoreLabel);
            this.scorePanel.Controls.Add(this.scoreName);
            this.scorePanel.Location = new System.Drawing.Point(270, 290);
            this.scorePanel.Name = "scorePanel";
            this.scorePanel.Size = new System.Drawing.Size(184, 188);
            this.scorePanel.TabIndex = 1;
            // 
            // levelLabel
            // 
            this.levelLabel.BackColor = System.Drawing.Color.Black;
            this.levelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelLabel.ForeColor = System.Drawing.Color.Transparent;
            this.levelLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.levelLabel.Location = new System.Drawing.Point(43, 59);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(100, 28);
            this.levelLabel.TabIndex = 4;
            this.levelLabel.Text = "1";
            this.levelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // levelName
            // 
            this.levelName.AutoSize = true;
            this.levelName.Font = new System.Drawing.Font("Bernard MT Condensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelName.Location = new System.Drawing.Point(65, 25);
            this.levelName.Name = "levelName";
            this.levelName.Size = new System.Drawing.Size(63, 25);
            this.levelName.TabIndex = 2;
            this.levelName.Text = "LEVEL";
            // 
            // scoreLabel
            // 
            this.scoreLabel.BackColor = System.Drawing.Color.Black;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.ForeColor = System.Drawing.Color.White;
            this.scoreLabel.Location = new System.Drawing.Point(43, 135);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(100, 28);
            this.scoreLabel.TabIndex = 3;
            this.scoreLabel.Text = "0";
            this.scoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scoreName
            // 
            this.scoreName.AutoSize = true;
            this.scoreName.Font = new System.Drawing.Font("Bernard MT Condensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreName.Location = new System.Drawing.Point(65, 104);
            this.scoreName.Name = "scoreName";
            this.scoreName.Size = new System.Drawing.Size(65, 25);
            this.scoreName.TabIndex = 2;
            this.scoreName.Text = "SCORE";
            this.scoreName.Click += new System.EventHandler(this.lineName_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(474, 500);
            this.Controls.Add(this.scorePanel);
            this.Controls.Add(this.mainPanel);
            this.Name = "Form1";
            this.Text = "Tetris";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.scorePanel.ResumeLayout(false);
            this.scorePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Timer softDropTimer;
        private System.Windows.Forms.Timer spaceDropTimer;
        private System.Windows.Forms.Panel scorePanel;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label scoreName;
        private System.Windows.Forms.Label levelLabel;
        private System.Windows.Forms.Label levelName;
    }
}

