using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PA4Draft
{
    public partial class PickSolidBrush : Form
    {
        public PickSolidBrush()
        {
            InitializeComponent();
            pickedColor = SystemColors.ButtonFace;
        }

        private void Color_Click(object sender, EventArgs e)
        {
            DialogResult d = colorDialog1.ShowDialog();
            if (d == DialogResult.OK)
                pickedColor = colorDialog1.Color;
            pickedColor = Color.FromArgb((byte)opacity.Value,pickedColor.R,pickedColor.G,pickedColor.B);
            color.BackColor = pickedColor;
        }

        private void label1_Click(object sender, EventArgs e)
        {




        }

        private void Opacity_ValueChanged(object sender, EventArgs e)
        {
            pickedColor = Color.FromArgb((byte)opacity.Value, pickedColor.R, pickedColor.G, pickedColor.B);
            color.BackColor = pickedColor;
        }
    }
}
