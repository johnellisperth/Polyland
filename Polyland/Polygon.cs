using System;
using System.Collections.Generic;

namespace Polyland
{
    public class MyPolygon
    {
        /// <summary>
        /// @author John Ellis
        /// Polygon is a n-sided convex simple polygon 
        /// </summary>

        public List<Point2D> Vertices { get; private set; } //vertices of the polygon
        public List<MetallicRatio> MetallicRatios { get; private set; } //list of all metallic ratios for this polygon
        List<double> _distances; //list of straight line distance between the first vertices and all other vertices up to halfway

        /// <summary>
        /// constructor of polygon
        /// </summary>
        /// <param name="number">number of vertices in this polygon</param>
        public MyPolygon(int number)
        {
            Vertices = new List<Point2D>();
            MetallicRatios = new List<MetallicRatio>();
            _distances = new List<double>();

            if (number > 2)//only bother creating a polygon with 3 or more sides
            {
                int radius = 50;
                int halfnumbers = number / 2 + 1;//halfway point - only need distances upto halfway
                for (int n = 0; n < number; n++)
                {
                    //work out each vertice using basic math
                    double x = radius * Math.Cos(2 * Math.PI * n / number);
                    double y = radius * Math.Sin(2 * Math.PI * n / number);
                    Point2D newVertice = new Point2D(x, y);
                    Vertices.Add(newVertice);
                    //work out distance from vertice 0 to this vertice
                    if (n > 0 && n < halfnumbers)
                    {
                        double distance = Vertices[0].Distance(newVertice);
                        _distances.Add(distance);
                    }
                }
                
                double epsilon = 0.000000001;

                //work out ratios
                //k =1 = golden ratio; 2=silver ratio
                for (int k = 1; k < 3; k++)
                {
                    double metallicRatio = GetMetallicRatio(k);
                    for (int n = 0; n < _distances.Count; n++)
                    {
                        for (int m = n; m < _distances.Count; m++)
                        {
                            double ratio = _distances[n]> epsilon ? _distances[m] / _distances[n] : 0;
                            if (Math.Abs(ratio - metallicRatio) < epsilon)//Equals not good enough!
                            {
                                MetallicRatios.Add(new MetallicRatio()
                                {
                                    IndexForNumerator = m+1,
                                    IndexForDenominator = n+1,
                                    Ratio = ratio,
                                    RatioIndex = k
                                });
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Get the Metallic ratio 1= golden ratio , 2= silver, 3= bronze, etc
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private double GetMetallicRatio(int n)
        {
            return n != double.NaN && n > 0 ? (n + Math.Sqrt(4 + n * n))/2 : 0;
        }

        public override string ToString()
        {
            List<string> lines = new List<string>();
            lines.Add(string.Format("No Sides = {0} No Ratios = {1}",
                Vertices.Count, MetallicRatios.Count));
            foreach (var r in MetallicRatios)
            {
                lines.Add(r.ToString());
            }
            return string.Join(", ", lines.ToArray());
        }

    }
}
