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
    public partial class PickTextureBrush : Form
    {

        public System.Drawing.Drawing2D.WrapMode wrapmode;
        public string filepath;

        public PickTextureBrush()
        {
            InitializeComponent();
        }

        private void uploadFile_Click(object sender, EventArgs e)
        {

            string fileDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            openFileDialog1.InitialDirectory = fileDirectory;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Filter = "All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            //openFileDialog1.FilterIndex = 1;
            //openFileDialog1.DefaultExt = "txt";
            //openFileDialog1.Filter = "txt files (*.txt)|*.txt";

            //saveFileDialog1.ShowDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName != "")
                {
                    filepath = openFileDialog1.FileName;

                    //openFileDialog1.

                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (radioButton1.Checked)
            {
                wrapmode = System.Drawing.Drawing2D.WrapMode.Tile;
            }
            else if (radioButton2.Checked) 
            {
                wrapmode = System.Drawing.Drawing2D.WrapMode.TileFlipX;
            }
            else if (radioButton3.Checked)
            {
                wrapmode = System.Drawing.Drawing2D.WrapMode.TileFlipY;
            }
            else if (radioButton4.Checked)
            {
                wrapmode = System.Drawing.Drawing2D.WrapMode.TileFlipXY;
            }
            else if (radioButton5.Checked)
            {
                wrapmode = System.Drawing.Drawing2D.WrapMode.Clamp;
            }

            if (openFileDialog1.FileName == "")
            {
                MessageBox.Show("No file found...Please try again");
                DialogResult = System.Windows.Forms.DialogResult.None;
                //DialogResult = System.Windows.Forms.DialogResult.None;
            }
            else
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
