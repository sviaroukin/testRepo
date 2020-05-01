using Geo;
using Geo.Models;
using NUnit.Framework;
using System;

namespace Tests
{
	public class GeoTests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void TestBearingCalculating()
		{
			Point a = new Point
			{
				Lat = 39.099912,
				Long = -94.581213
			};
			Point b = new Point
			{
				Lat = 38.627089,
				Long = -90.200203
			};

			Assert.AreEqual(96.51, Math.Round(GeoHelper.GetBearing(a, b), 2));

			Point a1 = new Point
			{
				Lat = 52.457182,
				Long = 31.026222
			};
			Point b1 = new Point
			{
				Lat = 52.457323,
				Long = 31.026065
			};

			double bearing = GeoHelper.GetBearing(a1, b1);
			Assert.AreEqual(325.84, Math.Round(bearing, 2));
		}

		[Test]
		public void TestNextPointAndDistanceCalculating()
		{
			Point a = new Point
			{
				Lat = 52.458393,
				Long = 31.025021
			};
			Point b = new Point
			{
				Lat = 52.459146,
				Long = 31.024851
			};

			double expectedDistance = 2;
			double bearing = GeoHelper.GetBearing(a, b);

			Point nextPoint = GeoHelper.GetNextPoint(a, bearing, expectedDistance);

			double distance = GeoHelper.GetDistance(a, nextPoint);

			Assert.AreEqual(expectedDistance, Math.Round(distance));
		}
	}
}