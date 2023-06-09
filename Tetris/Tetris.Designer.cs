namespace Tetris
{
    partial class Tetris
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
            this.newGameLabel = new System.Windows.Forms.Label();
            this.gameOverLabel = new System.Windows.Forms.Label();
            this.DropTimer = new System.Windows.Forms.Timer(this.components);
            this.spaceDropTimer = new System.Windows.Forms.Timer(this.components);
            this.scorePanel = new System.Windows.Forms.Panel();
            this.levelLabel = new System.Windows.Forms.Label();
            this.levelName = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.scoreName = new System.Windows.Forms.Label();
            this.nextBlockPanel = new System.Windows.Forms.Panel();
            this.nextBlockName = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.scorePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.Black;
            this.mainPanel.Controls.Add(this.newGameLabel);
            this.mainPanel.Controls.Add(this.gameOverLabel);
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(250, 500);
            this.mainPanel.TabIndex = 0;
            // 
            // newGameLabel
            // 
            this.newGameLabel.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.newGameLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.newGameLabel.Font = new System.Drawing.Font("Bernard MT Condensed", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newGameLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.newGameLabel.Location = new System.Drawing.Point(75, 250);
            this.newGameLabel.Name = "newGameLabel";
            this.newGameLabel.Size = new System.Drawing.Size(100, 80);
            this.newGameLabel.TabIndex = 5;
            this.newGameLabel.Text = "NEW GAME";
            this.newGameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.newGameLabel.Visible = false;
            this.newGameLabel.Click += new System.EventHandler(this.newGameLabel_Click);
            this.newGameLabel.MouseLeave += new System.EventHandler(this.newGameLabel_MouseLeave);
            this.newGameLabel.MouseHover += new System.EventHandler(this.newGameLabel_MouseHover);
            // 
            // gameOverLabel
            // 
            this.gameOverLabel.BackColor = System.Drawing.Color.Crimson;
            this.gameOverLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gameOverLabel.Font = new System.Drawing.Font("Bernard MT Condensed", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameOverLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gameOverLabel.Location = new System.Drawing.Point(25, 160);
            this.gameOverLabel.Name = "gameOverLabel";
            this.gameOverLabel.Size = new System.Drawing.Size(200, 80);
            this.gameOverLabel.TabIndex = 4;
            this.gameOverLabel.Text = "GAME OVER";
            this.gameOverLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.gameOverLabel.Visible = false;
            // 
            // DropTimer
            // 
            this.DropTimer.Enabled = true;
            this.DropTimer.Interval = 600;
            this.DropTimer.Tick += new System.EventHandler(this.softDropTimer_Tick);
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
            this.scorePanel.Location = new System.Drawing.Point(262, 288);
            this.scorePanel.Name = "scorePanel";
            this.scorePanel.Size = new System.Drawing.Size(200, 200);
            this.scorePanel.TabIndex = 1;
            // 
            // levelLabel
            // 
            this.levelLabel.BackColor = System.Drawing.Color.Black;
            this.levelLabel.Font = new System.Drawing.Font("Bernard MT Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelLabel.ForeColor = System.Drawing.Color.Transparent;
            this.levelLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.levelLabel.Location = new System.Drawing.Point(50, 45);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(100, 30);
            this.levelLabel.TabIndex = 4;
            this.levelLabel.Text = "1";
            this.levelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // levelName
            // 
            this.levelName.Font = new System.Drawing.Font("Bernard MT Condensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelName.Location = new System.Drawing.Point(65, 11);
            this.levelName.Name = "levelName";
            this.levelName.Size = new System.Drawing.Size(66, 25);
            this.levelName.TabIndex = 2;
            this.levelName.Text = "LEVEL";
            // 
            // scoreLabel
            // 
            this.scoreLabel.BackColor = System.Drawing.Color.Black;
            this.scoreLabel.Font = new System.Drawing.Font("Bernard MT Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.ForeColor = System.Drawing.Color.White;
            this.scoreLabel.Location = new System.Drawing.Point(50, 140);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(100, 30);
            this.scoreLabel.TabIndex = 3;
            this.scoreLabel.Text = "0";
            this.scoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scoreName
            // 
            this.scoreName.Font = new System.Drawing.Font("Bernard MT Condensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreName.Location = new System.Drawing.Point(65, 105);
            this.scoreName.Name = "scoreName";
            this.scoreName.Size = new System.Drawing.Size(66, 25);
            this.scoreName.TabIndex = 2;
            this.scoreName.Text = "SCORE";
            // 
            // nextBlockPanel
            // 
            this.nextBlockPanel.BackColor = System.Drawing.Color.Black;
            this.nextBlockPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.nextBlockPanel.Location = new System.Drawing.Point(262, 37);
            this.nextBlockPanel.Name = "nextBlockPanel";
            this.nextBlockPanel.Size = new System.Drawing.Size(200, 225);
            this.nextBlockPanel.TabIndex = 2;
            // 
            // nextBlockName
            // 
            this.nextBlockName.Font = new System.Drawing.Font("Bernard MT Condensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextBlockName.Location = new System.Drawing.Point(334, 9);
            this.nextBlockName.Name = "nextBlockName";
            this.nextBlockName.Size = new System.Drawing.Size(60, 25);
            this.nextBlockName.TabIndex = 3;
            this.nextBlockName.Text = "NEXT";
            // 
            // Tetris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(474, 500);
            this.Controls.Add(this.nextBlockName);
            this.Controls.Add(this.nextBlockPanel);
            this.Controls.Add(this.scorePanel);
            this.Controls.Add(this.mainPanel);
            this.Name = "Tetris";
            this.Text = "Tetris";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.mainPanel.ResumeLayout(false);
            this.scorePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Timer DropTimer;
        private System.Windows.Forms.Timer spaceDropTimer;
        private System.Windows.Forms.Panel scorePanel;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label scoreName;
        private System.Windows.Forms.Label levelLabel;
        private System.Windows.Forms.Label levelName;
        private System.Windows.Forms.Panel nextBlockPanel;
        private System.Windows.Forms.Label nextBlockName;
        private System.Windows.Forms.Label newGameLabel;
        private System.Windows.Forms.Label gameOverLabel;
    }
}

