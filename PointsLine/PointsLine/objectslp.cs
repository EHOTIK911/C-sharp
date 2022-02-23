using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PointsLine
{
    class objectslp
    {
        public struct Point
        {
            public float X;
            public float Y;
            public Point(float X, float Y)
            {
                this.X = X;
                this.Y = Y;
            }
        }
        public struct Line
        {
            public float A, B, C;
            public Line(Point A1, Point B1)
            {
                if (A1.X != B1.X && A1.Y != B1.Y)
                {
                    A = B1.Y - A1.Y;
                    B = A1.X - B1.X;
                    C = A1.Y * B1.X - A1.X * B1.Y;
                }
                else
                {
                    if (A1.X == B1.X)
                    {
                        A = 1;
                        B = 0;
                        C = -A1.X;
                    }
                    else
                    {
                        A = 0;
                        B = 1;
                        C = -A1.Y;
                    }
                }
            }
        }                
    }
}
