using System;

namespace Polyland
{
    public class Point2D 
    {
        /// <summary>
        // a point in 2D real(double) space
        /// </summary>
        public double X { get; private set; }
        public double Y { get; private set; }

        public Point2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Point2D(Point2D p)
        {
            X = p.X;
            Y = p.Y;
        }

        public double Distance(Point2D p)
        {
            double distance = 0;
            if (p != null)
            {
                double de = p.X - X;
                double dn = p.Y - Y;
                distance = Math.Sqrt(de * de + dn * dn);
            }
            return distance;

        }
    }
    }
