namespace Geo.Models
{
	public class Point
	{
		public double Lat { get; set; }
		public double Long { get; set; }

		public Point() { }

		public Point(double lat, double @long)
		{
			Lat = lat;
			Long = @long;
		}
	}
}
