using Geo.Extensions;
using Geo.Models;
using System;

namespace Geo
{
	public static class GeoHelper
	{
		private const int EARTH_RADIUS = 6371;

		public static double GetDistance(this Point origin, Point destination)
		{
			double originLat = origin.Lat.ToRad();
			double originLong = origin.Long.ToRad();
			double destLat = destination.Lat.ToRad();
			double destLong = destination.Long.ToRad();
			double deltaLat = destLat - originLat;
			double deltaLong = destLong - originLong;

			var a = Math.Pow(Math.Sin(deltaLat / 2), 2) + Math.Cos(originLat) * Math.Cos(destLat) * Math.Pow(Math.Sin(deltaLong / 2), 2);
			var c = 2 * Math.Asin(Math.Sqrt(a));
			return c * EARTH_RADIUS * 1000;
		}

		public static Point GetNextPoint(this Point origin, double bearing, double dist)
		{
			dist = dist / 1000 / EARTH_RADIUS;
			bearing = bearing.ToRad();

			double lat = Math.Asin(Math.Sin(origin.Lat.ToRad()) * Math.Cos(dist) + Math.Cos(origin.Lat.ToRad()) * Math.Sin(dist) * Math.Cos(bearing));
			double @long = origin.Long +
				Math.Atan2(Math.Sin(bearing) * Math.Sin(dist) * Math.Cos(origin.Lat.ToRad()), Math.Cos(dist) - Math.Sin(origin.Lat.ToRad()) * Math.Sin(lat)).ToDegree();

			Point result = new Point
			{
				Lat = lat.ToDegree(),
				Long = @long
			};
			return result;
		}

		public static double GetBearing(Point p1, Point p2)
		{
			var lat1 = p1.Lat.ToRad();
			var lat2 = p2.Lat.ToRad();
			var dLon = (p2.Long - p1.Long).ToRad();

			var y = Math.Sin(dLon) * Math.Cos(lat2);
			var x = Math.Cos(lat1) * Math.Sin(lat2) - Math.Sin(lat1) * Math.Cos(lat2) * Math.Cos(dLon);
			var brng = Math.Atan2(y, x);

			return (brng.ToDegree() + 360) % 360;
		}
	}
}
