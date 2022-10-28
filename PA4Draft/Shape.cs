using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA4Draft
{
    enum ShapeType
    {
        Rectangle,
        Ellipse
    }
    class Shape { 
        internal ShapeType type { get;}
        internal List<int> locationAndSize { get;}
        internal Brush fillBrush { get; set; }
        internal Pen drawPen { get; set; }
        public Shape(ShapeType t, List<int> dims, Brush b, Pen p)
        {
            type = t;
            locationAndSize = dims;
            fillBrush = b;
            drawPen = p;
        }
        public override string ToString()
        {
            string output = "";
            switch (type)
            {
                case ShapeType.Ellipse:
                    output = "Ecllipse";
                    break;
                case ShapeType.Rectangle:
                    output = "Rectangle";
                    break;
            }
            output += (", pen=" + drawPen.Color+", "+drawPen.Width);
            if(fillBrush!=null)
                output += (", brush=" + fillBrush.GetType());
            output += ", loc/size: ";
            for (int i = 0; i < locationAndSize.Count; i += 2)
                output += "("+locationAndSize[i]+", "+ locationAndSize[i+1]+") ";
            return output;
        }
    }
}
