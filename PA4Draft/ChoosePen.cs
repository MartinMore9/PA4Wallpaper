using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PA4Draft
{
    public partial class ChoosePen : Form
    {
        public ChoosePen(Color initialColor, int initalWidth)
        {
            InitializeComponent();
            colorDialog1.Color = penColor = initialColor;
            trackBar1.Value = penWidth = initalWidth;
            MAXPENWIDTH = trackBar1.Maximum;
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp; //assign the picturebox.Image property to the bitmap created
            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
            {
                SolidBrush b = new SolidBrush(penColor);
                g.FillRectangle(b, 0, pictureBox1.Height / 2, 60, penWidth);
            }
        }

        private void color_Click(object sender, EventArgs e)
        {
            DialogResult d = colorDialog1.ShowDialog();
            if(d == DialogResult.OK)
            {
                penColor = colorDialog1.Color;
                using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                {
                    g.FillRectangle(SystemBrushes.Control, 0, 0, pictureBox1.Width, pictureBox1.Height);
                    SolidBrush b = new SolidBrush(penColor);
                    g.FillRectangle(b, 0, (pictureBox1.Height - penWidth) / 2, 60, penWidth);
                }
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
            {
                g.FillRectangle(SystemBrushes.Control,0,0,pictureBox1.Width,pictureBox1.Height);
                SolidBrush b = new SolidBrush(penColor);
                g.FillRectangle(b, 0, (pictureBox1.Height-penWidth)/2, 60, penWidth);
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            penWidth = trackBar1.Value;
            if (pictureBox1.Image == null)
            {
                Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                pictureBox1.Image = bmp;
            }
            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
            {
                g.FillRectangle(SystemBrushes.Control, 0, 0, pictureBox1.Width, pictureBox1.Height);
                SolidBrush b = new SolidBrush(penColor);
                g.FillRectangle(b, 0, (pictureBox1.Height - penWidth) / 2, 60, penWidth);
            }
            pictureBox1.Invalidate();

        }
    }
}
