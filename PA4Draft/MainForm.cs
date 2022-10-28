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
    public partial class MainForm : Form
    {
        public enum MirrorStyle { 
            NoMirroring,
            XAxis,
            YAxis,
            XYAxis
        }
        public MainForm()
        {
            InitializeComponent();
            signature = null;
            tileDesign.Image = new Bitmap(tileDesign.Width, tileDesign.Height);
            shapes = new List<Shape>();
            mirrorStyle = MirrorStyle.NoMirroring;
        }

       

        private void AddSignature_Click(object sender, EventArgs e)
        {
            Signature signDialog = new Signature();
            DialogResult d = signDialog.ShowDialog();
            if (d == DialogResult.OK)
                signature = (Bitmap)signDialog.pictureBox1.Image;
        }

        private void ViewSignature_Click(object sender, EventArgs e)
        {
            if (signature == null)
                return;
            Form f = new Form();
            f.Text = "Your signature";
            f.Icon = new Icon(@"C:\Users\drbor\OneDrive\Desktop\Teaching\COP4226\icons\Office_-42_icon-icons.com_74001.ico");
            f.BackgroundImage = signature;
            f.MinimumSize = signature.Size;
            f.MaximumSize = signature.Size;
            f.Show();
            
        }

        private void saveSignatureAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (signature == null)
                return;
            DialogResult d = saveAsImage.ShowDialog();
            if (d == DialogResult.OK)
                signature.Save(saveAsImage.FileName);
        }

        private void RemoveSignature_Click(object sender, EventArgs e)
        {
            if (signature == null)
                return;
            signature = null;
            MessageBox.Show("Signature deleted successfully!");
        }

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void AddShapeClick(object sender, EventArgs e)
        {
            if (shapeType.SelectedIndex==0)
            {
                AddEllipse addShapeDialog = new AddEllipse();
                DialogResult d = addShapeDialog.ShowDialog();
                if (d == DialogResult.OK)
                {
                    List<int> locationAndSize = new List<int>() { addShapeDialog.returnedRectangle.X, addShapeDialog.returnedRectangle.Y, addShapeDialog.returnedRectangle.Width, addShapeDialog.returnedRectangle.Height };
                    shapes.Add(new Shape(ShapeType.Ellipse, locationAndSize, null, new Pen(addShapeDialog.drawingPenColor, addShapeDialog.drawingPenWidth)));
                }
            }
            else if (shapeType.SelectedIndex == 1)
            {
                AddRectangle addShapeDialog = new AddRectangle();
                DialogResult d = addShapeDialog.ShowDialog();
                if (d == DialogResult.OK)
                {
                    List<int> locationAndSize = new List<int>() { addShapeDialog.returnedRectangle.X, addShapeDialog.returnedRectangle.Y, addShapeDialog.returnedRectangle.Width, addShapeDialog.returnedRectangle.Height };
                    shapes.Add(new Shape(ShapeType.Rectangle, locationAndSize, null, new Pen(addShapeDialog.drawingPenColor, addShapeDialog.drawingPenWidth)));
                }
            }
            updateShapeList(shapes.Count-1);
            updateTileDesign();

        }

        private void updateTileDesign()
        {
            tileDesign.Image = new Bitmap(tileDesign.Width, tileDesign.Height);
            using (Graphics g = Graphics.FromImage(tileDesign.Image))
            {
                g.InterpolationMode = InterpolationMode.High;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                foreach (Shape s in shapes)
                    switch (s.type)
                    {
                        case ShapeType.Rectangle:
                        g.DrawRectangle(s.drawPen, new Rectangle(s.locationAndSize[0], s.locationAndSize[1], s.locationAndSize[2], s.locationAndSize[3]));
                        if(s.fillBrush != null)
                            g.FillRectangle(s.fillBrush, new Rectangle(s.locationAndSize[0], s.locationAndSize[1], s.locationAndSize[2], s.locationAndSize[3]));
                            break;
                        case ShapeType.Ellipse:
                            g.DrawEllipse(s.drawPen, new Rectangle(s.locationAndSize[0], s.locationAndSize[1], s.locationAndSize[2], s.locationAndSize[3]));
                            if (s.fillBrush != null)
                                g.FillEllipse(s.fillBrush, new Rectangle(s.locationAndSize[0], s.locationAndSize[1], s.locationAndSize[2], s.locationAndSize[3]));
                            break;
                    }
                tileDesign.Invalidate();
            }
        }

        private void ShapeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            deleteButton.Enabled = (shapeList.SelectedIndex >= 0);
            brushButtons.Enabled = (shapeList.SelectedIndex >= 0);
            up.Enabled = (shapeList.SelectedIndex > 0);
            down.Enabled = (shapeList.SelectedIndex >= 0 && shapeList.SelectedIndex < shapes.Count-1);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (shapeList.SelectedIndex < 0)
                return;
            shapes.RemoveAt(shapeList.SelectedIndex);
            updateTileDesign();
            updateShapeList(-1);
            
        }

        private void updateShapeList(int nextSelectedIndex)
        {
            shapeList.Items.Clear();
            foreach (Shape s in shapes)
                shapeList.Items.Add(s);
            shapeList.SelectedIndex = nextSelectedIndex;

        }

        private void SolidBrush_Click(object sender, EventArgs e)
        {
            if (shapeList.SelectedIndex < 0)
                return;
            PickSolidBrush p = new PickSolidBrush();
            DialogResult d = p.ShowDialog();
            if (d != DialogResult.OK)
                return;
            shapes[shapeList.SelectedIndex].fillBrush = new SolidBrush(p.pickedColor);
            updateTileDesign();
            updateShapeList(shapeList.SelectedIndex);
        }

        private void TextureBrush_Click(object sender, EventArgs e)
        {
            if (shapeList.SelectedIndex < 0)
                return;
            PickTextureBrush p = new PickTextureBrush();
            DialogResult d = p.ShowDialog();
            if (d != DialogResult.OK)
                return;
            Image fileImage = Image.FromFile(p.filepath);
            shapes[shapeList.SelectedIndex].fillBrush = new TextureBrush(fileImage,p.wrapmode);
            updateTileDesign();
            updateShapeList(shapeList.SelectedIndex);
        }

        private void HatchBrush_Click(object sender, EventArgs e)
        {
            if (shapeList.SelectedIndex < 0)
                return;
            PickHatchBrush p = new PickHatchBrush();
            DialogResult d = p.ShowDialog();
            if (d != DialogResult.OK)
                return;
            shapes[shapeList.SelectedIndex].fillBrush = new HatchBrush(p.hatchStyle, p.foregroundColor, p.backgroundColor);
            updateTileDesign();
            updateShapeList(shapeList.SelectedIndex);
        }

        private void preview_Click(object sender, EventArgs e)
        {
            Preview f = new Preview(tileDesign.Image, new Size((int)widthInput.Value, (int)heightInput.Value),(int)repsPerRow.Value,(int)repsPerColumn.Value,signature,mirrorStyle);
            f.ShowDialog();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Size tileSize = new Size();
            tileSize.Width = (int)widthInput.Value / (int)repsPerRow.Value;
            tileSize.Height = (int)heightInput.Value / (int)repsPerColumn.Value;
            Bitmap tile = new Bitmap(tileDesign.Image, tileSize);
            Bitmap image = new Bitmap((int)widthInput.Value, (int)heightInput.Value);
            Graphics g = Graphics.FromImage(image);
            g.InterpolationMode = InterpolationMode.High;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Brush b = new TextureBrush(tile);
            if (mirrorStyle == MirrorStyle.NoMirroring)
                ((TextureBrush)b).WrapMode = WrapMode.Tile;
            else if (mirrorStyle == MirrorStyle.XAxis)
                ((TextureBrush)b).WrapMode = WrapMode.TileFlipX;
            else if (mirrorStyle == MirrorStyle.YAxis)
                ((TextureBrush)b).WrapMode = WrapMode.TileFlipY;
            else if (mirrorStyle == MirrorStyle.XYAxis)
                ((TextureBrush)b).WrapMode = WrapMode.TileFlipXY;
            g.FillRectangle(b, new Rectangle(0,0, (int)widthInput.Value, (int)heightInput.Value));
            if (signature != null)
                g.DrawImage(new Bitmap(signature, 100, 50), new Point((int)widthInput.Value - 125, (int)heightInput.Value - 75));
            DialogResult d = saveAsImage.ShowDialog();
            if (d == DialogResult.OK)
                image.Save(saveAsImage.FileName);
        }

        private void Up_Click(object sender, EventArgs e)
        {
            int selected = shapeList.SelectedIndex;
            if (selected < 1)
                return;
            Shape s = shapes[selected];
            shapes.RemoveAt(selected);
            shapes.Insert(selected - 1, s);
            updateTileDesign();
            updateShapeList(selected-1);
        }

        private void Down_Click(object sender, EventArgs e)
        {
            int selected = shapeList.SelectedIndex;
            if (selected < 0 || selected == shapes.Count-1)
                return;
            Shape s = shapes[selected];
            shapes.RemoveAt(selected);
            shapes.Insert(selected + 1, s);
            updateTileDesign();
            updateShapeList(selected+1);
        }

        private void Default_Click(object sender, EventArgs e)
        {
            if (defaultMirroring.Checked == true)
                return;
            defaultMirroring.Checked = true;
            xAxisMirroring.Checked = false;
            yAxisMirroring.Checked = false;
            mirrorStyle = MirrorStyle.NoMirroring;
        }

        private void XAxis_Click(object sender, EventArgs e)
        {
            if (xAxisMirroring.Checked == true)
            {
                if (yAxisMirroring.Checked == true)
                {
                    xAxisMirroring.Checked = false;
                    mirrorStyle = MirrorStyle.YAxis;
                }
                else
                    return;
            }
            else
            {
                xAxisMirroring.Checked = true;
                defaultMirroring.Checked = false;
                mirrorStyle = yAxisMirroring.Checked? MirrorStyle.XYAxis: MirrorStyle.XAxis;
            }
        }
        private void YAxis_Click(object sender, EventArgs e)
        {
            if (yAxisMirroring.Checked == true)
            {
                if (xAxisMirroring.Checked == true)
                {
                    yAxisMirroring.Checked = false;
                    mirrorStyle = MirrorStyle.XAxis;
                }
                    
                else
                    return;
            }
            else
            {
                yAxisMirroring.Checked = true;
                defaultMirroring.Checked = false;
                mirrorStyle = xAxisMirroring.Checked ? MirrorStyle.XYAxis : MirrorStyle.YAxis;
            }
        }

        private void shapeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            addShapeButton.Enabled =shapeType.SelectedIndex>=0;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
