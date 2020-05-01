using Geo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImitationApi.ViewModels
{
	public class MarkerPathPointsRequest
	{
		public PolyLine Line { get; set; }
		public int Speed { get; set; }
		public int Delay { get; set; }
	}
}
