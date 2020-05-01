using Geo;
using Geo.Models;
using NUnit.Framework;
using PathReceiver.Abstraction;
using PathReceiver.Implementation.Adapters;
using System;

namespace Tests
{
	public class PathReceiverTests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void TestDirectionPointsGetting()
		{
			Point a = new Point
			{
				Lat = 52.457,
				Long = 31.026
			};
			Point b = new Point
			{
				Lat = 52.45584,
				Long = 30.971715
			};
			const string API_KEY = "adfcb201-baba-4dd4-99ec-a70a1a9ebd4b"

			IDirectionAdapter directionAdapter = new GraphHopperDirectionAdapter()
		}
	}
}
