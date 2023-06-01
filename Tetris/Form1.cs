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
            nextBlock();
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
        }

        public void disableBlock()
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

            nextBlock();
        }

        private void softDropTimer_Tick(object sender, EventArgs e)
        {
            if(!borderDown()) 
            {
                moveDown();
            }
            else
            {
                disableBlock();
            }
        }

        public void createBlock(int x)
        {
            PictureBox blocks = new PictureBox();
            var block = new PictureBox();
            blocks = block;
            block.Size = new Size(25,25);
            block.BorderStyle = BorderStyle.FixedSingle;
            block.Enabled = true;
            block.Visible = true;
            if(x == 0)
            {
                block.BackColor = Color.Red;
            }
            else if(x == 1)
            {
                block.BackColor = Color.Orange;
            }
            else if (x == 2)
            {
                block.BackColor = Color.Yellow;
            }
            else if (x == 3)
            {
                block.BackColor = Color.Green;
            }
            else if (x == 4)
            {
                block.BackColor = Color.Cyan;
            }
            else if (x == 5)
            {
                block.BackColor = Color.Blue;
            }
            else if (x == 6)
            {
                block.BackColor = Color.Purple;
            }
            block.Location = new Point(100,-25);
            mainPanel.Controls.Add(block);
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

        
        public void nextBlock()
        {
            int random = rand.Next(0,7);

            createBlock(random);
        }
    }
}