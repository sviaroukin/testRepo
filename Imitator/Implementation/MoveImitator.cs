using Geo;
using Geo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Imitator.Implementation
{
	public class MoveImitator
	{
		public static IEnumerable<Point> GetPathPoints(PolyLine line, double speed, int period)
		{
			double stepDistance = speed / 1000d * period;
			var points = new List<Point>();
			double currentRemainderOfDistance = 0d;
			Point current = null;
			Point previous = null;
			double bearing;

			for (int i = 1; i < line.Count; i++)
			{
				current = line[i];
				previous = line[i - 1];
				bearing = GeoHelper.GetBearing(previous, current);
				double lineDistance = previous.GetDistance(current);

				if (currentRemainderOfDistance > 0)
				{
					var firstPoint = GeoHelper.GetNextPoint(previous, bearing, stepDistance - currentRemainderOfDistance);
					points.Add(firstPoint);
					previous = firstPoint;
					lineDistance = lineDistance - (stepDistance - currentRemainderOfDistance);
				}

				while (lineDistance >= stepDistance)
				{
					var point = GeoHelper.GetNextPoint(previous, bearing, stepDistance);
					points.Add(point);
					lineDistance -= stepDistance;
					previous = point;
				}
				currentRemainderOfDistance = lineDistance;
			}

			if (currentRemainderOfDistance > 0)
			{
				points.Add(line.LatLongs.Last());
			}
			return points;
		}
	}
}
