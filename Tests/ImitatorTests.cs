using Geo.Models;
using Imitator.Implementation;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
	public class ImitatorTests
	{
		[SetUp]
		public void Setup()
		{

		}

		[Test]
		public void TestPathPointCalculation()
		{
			PolyLine line = new PolyLine()
			{
				LatLongs = new List<Point>()
				{
					new Point(52.45698, 31.026151),
					new Point(52.457182, 31.026222),
					new Point(52.457323, 31.026065),
					new Point(52.457658, 31.026157),
					new Point(52.457788, 31.026058),
					new Point(52.458121, 31.026172),
					new Point(52.458288, 31.02602),
					new Point(52.458355, 31.025487),
					new Point(52.458393, 31.025021),
					new Point(52.459146, 31.024851),
					new Point(52.45975, 31.024663),
					new Point(52.459725, 31.024484)
				}
			};

			var points = MoveImitator.GetPathPoints(line, 10, 200);

			Assert.Greater(points.Count(), line.Count);
		}
	}
}
