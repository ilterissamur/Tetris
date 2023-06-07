using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Tetris : Form
    {
        Random rand = new Random();

        int lines = 0;
        int level = 1;
        int[] dropTimerIntervals = { 600, 600, 450, 300, 275, 250, 225, 200, 185, 170, 155, 140, 125, 110, 100, 90, 80, 70, 60, 50, 45, 40, 35, 30, 25, 25};
        int score = 0;
        bool gameStart = false;
        int currentTet = 0;
        int nextTet = 0;
        bool isGameOver = false;

        public Tetris()
        {
            InitializeComponent();
            nextTetromino();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Right && !borderRight())
            {
                moveRight();
            }
            
            if(e.KeyCode == Keys.Left && !borderLeft())
            {
                moveLeft();
            }

            if(e.KeyCode == Keys.Down && !borderDown())
            {
                moveDown();
                score++;
                scoreLabel.Text = score.ToString();
            }

            if(e.KeyCode == Keys.Space && !borderDown())
            {
                spaceDropTimer.Enabled = true;
            }

            if(e.KeyCode == Keys.Up)
            {
                rotateTetrominos();
            }
        }

        private void softDropTimer_Tick(object sender, EventArgs e)
        {
            if(!borderDown()) 
            {
                moveDown();
            }
            else
            {
                disableTetromino();
            }
        }

        private void spaceDropTimer_Tick(object sender, EventArgs e)
        {
            if (!borderDown())
            {
                moveDown();
                score += 2;
                scoreLabel.Text = score.ToString();
            }
            else
            {
                spaceDropTimer.Enabled = false;
            }
        }

        public void moveRight()
        {
            foreach( Control c in mainPanel.Controls ) 
            {
                if(c.GetType() == typeof(PictureBox))
                {
                    PictureBox pb = c as PictureBox;

                    if(pb.Enabled && pb.Visible)
                    {
                        pb.Left = pb.Left + 25;
                    }
                }
            }
        }

        public void moveLeft()
        {
            foreach (Control c in mainPanel.Controls)
            {
                if (c.GetType() == typeof(PictureBox))
                {
                    PictureBox pb = c as PictureBox;

                    if (pb.Enabled && pb.Visible)
                    {
                        pb.Left = pb.Left - 25;
                    }
                }
            }
        }

        public void moveDown()
        {
            foreach (Control c in mainPanel.Controls)
            {
                if (c.GetType() == typeof(PictureBox))
                {
                    PictureBox pb = c as PictureBox;

                    if (pb.Enabled && pb.Visible)
                    {
                        pb.Top = pb.Top + 25;
                    }
                }
            }
        }

        public void isRowFull()
        {
            int fullRowsCounter = 0;
            int clearedLineCounter = 0;

            for(int i=0; i<20; i++)
            {
                foreach (Control c in mainPanel.Controls)
                {
                    if (c.GetType() == typeof(PictureBox))
                    {
                        PictureBox pb = c as PictureBox;

                        if (!pb.Enabled && pb.Visible && pb.Location.Y == i*25)
                        {
                            fullRowsCounter++;
                        }
                    }
                }

                if (fullRowsCounter > 9)
                {
                    foreach (Control c in mainPanel.Controls)
                    {
                        if (c.GetType() == typeof(PictureBox))
                        {
                            PictureBox pb = c as PictureBox;

                            if (!pb.Enabled && pb.Visible && pb.Location.Y == i * 25)
                            {
                                pb.Visible = false;
                            }
                        }
                    }

                    foreach (Control c in mainPanel.Controls)
                    {
                        if (c.GetType() == typeof(PictureBox))
                        {
                            PictureBox pb = c as PictureBox;

                            if (!pb.Enabled && pb.Visible && pb.Location.Y < i * 25)
                            {
                                pb.Top = pb.Top + 25;
                            }
                        }
                    }
                    clearedLineCounter++;
                    lines++;

                    if(lines % 5 == 0)
                    {
                        level++;
                        levelLabel.Text = level.ToString();
                        if (level < 26)
                        {
                            DropTimer.Interval = dropTimerIntervals[level];
                        }
                        else
                        {
                            DropTimer.Interval = 25;
                        }
                    }

                    score = score + 100;
                    scoreLabel.Text = score.ToString();
                }
                fullRowsCounter = 0;
            }

            if(clearedLineCounter == 1)
            {
                score = score + 100;
            }
            else if(clearedLineCounter == 2)
            {
                score = score + 300;
            }
            else if(clearedLineCounter == 3)
            {
                score = score + 500;
            }
            else if (clearedLineCounter == 4) 
            {
                score = score + 800;
            }
        }

        private void newGameLabel_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            nextBlockPanel.Controls.Clear();
            gameOverLabel.Visible = false;
            newGameLabel.Visible = false;
            lines = 0;
            level = 1;
            score = 0;
            gameStart = false;
            currentTet = 0;
            nextTet = 0;    
            isGameOver = false;
            scoreLabel.Text = "0";
            levelLabel.Text = "1";
            DropTimer.Enabled = true;
            nextTetromino();
            DropTimer.Interval = 600;

        }

        private void newGameLabel_MouseHover(object sender, EventArgs e)
        {
            newGameLabel.BackColor = Color.ForestGreen;
        }

        private void newGameLabel_MouseLeave(object sender, EventArgs e)
        {
            newGameLabel.BackColor = Color.DarkSeaGreen;
        }
    }
}