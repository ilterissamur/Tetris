using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Tetris
    {
        public void disableTetromino()
        {
            foreach (Control c in mainPanel.Controls)
            {
                if (c.GetType() == typeof(PictureBox))
                {
                    PictureBox pb = c as PictureBox;

                    if (pb.Enabled && pb.Visible)
                    {
                        pb.Enabled = false;
                        spaceDropTimer.Enabled = false;
                    }

                    if (!pb.Enabled && pb.Visible && pb.Location.Y <= 0)
                    {
                        gameOverLabel.Visible = true;
                        DropTimer.Enabled = false;
                        newGameLabel.Visible = true;
                        isGameOver = true;
                        break;
                    }
                }
            }

            isRowFull();
            nextTetromino();
        }

        public void createTetrominos(int x)
        {
            PictureBox[] tetrominos = new PictureBox[4];

            for (int i = 0; i < 4; i++)
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

                    if (i == 0)
                    {
                        tetromino.Location = new Point(75, -50);
                    }
                    else if (i == 1)
                    {
                        tetromino.Location = new Point(100, -50);
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

        public void showNextTeterminos(int x)
        {
            PictureBox[] tetrominos = new PictureBox[4];

            for (int i = 0; i < 4; i++)
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

                    if (i == 0)
                    {
                        tetromino.Location = new Point(60, 90);
                    }
                    else if (i == 1)
                    {
                        tetromino.Location = new Point(85, 90);
                    }
                    else if (i == 2)
                    {
                        tetromino.Location = new Point(85, 115);
                    }
                    else if (i == 3)
                    {
                        tetromino.Location = new Point(110, 115);
                    }
                }
                else if (x == 1)
                {
                    tetromino.BackColor = Color.Orange;

                    if (i == 0)
                    {
                        tetromino.Location = new Point(60, 115);
                    }
                    else if (i == 1)
                    {
                        tetromino.Location = new Point(85, 115);
                    }
                    else if (i == 2)
                    {
                        tetromino.Location = new Point(110, 115);
                    }
                    else if (i == 3)
                    {
                        tetromino.Location = new Point(110, 90);
                    }
                }
                else if (x == 2)
                {
                    tetromino.BackColor = Color.Yellow;

                    if (i == 0)
                    {
                        tetromino.Location = new Point(75, 90);
                    }
                    else if (i == 1)
                    {
                        tetromino.Location = new Point(100, 90);
                    }
                    else if (i == 2)
                    {
                        tetromino.Location = new Point(75, 115);
                    }
                    else if (i == 3)
                    {
                        tetromino.Location = new Point(100, 115);
                    }
                }
                else if (x == 3)
                {
                    tetromino.BackColor = Color.Chartreuse;

                    if (i == 0)
                    {
                        tetromino.Location = new Point(60, 115);
                    }
                    else if (i == 1)
                    {
                        tetromino.Location = new Point(85, 90);
                    }
                    else if (i == 2)
                    {
                        tetromino.Location = new Point(85, 115);
                    }
                    else if (i == 3)
                    {
                        tetromino.Location = new Point(110, 90);
                    }
                }
                else if (x == 4)
                {
                    tetromino.BackColor = Color.Cyan;

                    if (i == 0)
                    {
                        tetromino.Location = new Point(85, 50);
                    }
                    else if (i == 1)
                    {
                        tetromino.Location = new Point(85, 75);
                    }
                    else if (i == 2)
                    {
                        tetromino.Location = new Point(85, 100);
                    }
                    else if (i == 3)
                    {
                        tetromino.Location = new Point(85, 125);
                    }
                }
                else if (x == 5)
                {
                    tetromino.BackColor = Color.Blue;

                    if (i == 0)
                    {
                        tetromino.Location = new Point(65, 100);
                    }
                    else if (i == 1)
                    {
                        tetromino.Location = new Point(90, 100);
                    }
                    else if (i == 2)
                    {
                        tetromino.Location = new Point(115, 100);
                    }
                    else if (i == 3)
                    {
                        tetromino.Location = new Point(115, 75);
                    }
                }
                else if (x == 6)
                {
                    tetromino.BackColor = Color.Magenta;

                    if (i == 0)
                    {
                        tetromino.Location = new Point(65, 100);
                    }
                    else if (i == 1)
                    {
                        tetromino.Location = new Point(90, 100);
                    }
                    else if (i == 2)
                    {
                        tetromino.Location = new Point(90, 75);
                    }
                    else if (i == 3)
                    {
                        tetromino.Location = new Point(115, 100);
                    }
                }

                nextBlockPanel.Controls.Add(tetromino);
            }

        }

        public void nextTetromino()
        {
            nextBlockPanel.Controls.Clear();
            nextTet = rand.Next(0, 7);
            showNextTeterminos(nextTet);

            if (!gameStart)
            {
                gameStart = true;
                currentTet = rand.Next(0, 7);
            }

            createTetrominos(currentTet);
            currentTet = nextTet;
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
                        blocksLocations[counter, 0] = pb.Location.X;
                        blocksLocations[counter, 1] = pb.Location.Y;
                        counter++;
                    }
                }
            }

            int subX = blocksLocations[0, 0];
            int subY = blocksLocations[0, 1];

            for (int i = 0; i < 4; i++)
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
                            else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
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

                            else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
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

                            else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
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

                            else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
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

                            else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
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
    }
}