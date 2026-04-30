using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SimplePaint
{
    public partial class ColorPalette : Form
    {
        public delegate void ColorSelectedHandler(Color color);
        public event ColorSelectedHandler ColorSelected;

        public ColorPalette()
        {
            InitializeComponent();
            pictureBox1.MouseClick += PictureBox1_MouseClick;
        }

        private void PictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                using (Bitmap bmp = new Bitmap(pictureBox1.Image))
                {
                    if (e.X >= 0 && e.X < bmp.Width && e.Y >= 0 && e.Y < bmp.Height)
                    {
                        Color c = bmp.GetPixel(e.X, e.Y);
                        ColorSelected?.Invoke(c);
                    }
                }
            }
        }
    }
}
