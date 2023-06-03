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
            }

            if(e.KeyCode == Keys.Space)
            {
                spaceDropTimer.Enabled = true;
            }
        }

        public void disableTetromino()
        {
            foreach(Control c in mainPanel.Controls) 
            {
                if(c.GetType() == typeof(PictureBox))
                {
                    PictureBox pb = c as PictureBox;

                    if(pb.Enabled)
                    {
                        pb.Enabled = false;
                    }
                }
            }

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

                    if(pb.Enabled)
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

                    if (pb.Enabled)
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

                    if (pb.Enabled)
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

                    if(pb.Enabled)
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

                        if (pb.Enabled)
                        {
                            foreach (Control i in mainPanel.Controls)
                            {
                                if (i.GetType() == typeof(PictureBox))
                                {
                                    PictureBox pbx = i as PictureBox;

                                    if (!pbx.Enabled && pb.Location.X == pbx.Location.X && pb.Location.Y == pbx.Location.Y - 25)
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

                    if (pb.Enabled)
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

                        if (pb.Enabled)
                        {
                            foreach (Control i in mainPanel.Controls)
                            {
                                if (i.GetType() == typeof(PictureBox))
                                {
                                    PictureBox pbx = i as PictureBox;

                                    if (!pbx.Enabled && pb.Location.X == pbx.Location.X - 25 && pb.Location.Y == pbx.Location.Y)
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

                    if (pb.Enabled)
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

                        if (pb.Enabled)
                        {
                            foreach (Control i in mainPanel.Controls)
                            {
                                if (i.GetType() == typeof(PictureBox))
                                {
                                    PictureBox pbx = i as PictureBox;

                                    if (!pbx.Enabled && pb.Location.X == pbx.Location.X + 25 && pb.Location.Y == pbx.Location.Y)
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
    }
}