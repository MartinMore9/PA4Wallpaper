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
    public partial class PickHatchBrush : Form
    {

        public Color foregroundColor;
        public Color backgroundColor;
        public System.Drawing.Drawing2D.HatchStyle hatchStyle;

        public PickHatchBrush()
        {
            InitializeComponent();
        }

        private void PickHatchBrush_Load(object sender, EventArgs e)
        {
            foreach (string styleName in Enum.GetNames(typeof(System.Drawing.Drawing2D.HatchStyle)))
            {
                comboBox1.Items.Add(styleName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (comboBox1.SelectedItem == null && foregroundColor != null && backgroundColor != null)
            {
                MessageBox.Show("No Hatch Style or Color selected...Please try again");
                DialogResult = System.Windows.Forms.DialogResult.None;
            }
            else
            {

                hatchStyle = (System.Drawing.Drawing2D.HatchStyle)Enum.Parse(typeof(System.Drawing.Drawing2D.HatchStyle),comboBox1.SelectedItem.ToString(), true);

                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult d = colorDialog1.ShowDialog();
            if (d == DialogResult.OK)
                foregroundColor = colorDialog1.Color;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult d = colorDialog2.ShowDialog();
            if (d == DialogResult.OK)
                backgroundColor = colorDialog2.Color;
        }
    }
}
