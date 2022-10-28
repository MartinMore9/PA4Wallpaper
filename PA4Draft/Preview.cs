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
using static PA4Draft.MainForm;

namespace PA4Draft
{
    public partial class Preview : Form
    {
        public Preview(Image tileDesign, Size s,int tilesPerRow,int tilesPerColumn,Image aSignature,MirrorStyle aMirrorStyle)
        {
            InitializeComponent();
            Size = MaximumSize=MinimumSize= s;
            Size tileSize = new Size();
            tileSize.Width = s.Width / tilesPerRow;
            tileSize.Height = s.Height / tilesPerColumn;
            tile = new Bitmap(tileDesign, tileSize);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            signature = aSignature;
            mirrorStyle = aMirrorStyle;

        }

        private void Preview_Paint(object sender, PaintEventArgs e)
        {
            if (picture.Image == null)
                picture.Image = new Bitmap(picture.Width, picture.Height);
            Graphics g = Graphics.FromImage(picture.Image);
            Brush b = new TextureBrush(tile);
            if (mirrorStyle == MirrorStyle.NoMirroring)
                ((TextureBrush)b).WrapMode = WrapMode.Tile;
            else if (mirrorStyle == MirrorStyle.XAxis)
                ((TextureBrush)b).WrapMode = WrapMode.TileFlipX;
            else if (mirrorStyle == MirrorStyle.YAxis)
                ((TextureBrush)b).WrapMode = WrapMode.TileFlipY;
            else if (mirrorStyle == MirrorStyle.XYAxis)
                ((TextureBrush)b).WrapMode = WrapMode.TileFlipXY;
            g.FillRectangle(b, this.ClientRectangle);
            if (signature != null)
                g.DrawImage(new Bitmap(signature, 100, 50), new Point(this.Size.Width - 125 , this.Size.Height - 75));
        }
    }
}
