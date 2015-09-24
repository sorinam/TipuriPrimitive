using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TipuriPrimitive
{
	[TestClass]
	public class Columns_BuildArea
	{
		[TestMethod]
		public void Columns_CalculateBuildArea()
        {
            float xa = 0.000000f;
            float ya = 0.000000f;
            float xb = 0.000000f;
            float yb = 1.000000f;
            float xc = 1.000000f;
            float yc = 1.000000f;
            Columns_CalculateArea column = new Columns_CalculateArea();
            float result = 0;
            //the area of build is double of triangles's area
            result =column.Calculate_AreaofTriangle(xa,ya,xb,yb,xc,yc)*2;
            float expected_result = 1;
            Assert.AreEqual(expected_result,result);
		}
	}
}
