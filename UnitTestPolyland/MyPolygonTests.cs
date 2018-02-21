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
    public class MyPolygonTests
    {
        [TestMethod()]
        public void MyPolygonTest()
        {
            //Arrange
            MyPolygon testPolygon = new MyPolygon(300);

            //Act
            int totalVertices = testPolygon.Vertices.Count;

            //Assert
            Assert.AreEqual(totalVertices, 300);
        }

        /*[TestMethod()]
        public void MyPolygonTest1()
        {
            MyPolygon myPolygon = new MyPolygon(10);
            MyPolygon testPolygon = new MyPolygon(myPolygon);
            Assert.AreEqual(testPolygon.Vertices.Count, myPolygon.Vertices.Count);
            Assert.AreEqual(testPolygon.MetallicRatios.Count, myPolygon.MetallicRatios.Count);
        }*/
    }
}