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
    public partial class AddRectangle : Form
    {
        public AddRectangle()
        {
            InitializeComponent();
            drawingPenColor = Color.Black;
            drawingPenWidth = 2;
            returnedRectangle = new Rectangle(0, 0, 0, 0);
        }

        private void SelectedRectangle_MouseDown(object sender, MouseEventArgs e)
        {
            rectangleLocation = e.Location;//we assign the rectangleLocation to the current mouse position: e.Location ('e' is from the MouseEventArgs passed into the MouseDown event)
            isMouseDown = true;//we set to true because our mouse button is down (clicked)
            returnedRectangle = new Rectangle(0, 0, 0, 0);
            Bitmap bmp = new Bitmap(selectedRectangle.Width, selectedRectangle.Height);
            selectedRectangle.Image = bmp; //assign the picturebox.Image property to the bitmap created
        }

        private void SelectedRectangle_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            if (returnedRectangle.Width*returnedRectangle.Height != 0)
            {
                xLoc.Value = returnedRectangle.X;
                yLoc.Value = returnedRectangle.Y;
                width.Value = returnedRectangle.Width;
                height.Value = returnedRectangle.Height;
            }
        }

        private void SelectedRectangle_MouseMove(object sender, MouseEventArgs e)
        {
            Point c = new Point(Math.Min(selectedRectangle.Width - (int)Math.Ceiling((double)drawingPenWidth / 2), 
                                        Math.Max(e.Location.X, (int)Math.Ceiling((double)drawingPenWidth / 2))),
                                Math.Min(selectedRectangle.Height- (int)Math.Ceiling((double)drawingPenWidth /2), 
                                        Math.Max(e.Location.Y, (int)Math.Ceiling((double)drawingPenWidth / 2))));
            mouseLocation.Text = ( c.X + ", "+c.Y);
            if (isMouseDown == true)//check to see if the mouse button is down
            {
                mouseLocation.Text += (" | Width: " + Math.Abs(c.X - rectangleLocation.X) + ", Height: " + Math.Abs(c.Y - rectangleLocation.Y));
                if (rectangleLocation != null)//if our rectangle location is not null
                {
                    if (selectedRectangle.Image == null)//if no available bitmap exists on the selected Rectangle to draw on
                    {
                        Bitmap bmp = new Bitmap(selectedRectangle.Width, selectedRectangle.Height);
                        selectedRectangle.Image = bmp; 
                    }
                    using (Graphics g = Graphics.FromImage(selectedRectangle.Image))
                    {
                        Pen p = new Pen(drawingPenColor, drawingPenWidth);
                        Pen eraser = new Pen(SystemColors.ButtonHighlight, ChoosePen.MAXPENWIDTH);
                        if (returnedRectangle.Width * returnedRectangle.Height != 0)
                            g.DrawRectangle(eraser, returnedRectangle);//erase the previously drawn rectangle
                        Rectangle r = new Rectangle(Math.Min(rectangleLocation.X,c.X), Math.Min(rectangleLocation.Y, c.Y), Math.Abs(c.X - rectangleLocation.X), Math.Abs(c.Y - rectangleLocation.Y));
                        g.DrawRectangle(p, r);
                        returnedRectangle = r;

                    }
                    selectedRectangle.Invalidate();//refreshes the selected rectangle
                }
            }else if (returnedRectangle.Width * returnedRectangle.Height != 0)
                mouseLocation.Text += (" | Width: " + (returnedRectangle.Width) + ", Height: " + (returnedRectangle.Height));
        }

        private void ChooseAPenClick(object sender, EventArgs e)
        {
            ChoosePen choosePen = new ChoosePen(drawingPenColor, drawingPenWidth);
            DialogResult d = choosePen.ShowDialog();
            if (d == DialogResult.OK)
            {
                drawingPenColor = choosePen.penColor;
                drawingPenWidth = choosePen.penWidth;
            }
        }
        private void updateShape(int x, int y, int w, int h)
        {
            if (selectedRectangle.Image == null)//if no available bitmap exists on the selected Rectangle to draw on
            {
                Bitmap bmp = new Bitmap(selectedRectangle.Width, selectedRectangle.Height);
                selectedRectangle.Image = bmp;
            }
            using (Graphics g = Graphics.FromImage(selectedRectangle.Image))
            {
                Pen p = new Pen(drawingPenColor, drawingPenWidth);
                Pen eraser = new Pen(SystemColors.ButtonHighlight, ChoosePen.MAXPENWIDTH);
                if (returnedRectangle.Width * returnedRectangle.Height != 0)
                    g.DrawRectangle(eraser, returnedRectangle);//erase the previously drawn rectangle
                returnedRectangle = new Rectangle(x, y, w, h); 
                g.DrawRectangle(p, returnedRectangle);
            }
            selectedRectangle.Invalidate();
        }
        private void XLoc_ValueChanged(object sender, EventArgs e)
        {
            if (xLoc.Value + width.Value > selectedRectangle.Width - (int)Math.Ceiling((double)drawingPenWidth / 2))
                xLoc.Value = selectedRectangle.Width - width.Value - (int)Math.Ceiling((double)drawingPenWidth / 2);
            if (xLoc.Value < (int)Math.Ceiling((double)drawingPenWidth / 2))
                xLoc.Value = (int)Math.Ceiling((double)drawingPenWidth / 2);
            updateShape((int)xLoc.Value,returnedRectangle.Y,returnedRectangle.Width,returnedRectangle.Height);
        }

        private void YLoc_ValueChanged(object sender, EventArgs e)
        {
            if (yLoc.Value + height.Value > selectedRectangle.Height - (int)Math.Ceiling((double)drawingPenWidth / 2))
                yLoc.Value = selectedRectangle.Height - height.Value - (int)Math.Ceiling((double)drawingPenWidth / 2);
            if (yLoc.Value < (int)Math.Ceiling((double)drawingPenWidth / 2))
                yLoc.Value = (int)Math.Ceiling((double)drawingPenWidth / 2);
            updateShape(returnedRectangle.X, (int)yLoc.Value, returnedRectangle.Width, returnedRectangle.Height);
        }

        private void Width_ValueChanged(object sender, EventArgs e)
        {
            if (xLoc.Value + width.Value > selectedRectangle.Width - (int)Math.Ceiling((double)drawingPenWidth / 2))
                width.Value = selectedRectangle.Width - xLoc.Value - (int)Math.Ceiling((double)drawingPenWidth / 2);
            if (width.Value < drawingPenWidth )
                width.Value = drawingPenWidth;
            updateShape(returnedRectangle.X, returnedRectangle.Y, (int)width.Value, returnedRectangle.Height);
            if (returnedRectangle.Width * returnedRectangle.Height != 0)
                okButton.Enabled = true;
        }

        private void Height_ValuedChanged(object sender, EventArgs e)
        {
            if (yLoc.Value + height.Value > selectedRectangle.Height - (int)Math.Ceiling((double)drawingPenWidth / 2))
                height.Value = selectedRectangle.Height - yLoc.Value - (int)Math.Ceiling((double)drawingPenWidth / 2);
            if (height.Value < drawingPenWidth)
                height.Value = drawingPenWidth;
            updateShape(returnedRectangle.X, returnedRectangle.Y, returnedRectangle.Width, (int)height.Value);
            if (returnedRectangle.Width * returnedRectangle.Height != 0)
                okButton.Enabled = true;
        }
    }
}
