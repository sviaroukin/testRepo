using Geo.Models;
using System.Collections.Generic;

namespace PathReceiver.Abstraction
{
	public interface IDirectionAdapter
	{
		IEnumerable<Point> GetDirection(Point start, Point finish);
	}
}
