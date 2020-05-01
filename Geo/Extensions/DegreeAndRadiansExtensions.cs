using System;
using System.Collections.Generic;
using System.Text;

namespace Geo.Extensions
{
	public static class DegreeAndRadiansExtensions
	{
		public static double ToRad(this double degree)
		{
			return degree * Math.PI / 180;
		}

		public static double ToDegree(this double rad)
		{
			return rad * 180 / Math.PI;
		}
	}
}
