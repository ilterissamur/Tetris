using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Tetris 
    {
        public bool borderDown()
        {
            bool border = false;

            foreach (Control c in mainPanel.Controls)
            {
                if (c.GetType() == typeof(PictureBox))
                {
                    PictureBox pb = c as PictureBox;

                    if (pb.Enabled && pb.Visible)
                    {
                        if (pb.Top + 25 > 475)
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

        public void isLocLegal(PictureBox pb, ref bool border, int posX, int posY)
        {
            if (posX < 0)
            {
                if (pb.Left + posX < 0)
                {
                    border = true;
                }
            }
            else if (posX > 0)
            {
                if (pb.Left + posX > 225)
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

            if (!border)
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
                        else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
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

                        else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
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

                        else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
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

                        else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
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

                        else if (turningLocations[0, 0] == 0 && turningLocations[0, 1] == 0 &&
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
    }
}
