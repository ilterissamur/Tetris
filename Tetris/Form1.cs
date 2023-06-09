using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Form1 : Form
    {
        Random rand = new Random();

        int lines = 0;
        int level = 1;
        int[] dropTimerIntervals = { 600, 600, 450, 300, 275, 250, 225, 200, 185, 170, 155, 140, 125, 110, 100, 90, 80, 70, 60, 50, 45, 40, 35, 30, 25, 25};
        int score = 0;

        public Form1()
        {
            InitializeComponent();
            nextTetromino();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
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

            if(e.KeyCode == Keys.Space)
            {
                spaceDropTimer.Enabled = true;
            }

            if(e.KeyCode == Keys.Up)
            {
                rotateTetrominos();
            }
        }

        public void disableTetromino()
        {
            foreach(Control c in mainPanel.Controls) 
            {
                if(c.GetType() == typeof(PictureBox))
                {
                    PictureBox pb = c as PictureBox;

                    if(pb.Enabled && pb.Visible)
                    {
                        pb.Enabled = false;
                    }
                }
            }

            isRowFull();
            nextTetromino();
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

        public void createTetrominos(int x)
        {
            PictureBox[] tetrominos = new PictureBox[4];

            for(int i=0; i<4; i++)
            {
                var tetromino = new PictureBox();
                tetrominos[i] = tetromino;
                tetromino.Size = new Size(25, 25);
                tetromino.BorderStyle = BorderStyle.FixedSingle;
                tetromino.Enabled = true;
                tetromino.Visible = true;
                if (x == 0)
                {
                    tetromino.BackColor = Color.Red;

                    if(i == 0)
                    {
                        tetromino.Location = new Point(75, -50);
                    }
                    else if(i==1)
                    {
                        tetromino.Location = new Point(100, -50);
                    }
                    else if(i== 2)
                    {
                        tetromino.Location = new Point(100, -25);
                    }
                    else if(i == 3)
                    {
                        tetromino.Location = new Point(125, -25);
                    }
                }
                else if (x == 1)
                {
                    tetromino.BackColor = Color.Orange;

                    if (i == 0)
                    {
                        tetromino.Location = new Point(75, -25);
                    }
                    else if (i == 1)
                    {
                        tetromino.Location = new Point(100, -25);
                    }
                    else if (i == 2)
                    {
                        tetromino.Location = new Point(125, -25);
                    }
                    else if (i == 3)
                    {
                        tetromino.Location = new Point(125, -50);
                    }
                }
                else if (x == 2)
                {
                    tetromino.BackColor = Color.Yellow;

                    if (i == 0)
                    {
                        tetromino.Location = new Point(100, -50);
                    }
                    else if (i == 1)
                    {
                        tetromino.Location = new Point(125, -50);
                    }
                    else if (i == 2)
                    {
                        tetromino.Location = new Point(100, -25);
                    }
                    else if (i == 3)
                    {
                        tetromino.Location = new Point(125, -25);
                    }
                }
                else if (x == 3)
                {
                    tetromino.BackColor = Color.Chartreuse;

                    if (i == 0)
                    {
                        tetromino.Location = new Point(75, -25);
                    }
                    else if (i == 1)
                    {
                        tetromino.Location = new Point(100, -25);
                    }
                    else if (i == 2)
                    {
                        tetromino.Location = new Point(100, -50);
                    }
                    else if (i == 3)
                    {
                        tetromino.Location = new Point(125, -50);
                    }
                }
                else if (x == 4)
                {
                    tetromino.BackColor = Color.Cyan;

                    if (i == 0)
                    {
                        tetromino.Location = new Point(75, -25);
                    }
                    else if (i == 1)
                    {
                        tetromino.Location = new Point(100, -25);
                    }
                    else if (i == 2)
                    {
                        tetromino.Location = new Point(125, -25);
                    }
                    else if (i == 3)
                    {
                        tetromino.Location = new Point(150, -25);
                    }
                }
                else if (x == 5)
                {
                    tetromino.BackColor = Color.Blue;

                    if (i == 0)
                    {
                        tetromino.Location = new Point(75, -25);
                    }
                    else if (i == 1)
                    {
                        tetromino.Location = new Point(100, -25);
                    }
                    else if (i == 2)
                    {
                        tetromino.Location = new Point(125, -25);
                    }
                    else if (i == 3)
                    {
                        tetromino.Location = new Point(75, -50);
                    }
                }
                else if (x == 6)
                {
                    tetromino.BackColor = Color.Magenta;

                    if (i == 0)
                    {
                        tetromino.Location = new Point(75, -25);
                    }
                    else if (i == 1)
                    {
                        tetromino.Location = new Point(100, -25);
                    }
                    else if (i == 2)
                    {
                        tetromino.Location = new Point(125, -25);
                    }
                    else if (i == 3)
                    {
                        tetromino.Location = new Point(100, -50);
                    }
                }
                
                mainPanel.Controls.Add(tetromino);
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

        public bool borderDown()
        {
            bool border = false;

            foreach(Control c in mainPanel.Controls)
            {
                if(c.GetType() == typeof(PictureBox))
                {
                    PictureBox pb = c as PictureBox;

                    if(pb.Enabled && pb.Visible)
                    {
                        if(pb.Top + 25 > 475)
                        {
                            border = true;
                        }
                    }
                }
            }

            if(!border)
            {
                foreach (Control c in mainPanel.Controls)
                {
                    if (c.GetType() == typeof(PictureBox))
                    {
                        PictureBox pb = c as PictureBox;

                        if (pb.Enabled && pb.Visible)
                        {
                            foreach (Control i in mainPanel.Controls)
                            {
                                if (i.GetType() == typeof(PictureBox))
                                {
                                    PictureBox pbx = i as PictureBox;

                                    if (!pbx.Enabled && pbx.Visible && pb.Location.X == pbx.Location.X && pb.Location.Y == pbx.Location.Y - 25)
                                    {
                                        border = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return border;
        }

        public bool borderRight()
        {
            bool border = false;

            foreach (Control c in mainPanel.Controls)
            {
                if (c.GetType() == typeof(PictureBox))
                {
                    PictureBox pb = c as PictureBox;

                    if (pb.Enabled && pb.Visible)
                    {
                        if (pb.Left + 25 > 225)
                        {
                            border = true;
                        }
                    }
                }
            }

            if (!border)
            {
                foreach (Control c in mainPanel.Controls)
                {
                    if (c.GetType() == typeof(PictureBox))
                    {
                        PictureBox pb = c as PictureBox;

                        if (pb.Enabled && pb.Visible)
                        {
                            foreach (Control i in mainPanel.Controls)
                            {
                                if (i.GetType() == typeof(PictureBox))
                                {
                                    PictureBox pbx = i as PictureBox;

                                    if (!pbx.Enabled && pbx.Visible && pb.Location.X == pbx.Location.X - 25 && pb.Location.Y == pbx.Location.Y)
                                    {
                                        border = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return border;
        }

        public bool borderLeft()
        {
            bool border = false;

            foreach (Control c in mainPanel.Controls)
            {
                if (c.GetType() == typeof(PictureBox))
                {
                    PictureBox pb = c as PictureBox;

                    if (pb.Enabled && pb.Visible)
                    {
                        if (pb.Left - 25 < 0)
                        {
                            border = true;
                        }
                    }
                }
            }

            if (!border)
            {
                foreach (Control c in mainPanel.Controls)
                {
                    if (c.GetType() == typeof(PictureBox))
                    {
                        PictureBox pb = c as PictureBox;

                        if (pb.Enabled && pb.Visible)
                        {
                            foreach (Control i in mainPanel.Controls)
                            {
                                if (i.GetType() == typeof(PictureBox))
                                {
                                    PictureBox pbx = i as PictureBox;

                                    if (!pbx.Enabled && pbx.Visible && pb.Location.X == pbx.Location.X + 25 && pb.Location.Y == pbx.Location.Y)
                                    {
                                        border = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return border;
        }

        
        public void nextTetromino()
        {
            int random = rand.Next(0,7);
            createTetrominos(random);
        }

        public void rotateTetrominos()
        {
            int[,] blocksLocations = new int[4, 2];
            int[,] turningLocations = new int[4, 2];
            int counter = 0;

            foreach (Control c in mainPanel.Controls)
            {
                if (c.GetType() == typeof(PictureBox))
                {
                    PictureBox pb = c as PictureBox;

                    if (pb.Enabled && pb.Visible)
                    {
                        blocksLocations[counter,0] = pb.Location.X;
                        blocksLocations[counter, 1] = pb.Location.Y;
                        counter++;
                    }
                }
            }

            int subX = blocksLocations[0, 0];
            int subY = blocksLocations[0, 1];

            for(int i=0; i < 4; i++) 
            {
                turningLocations[i, 0] = blocksLocations[i, 0] - subX;
                turningLocations[i, 1] = blocksLocations[i, 1] - subY;
            }

            if (!rotationBorders(turningLocations, blocksLocations))
            {
                foreach (Control c in mainPanel.Controls)
                {
                    if (c.GetType() == typeof(PictureBox))
                    {
                        PictureBox pb = c as PictureBox;

                        if (pb.Enabled && pb.Visible)
                        {
                            //red tetromino
                            if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                            turningLocations[1, 0] == 25 && turningLocations[1, 1] == 0 &&
                            turningLocations[2, 0] == 25 && turningLocations[2, 1] == 25 &&
                            turningLocations[3, 0] == 50 && turningLocations[3, 1] == 25)
                            {
                                if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                                {
                                    pb.Left = pb.Left + 25;
                                    pb.Top = pb.Top - 25;
                                }
                                else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                                {
                                    pb.Left = pb.Left - 25;
                                    pb.Top = pb.Top - 25;
                                }
                                else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                                {
                                    pb.Left = pb.Left - 50;
                                }
                            }
                            else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                            turningLocations[1, 0] == 0 && turningLocations[1, 1] == 25 &&
                            turningLocations[2, 0] == -25 && turningLocations[2, 1] == 25 &&
                            turningLocations[3, 0] == -25 && turningLocations[3, 1] == 50)
                            {
                                if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                                {
                                    pb.Left = pb.Left + 25;
                                    pb.Top = pb.Top + 25;
                                }
                                else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                                {
                                    pb.Left = pb.Left + 25;
                                    pb.Top = pb.Top - 25;
                                }
                                else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                                {
                                    pb.Top = pb.Top - 50;
                                }

                            }
                            else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                            turningLocations[1, 0] == -25 && turningLocations[1, 1] == 0 &&
                            turningLocations[2, 0] == -25 && turningLocations[2, 1] == -25 &&
                            turningLocations[3, 0] == -50 && turningLocations[3, 1] == -25)
                            {
                                if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                                {
                                    pb.Left = pb.Left - 25;
                                    pb.Top = pb.Top + 25;
                                }
                                else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                                {
                                    pb.Left = pb.Left + 25;
                                    pb.Top = pb.Top + 25;
                                }
                                else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                                {
                                    pb.Left = pb.Left + 50;
                                }
                            }
                            else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                            turningLocations[1, 0] == 0 && turningLocations[1, 1] == -25 &&
                            turningLocations[2, 0] == 25 && turningLocations[2, 1] == -25 &&
                            turningLocations[3, 0] == 25 && turningLocations[3, 1] == -50)
                            {
                                if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                                {
                                    pb.Left = pb.Left - 25;
                                    pb.Top = pb.Top - 25;
                                }
                                else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                                {
                                    pb.Left = pb.Left - 25;
                                    pb.Top = pb.Top + 25;
                                }
                                else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                                {
                                    pb.Top = pb.Top + 50;
                                }
                            }

                            //orange tetromino
                            if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                            turningLocations[1, 0] == 25 && turningLocations[1, 1] == 0 &&
                            turningLocations[2, 0] == 50 && turningLocations[2, 1] == 0 &&
                            turningLocations[3, 0] == 50 && turningLocations[3, 1] == -25)
                            {
                                if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                                {
                                    pb.Left = pb.Left + 25;
                                    pb.Top = pb.Top - 25;
                                }
                                else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                                {
                                    pb.Left = pb.Left - 25;
                                    pb.Top = pb.Top + 25;
                                }
                                else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                                {
                                    pb.Top = pb.Top + 50;
                                }
                            }
                            else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                            turningLocations[1, 0] == 0 && turningLocations[1, 1] == 25 &&
                            turningLocations[2, 0] == 0 && turningLocations[2, 1] == 50 &&
                            turningLocations[3, 0] == 25 && turningLocations[3, 1] == 50)
                            {
                                if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                                {
                                    pb.Left = pb.Left + 25;
                                    pb.Top = pb.Top + 25;
                                }
                                else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                                {
                                    pb.Left = pb.Left - 25;
                                    pb.Top = pb.Top - 25;
                                }
                                else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                                {
                                    pb.Left = pb.Left - 50;
                                }
                            }
                            else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                            turningLocations[1, 0] == -25 && turningLocations[1, 1] == 0 &&
                            turningLocations[2, 0] == -50 && turningLocations[2, 1] == 0 &&
                            turningLocations[3, 0] == -50 && turningLocations[3, 1] == 25)
                            {
                                if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                                {
                                    pb.Left = pb.Left - 25;
                                    pb.Top = pb.Top + 25;
                                }
                                else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                                {
                                    pb.Left = pb.Left + 25;
                                    pb.Top = pb.Top - 25;
                                }
                                else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                                {
                                    pb.Top = pb.Top - 50;
                                }
                            }
                            else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                            turningLocations[1, 0] == 0 && turningLocations[1, 1] == -25 &&
                            turningLocations[2, 0] == 0 && turningLocations[2, 1] == -50 &&
                            turningLocations[3, 0] == -25 && turningLocations[3, 1] == -50)
                            {
                                if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                                {
                                    pb.Left = pb.Left - 25;
                                    pb.Top = pb.Top - 25;
                                }
                                else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                                {
                                    pb.Left = pb.Left + 25;
                                    pb.Top = pb.Top + 25;
                                }
                                else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                                {
                                    pb.Left = pb.Left + 50;
                                }
                            }

                            //green tetromino

                            if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                            turningLocations[1, 0] == 25 && turningLocations[1, 1] == 0 &&
                            turningLocations[2, 0] == 25 && turningLocations[2, 1] == -25 &&
                            turningLocations[3, 0] == 50 && turningLocations[3, 1] == -25)
                            {
                                if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                                {
                                    pb.Left = pb.Left + 25;
                                    pb.Top = pb.Top - 25;
                                }
                                else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                                {
                                    pb.Left = pb.Left + 25;
                                    pb.Top = pb.Top + 25;
                                }
                                else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                                {
                                    pb.Top = pb.Top + 50;
                                }
                            }
                            else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                            turningLocations[1, 0] == 0 && turningLocations[1, 1] == 25 &&
                            turningLocations[2, 0] == 25 && turningLocations[2, 1] == 25 &&
                            turningLocations[3, 0] == 25 && turningLocations[3, 1] == 50)
                            {
                                if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                                {
                                    pb.Left = pb.Left + 25;
                                    pb.Top = pb.Top + 25;
                                }
                                else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                                {
                                    pb.Left = pb.Left - 25;
                                    pb.Top = pb.Top + 25;
                                }
                                else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                                {
                                    pb.Left = pb.Left - 50;
                                }
                            }
                            else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                            turningLocations[1, 0] == -25 && turningLocations[1, 1] == 0 &&
                            turningLocations[2, 0] == -25 && turningLocations[2, 1] == 25 &&
                            turningLocations[3, 0] == -50 && turningLocations[3, 1] == 25)
                            {
                                if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                                {
                                    pb.Left = pb.Left - 25;
                                    pb.Top = pb.Top + 25;
                                }
                                else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                                {
                                    pb.Left = pb.Left - 25;
                                    pb.Top = pb.Top - 25;
                                }
                                else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                                {
                                    pb.Top = pb.Top - 50;
                                }
                            }
                            else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                            turningLocations[1, 0] == 0 && turningLocations[1, 1] == -25 &&
                            turningLocations[2, 0] == -25 && turningLocations[2, 1] == -25 &&
                            turningLocations[3, 0] == -25 && turningLocations[3, 1] == -50)
                            {
                                if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                                {
                                    pb.Left = pb.Left - 25;
                                    pb.Top = pb.Top - 25;
                                }
                                else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                                {
                                    pb.Left = pb.Left + 25;
                                    pb.Top = pb.Top - 25;
                                }
                                else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                                {
                                    pb.Left = pb.Left + 50;
                                }
                            }

                            //cyan tetromino

                            if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                            turningLocations[1, 0] == 25 && turningLocations[1, 1] == 0 &&
                            turningLocations[2, 0] == 50 && turningLocations[2, 1] == 0 &&
                            turningLocations[3, 0] == 75 && turningLocations[3, 1] == 0)
                            {
                                if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                                {
                                    pb.Left = pb.Left + 50;
                                    pb.Top = pb.Top - 25;
                                }
                                else if (pb.Location.X == blocksLocations[1, 0] && pb.Location.Y == blocksLocations[1, 1])
                                {
                                    pb.Left = pb.Left + 25;
                                }
                                else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                                {
                                    pb.Top = pb.Top + 25;
                                }
                                else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                                {
                                    pb.Left = pb.Left - 25;
                                    pb.Top = pb.Top + 50;
                                }
                            }
                            else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                            turningLocations[1, 0] == 0 && turningLocations[1, 1] == 25 &&
                            turningLocations[2, 0] == 0 && turningLocations[2, 1] == 50 &&
                            turningLocations[3, 0] == 0 && turningLocations[3, 1] == 75)
                            {
                                if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                                {
                                    pb.Left = pb.Left + 25;
                                    pb.Top = pb.Top + 50;
                                }
                                else if (pb.Location.X == blocksLocations[1, 0] && pb.Location.Y == blocksLocations[1, 1])
                                {
                                    pb.Top = pb.Top + 25;
                                }
                                else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                                {
                                    pb.Left = pb.Left - 25;
                                }
                                else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                                {
                                    pb.Left = pb.Left - 50;
                                    pb.Top = pb.Top - 25;
                                }
                            }
                            else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                            turningLocations[1, 0] == -25 && turningLocations[1, 1] == 0 &&
                            turningLocations[2, 0] == -50 && turningLocations[2, 1] == 0 &&
                            turningLocations[3, 0] == -75 && turningLocations[3, 1] == 0)
                            {
                                if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                                {
                                    pb.Left = pb.Left - 50;
                                    pb.Top = pb.Top + 25;
                                }
                                else if (pb.Location.X == blocksLocations[1, 0] && pb.Location.Y == blocksLocations[1, 1])
                                {
                                    pb.Left = pb.Left - 25;
                                }
                                else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                                {
                                    ;
                                    pb.Top = pb.Top - 25;
                                }
                                else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                                {
                                    pb.Left = pb.Left + 25;
                                    pb.Top = pb.Top - 50;
                                }
                            }
                            else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                            turningLocations[1, 0] == 0 && turningLocations[1, 1] == -25 &&
                            turningLocations[2, 0] == 0 && turningLocations[2, 1] == -50 &&
                            turningLocations[3, 0] == 0 && turningLocations[3, 1] == -75)
                            {
                                if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                                {
                                    pb.Left = pb.Left - 25;
                                    pb.Top = pb.Top - 50;
                                }
                                else if (pb.Location.X == blocksLocations[1, 0] && pb.Location.Y == blocksLocations[1, 1])
                                {
                                    pb.Top = pb.Top - 25;
                                }
                                else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                                {
                                    pb.Left = pb.Left + 25;
                                }
                                else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                                {
                                    pb.Left = pb.Left + 50;
                                    pb.Top = pb.Top + 25;
                                }
                            }

                            //blue tetromino

                            if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                            turningLocations[1, 0] == 25 && turningLocations[1, 1] == 0 &&
                            turningLocations[2, 0] == 50 && turningLocations[2, 1] == 0 &&
                            turningLocations[3, 0] == 0 && turningLocations[3, 1] == -25)
                            {
                                if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                                {
                                    pb.Left = pb.Left + 25;
                                    pb.Top = pb.Top - 25;
                                }
                                else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                                {
                                    pb.Left = pb.Left - 25;
                                    pb.Top = pb.Top + 25;
                                }
                                else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                                {
                                    pb.Left = pb.Left + 50;
                                }
                            }
                            else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                            turningLocations[1, 0] == 0 && turningLocations[1, 1] == 25 &&
                            turningLocations[2, 0] == 0 && turningLocations[2, 1] == 50 &&
                            turningLocations[3, 0] == 25 && turningLocations[3, 1] == 0)
                            {
                                if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                                {
                                    pb.Left = pb.Left + 25;
                                    pb.Top = pb.Top + 25;
                                }
                                else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                                {
                                    pb.Left = pb.Left - 25;
                                    pb.Top = pb.Top - 25;
                                }
                                else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                                {
                                    pb.Top = pb.Top + 50;
                                }
                            }
                            else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                            turningLocations[1, 0] == -25 && turningLocations[1, 1] == 0 &&
                            turningLocations[2, 0] == -50 && turningLocations[2, 1] == 0 &&
                            turningLocations[3, 0] == 0 && turningLocations[3, 1] == 25)
                            {
                                if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                                {
                                    pb.Left = pb.Left - 25;
                                    pb.Top = pb.Top + 25;
                                }
                                else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                                {
                                    pb.Left = pb.Left + 25;
                                    pb.Top = pb.Top - 25;
                                }
                                else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                                {
                                    pb.Left = pb.Left - 50;
                                }
                            }
                            else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                            turningLocations[1, 0] == 0 && turningLocations[1, 1] == -25 &&
                            turningLocations[2, 0] == 0 && turningLocations[2, 1] == -50 &&
                            turningLocations[3, 0] == -25 && turningLocations[3, 1] == 0)
                            {
                                if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                                {
                                    pb.Left = pb.Left - 25;
                                    pb.Top = pb.Top - 25;
                                }
                                else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                                {
                                    pb.Left = pb.Left + 25;
                                    pb.Top = pb.Top + 25;
                                }
                                else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                                {
                                    pb.Top = pb.Top - 50;
                                }
                            }

                            //purple tetromino

                            if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                            turningLocations[1, 0] == 25 && turningLocations[1, 1] == 0 &&
                            turningLocations[2, 0] == 50 && turningLocations[2, 1] == 0 &&
                            turningLocations[3, 0] == 25 && turningLocations[3, 1] == -25)
                            {
                                if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                                {
                                    pb.Left = pb.Left + 25;
                                    pb.Top = pb.Top - 25;
                                }
                                else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                                {
                                    pb.Left = pb.Left - 25;
                                    pb.Top = pb.Top + 25;
                                }
                                else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                                {
                                    pb.Left = pb.Left + 25;
                                    pb.Top = pb.Top + 25;
                                }
                            }
                            else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                            turningLocations[1, 0] == 0 && turningLocations[1, 1] == 25 &&
                            turningLocations[2, 0] == 0 && turningLocations[2, 1] == 50 &&
                            turningLocations[3, 0] == 25 && turningLocations[3, 1] == 25)
                            {
                                if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                                {
                                    pb.Left = pb.Left + 25;
                                    pb.Top = pb.Top + 25;
                                }
                                else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                                {
                                    pb.Left = pb.Left - 25;
                                    pb.Top = pb.Top - 25;
                                }
                                else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                                {
                                    pb.Left = pb.Left - 25;
                                    pb.Top = pb.Top + 25;
                                }
                            }
                            else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                            turningLocations[1, 0] == -25 && turningLocations[1, 1] == 0 &&
                            turningLocations[2, 0] == -50 && turningLocations[2, 1] == 0 &&
                            turningLocations[3, 0] == -25 && turningLocations[3, 1] == 25)
                            {
                                if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                                {
                                    pb.Left = pb.Left - 25;
                                    pb.Top = pb.Top + 25;
                                }
                                else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                                {
                                    pb.Left = pb.Left + 25;
                                    pb.Top = pb.Top - 25;
                                }
                                else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                                {
                                    pb.Left = pb.Left - 25;
                                    pb.Top = pb.Top - 25;
                                }
                            }
                            else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                            turningLocations[1, 0] == 0 && turningLocations[1, 1] == -25 &&
                            turningLocations[2, 0] == 0 && turningLocations[2, 1] == -50 &&
                            turningLocations[3, 0] == -25 && turningLocations[3, 1] == -25)
                            {
                                if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                                {
                                    pb.Left = pb.Left - 25;
                                    pb.Top = pb.Top - 25;
                                }
                                else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                                {
                                    pb.Left = pb.Left + 25;
                                    pb.Top = pb.Top + 25;
                                }
                                else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                                {
                                    pb.Left = pb.Left + 25;
                                    pb.Top = pb.Top - 25;
                                }
                            }
                        }
                    }
                }
            }
        }

        public bool rotationBorders(int[,] turningLocations, int[,] blocksLocations)
        {
            bool border = false;

            foreach (Control c in mainPanel.Controls)
            {
                if (c.GetType() == typeof(PictureBox))
                {
                    PictureBox pb = c as PictureBox;

                    if (pb.Enabled && pb.Visible)
                    {
                        //red tetromino
                        if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                        turningLocations[1, 0] == 25 && turningLocations[1, 1] == 0 &&
                        turningLocations[2, 0] == 25 && turningLocations[2, 1] == 25 &&
                        turningLocations[3, 0] == 50 && turningLocations[3, 1] == 25)
                        {
                            isLocLegal(pb, ref border, 25, -25);

                            if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                            {
                                isLocLegal(pb, ref border, 25, -25);
                                
                                if(border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                            {
                                isLocLegal(pb, ref border, -25, -25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                            {
                                isLocLegal(pb, ref border, -50, 0);

                                if (border)
                                {
                                    break;
                                }
                            }
                        }
                        else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                        turningLocations[1, 0] == 0 && turningLocations[1, 1] == 25 &&
                        turningLocations[2, 0] == -25 && turningLocations[2, 1] == 25 &&
                        turningLocations[3, 0] == -25 && turningLocations[3, 1] == 50)
                        {
                            if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                            {
                                isLocLegal(pb, ref border, 25, 25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                            {
                                isLocLegal(pb, ref border, 25, -25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                            {
                                isLocLegal(pb, ref border, 0, -50);

                                if (border)
                                {
                                    break;
                                }
                            }

                        }
                        else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                        turningLocations[1, 0] == -25 && turningLocations[1, 1] == 0 &&
                        turningLocations[2, 0] == -25 && turningLocations[2, 1] == -25 &&
                        turningLocations[3, 0] == -50 && turningLocations[3, 1] == -25)
                        {
                            if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                            {
                                isLocLegal(pb, ref border, -25, 25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                            {
                                isLocLegal(pb, ref border, 25, 25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                            {
                                isLocLegal(pb, ref border, 50, 0);

                                if (border)
                                {
                                    break;
                                }
                            }
                        }
                        else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                        turningLocations[1, 0] == 0 && turningLocations[1, 1] == -25 &&
                        turningLocations[2, 0] == 25 && turningLocations[2, 1] == -25 &&
                        turningLocations[3, 0] == 25 && turningLocations[3, 1] == -50)
                        {
                            if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                            {
                                isLocLegal(pb, ref border, 25, -25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                            {
                                isLocLegal(pb, ref border, -25, 25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                            {
                                isLocLegal(pb, ref border, 0, 50);

                                if (border)
                                {
                                    break;
                                }
                            }
                        }

                        //orange tetromino
                        if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                        turningLocations[1, 0] == 25 && turningLocations[1, 1] == 0 &&
                        turningLocations[2, 0] == 50 && turningLocations[2, 1] == 0 &&
                        turningLocations[3, 0] == 50 && turningLocations[3, 1] == -25)
                        {
                            if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                            {
                                isLocLegal(pb, ref border, 25, -25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                            {
                                isLocLegal(pb, ref border, -25, 25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                            {
                                isLocLegal(pb, ref border, 0, 50);

                                if (border)
                                {
                                    break;
                                }
                            }
                        }
                        else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                        turningLocations[1, 0] == 0 && turningLocations[1, 1] == 25 &&
                        turningLocations[2, 0] == 0 && turningLocations[2, 1] == 50 &&
                        turningLocations[3, 0] == 25 && turningLocations[3, 1] == 50)
                        {
                            if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                            {
                                isLocLegal(pb, ref border, 25, 25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                            {
                                isLocLegal(pb, ref border, -25, -25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                            {
                                isLocLegal(pb, ref border, -50, 0);

                                if (border)
                                {
                                    break;
                                }
                            }
                        }
                        else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                        turningLocations[1, 0] == -25 && turningLocations[1, 1] == 0 &&
                        turningLocations[2, 0] == -50 && turningLocations[2, 1] == 0 &&
                        turningLocations[3, 0] == -50 && turningLocations[3, 1] == 25)
                        {
                            if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                            {
                                isLocLegal(pb, ref border, -25, 25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                            {
                                isLocLegal(pb, ref border, 25, -25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                            {
                                isLocLegal(pb, ref border, 0, -50);

                                if (border)
                                {
                                    break;
                                }
                            }
                        }
                        else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                        turningLocations[1, 0] == 0 && turningLocations[1, 1] == -25 &&
                        turningLocations[2, 0] == 0 && turningLocations[2, 1] == -50 &&
                        turningLocations[3, 0] == -25 && turningLocations[3, 1] == -50)
                        {
                            if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                            {
                                isLocLegal(pb, ref border, -25, -25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                            {
                                isLocLegal(pb, ref border, 25, 25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                            {
                                isLocLegal(pb, ref border, 50, 0);

                                if (border)
                                {
                                    break;
                                }
                            }
                        }

                        //green tetromino

                        if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                        turningLocations[1, 0] == 25 && turningLocations[1, 1] == 0 &&
                        turningLocations[2, 0] == 25 && turningLocations[2, 1] == -25 &&
                        turningLocations[3, 0] == 50 && turningLocations[3, 1] == -25)
                        {
                            if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                            {
                                isLocLegal(pb, ref border, 25, -25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                            {
                                isLocLegal(pb, ref border, 25, 25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                            {
                                isLocLegal(pb, ref border, 0, 50);

                                if (border)
                                {
                                    break;
                                }
                            }
                        }
                        else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                        turningLocations[1, 0] == 0 && turningLocations[1, 1] == 25 &&
                        turningLocations[2, 0] == 25 && turningLocations[2, 1] == 25 &&
                        turningLocations[3, 0] == 25 && turningLocations[3, 1] == 50)
                        {
                            if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                            {
                                isLocLegal(pb, ref border, 25, 25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                            {
                                isLocLegal(pb, ref border, -25, 25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                            {
                                isLocLegal(pb, ref border, -50, 0);

                                if (border)
                                {
                                    break;
                                }
                            }
                        }
                        else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                        turningLocations[1, 0] == -25 && turningLocations[1, 1] == 0 &&
                        turningLocations[2, 0] == -25 && turningLocations[2, 1] == 25 &&
                        turningLocations[3, 0] == -50 && turningLocations[3, 1] == 25)
                        {
                            if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                            {
                                isLocLegal(pb, ref border, -25, 25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                            {
                                isLocLegal(pb, ref border, -25, -25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                            {
                                isLocLegal(pb, ref border, 0, -50);

                                if (border)
                                {
                                    break;
                                }
                            }
                        }
                        else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                        turningLocations[1, 0] == 0 && turningLocations[1, 1] == -25 &&
                        turningLocations[2, 0] == -25 && turningLocations[2, 1] == -25 &&
                        turningLocations[3, 0] == -25 && turningLocations[3, 1] == -50)
                        {
                            if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                            {
                                isLocLegal(pb, ref border, -25, -25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                            {
                                isLocLegal(pb, ref border, 25, -25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                            {
                                isLocLegal(pb, ref border, 50, 0);

                                if (border)
                                {
                                    break;
                                }
                            }
                        }

                        //cyan tetromino

                        if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                        turningLocations[1, 0] == 25 && turningLocations[1, 1] == 0 &&
                        turningLocations[2, 0] == 50 && turningLocations[2, 1] == 0 &&
                        turningLocations[3, 0] == 75 && turningLocations[3, 1] == 0)
                        {
                            if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                            {
                                isLocLegal(pb, ref border, 50, -25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[1, 0] && pb.Location.Y == blocksLocations[1, 1])
                            {
                                isLocLegal(pb, ref border, 25, 0);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                            {
                                isLocLegal(pb, ref border, 0, 25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                            {
                                isLocLegal(pb, ref border, -25, 50);

                                if (border)
                                {
                                    break;
                                }
                            }
                        }
                        else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                        turningLocations[1, 0] == 0 && turningLocations[1, 1] == 25 &&
                        turningLocations[2, 0] == 0 && turningLocations[2, 1] == 50 &&
                        turningLocations[3, 0] == 0 && turningLocations[3, 1] == 75)
                        {
                            if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                            {
                                isLocLegal(pb, ref border, 25, 50);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[1, 0] && pb.Location.Y == blocksLocations[1, 1])
                            {
                                isLocLegal(pb, ref border, 0, 25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                            {
                                isLocLegal(pb, ref border, -25, 0);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                            {
                                isLocLegal(pb, ref border, 50, -25);

                                if (border)
                                {
                                    break;
                                }
                            }
                        }
                        else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                        turningLocations[1, 0] == -25 && turningLocations[1, 1] == 0 &&
                        turningLocations[2, 0] == -50 && turningLocations[2, 1] == 0 &&
                        turningLocations[3, 0] == -75 && turningLocations[3, 1] == 0)
                        {
                            if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                            {
                                isLocLegal(pb, ref border, -50, 25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[1, 0] && pb.Location.Y == blocksLocations[1, 1])
                            {
                                isLocLegal(pb, ref border, -25, 0);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                            {
                                ;
                                isLocLegal(pb, ref border, 0, 25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                            {
                                isLocLegal(pb, ref border, 25, -50);

                                if (border)
                                {
                                    break;
                                }
                            }
                        }
                        else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                        turningLocations[1, 0] == 0 && turningLocations[1, 1] == -25 &&
                        turningLocations[2, 0] == 0 && turningLocations[2, 1] == -50 &&
                        turningLocations[3, 0] == 0 && turningLocations[3, 1] == -75)
                        {
                            if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                            {
                                isLocLegal(pb, ref border, 25, -50);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[1, 0] && pb.Location.Y == blocksLocations[1, 1])
                            {
                                isLocLegal(pb, ref border, 0, -25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                            {
                                isLocLegal(pb, ref border, 25, 0);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                            {
                                isLocLegal(pb, ref border, 50, 25);

                                if (border)
                                {
                                    break;
                                }
                            }
                        }

                        //blue tetromino

                        if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                        turningLocations[1, 0] == 25 && turningLocations[1, 1] == 0 &&
                        turningLocations[2, 0] == 50 && turningLocations[2, 1] == 0 &&
                        turningLocations[3, 0] == 0 && turningLocations[3, 1] == -25)
                        {
                            if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                            {
                                isLocLegal(pb, ref border, 25, 25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                            {
                                isLocLegal(pb, ref border, -25, 25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                            {
                                isLocLegal(pb, ref border, 50, 0);

                                if (border)
                                {
                                    break;
                                }
                            }
                        }
                        else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                        turningLocations[1, 0] == 0 && turningLocations[1, 1] == 25 &&
                        turningLocations[2, 0] == 0 && turningLocations[2, 1] == 50 &&
                        turningLocations[3, 0] == 25 && turningLocations[3, 1] == 0)
                        {
                            if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                            {
                                isLocLegal(pb, ref border, 25, 25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                            {
                                isLocLegal(pb, ref border, -25, -25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                            {
                                isLocLegal(pb, ref border, 0, 50);

                                if (border)
                                {
                                    break;
                                }
                            }
                        }
                        else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                        turningLocations[1, 0] == -25 && turningLocations[1, 1] == 0 &&
                        turningLocations[2, 0] == -50 && turningLocations[2, 1] == 0 &&
                        turningLocations[3, 0] == 0 && turningLocations[3, 1] == 25)
                        {
                            if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                            {
                                isLocLegal(pb, ref border, -25, 25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                            {
                                isLocLegal(pb, ref border, 25, -25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                            {
                                isLocLegal(pb, ref border, -50, 0);

                                if (border)
                                {
                                    break;
                                }
                            }
                        }
                        else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                        turningLocations[1, 0] == 0 && turningLocations[1, 1] == -25 &&
                        turningLocations[2, 0] == 0 && turningLocations[2, 1] == -50 &&
                        turningLocations[3, 0] == -25 && turningLocations[3, 1] == 0)
                        {
                            if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                            {
                                isLocLegal(pb, ref border, -25, -25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                            {
                                isLocLegal(pb, ref border, 25, 25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                            {
                                isLocLegal(pb, ref border, 0, -50);

                                if (border)
                                {
                                    break;
                                }
                            }
                        }

                        //purple tetromino

                        if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                        turningLocations[1, 0] == 25 && turningLocations[1, 1] == 0 &&
                        turningLocations[2, 0] == 50 && turningLocations[2, 1] == 0 &&
                        turningLocations[3, 0] == 25 && turningLocations[3, 1] == -25)
                        {
                            if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                            {
                                isLocLegal(pb, ref border, 25, -25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                            {
                                isLocLegal(pb, ref border, -25, 25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                            {
                                isLocLegal(pb, ref border, 25, 25);

                                if (border)
                                {
                                    break;
                                }
                            }
                        }
                        else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                        turningLocations[1, 0] == 0 && turningLocations[1, 1] == 25 &&
                        turningLocations[2, 0] == 0 && turningLocations[2, 1] == 50 &&
                        turningLocations[3, 0] == 25 && turningLocations[3, 1] == 25)
                        {
                            if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                            {
                                isLocLegal(pb, ref border, 25, 25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                            {
                                isLocLegal(pb, ref border, -25, -25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                            {
                                isLocLegal(pb, ref border, -25, 25);

                                if (border)
                                {
                                    break;
                                }
                            }
                        }
                        else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                        turningLocations[1, 0] == -25 && turningLocations[1, 1] == 0 &&
                        turningLocations[2, 0] == -50 && turningLocations[2, 1] == 0 &&
                        turningLocations[3, 0] == -25 && turningLocations[3, 1] == 25)
                        {
                            if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                            {
                                isLocLegal(pb, ref border, -25, -25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                            {
                                isLocLegal(pb, ref border, 25, -25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                            {
                                isLocLegal(pb, ref border, 25, -25);

                                if (border)
                                {
                                    break;
                                }
                            }
                        }
                        else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
                        turningLocations[1, 0] == 0 && turningLocations[1, 1] == -25 &&
                        turningLocations[2, 0] == 0 && turningLocations[2, 1] == -50 &&
                        turningLocations[3, 0] == -25 && turningLocations[3, 1] == -25)
                        {
                            if (pb.Location.X == blocksLocations[0, 0] && pb.Location.Y == blocksLocations[0, 1])
                            {
                                isLocLegal(pb, ref border, -25, -25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[2, 0] && pb.Location.Y == blocksLocations[2, 1])
                            {
                                isLocLegal(pb, ref border, 25, 25);

                                if (border)
                                {
                                    break;
                                }
                            }
                            else if (pb.Location.X == blocksLocations[3, 0] && pb.Location.Y == blocksLocations[3, 1])
                            {
                                isLocLegal(pb, ref border, 25, -25);

                                if (border)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            return border;
        }

        public void isLocLegal(PictureBox pb, ref bool border, int posX, int posY)
        {
            if(posX < 0)
            {
                if(pb.Left + posX <0)
                {
                    border = true;
                }
            }
            else if(posX > 0)
            {
                if(pb.Left + posX > 225) 
                {
                    border = true;
                }
            }

            if (posY > 0)
            {
                if (pb.Top + posY > 475)
                {
                    border = true;
                }
            }

            if(!border)
            {
                foreach (Control i in mainPanel.Controls)
                {
                    if (i.GetType() == typeof(PictureBox))
                    {
                        PictureBox pbx = i as PictureBox;

                        if (!pbx.Enabled && pbx.Visible && pb.Location.X == pbx.Location.X - posX && pb.Location.Y == pbx.Location.Y - posY)
                        {
                            border = true;
                        }
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
                            softDropTimer.Interval = dropTimerIntervals[level];
                        }
                        else
                        {
                            softDropTimer.Interval = 25;
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

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lineName_Click(object sender, EventArgs e)
        {

        }
    }
}