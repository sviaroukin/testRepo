using System.Collections.Generic;
using System.Linq;

namespace Geo.Models
{
	public class PolyLine
	{
		public List<Point> LatLongs { get; set; }

		public Point this[int i]
		{
			get => LatLongs.ElementAt(i);
		}

		public int Count => LatLongs.Count;

		public Point GetPointAtDistance(double metres)
		{
			if (metres == 0)
			{
				return LatLongs.First();
			}
			if (metres < 0 || LatLongs.Count < 2)
			{
				return null;
			}

			double dist = 0;
			double oldDist = 0;
			int i = 1;
			while (i < LatLongs.Count && dist < metres)
			{
				oldDist = dist;
				dist += LatLongs.ElementAt(i - 1).GetDistance(LatLongs.ElementAt(i));
				i++;
			}

			if (dist < metres)
			{
				return null;
			}

			return GetApproximatePoint(i, dist, oldDist, metres);
		}

		private Point GetApproximatePoint(int i, double dist, double oldDist, double metres)
		{
			Point p1 = LatLongs.ElementAt(i - 2);
			Point p2 = LatLongs.ElementAt(i - 1);

			double m = (metres - oldDist) / (dist - oldDist);
			return new Point
			{
				Lat = p1.Lat + (p2.Lat - p1.Lat) * m,
				Long = p1.Long + (p2.Long - p1.Long) * m
			};
		}
	}
}
