using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polyland;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polyland.Tests
{
    [TestClass()]
    public class Point2DTests
    {
        [TestMethod()]
        public void Point2DTest()
        {
            Point2D pointA = new Point2D(10, 10);
            Point2D pointB = new Point2D(pointA);
            Assert.AreEqual(pointA.X, pointB.X);
            Assert.AreEqual(pointA.Y, pointB.Y);
        }

        [TestMethod()]
        public void DistanceTest()
        {
            Point2D pointA = new Point2D(0, 0);
            Point2D pointB = new Point2D(Math.Sqrt(2), Math.Sqrt(2));
            Assert.AreEqual(pointB.Distance(pointA), 2);

        }
    }
}