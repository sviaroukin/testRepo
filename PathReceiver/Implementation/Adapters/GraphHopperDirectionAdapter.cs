using Geo.Models;
using Newtonsoft.Json;
using PathReceiver.Abstraction;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace PathReceiver.Implementation.Adapters
{
	public class GraphHopperDirectionAdapter : IDirectionAdapter
	{
		private const string REQUEST_URL = "https://graphhopper.com/api/1/route?";
		private static HttpClient Client = new HttpClient();

		private readonly Dictionary<string, string> parameters = new Dictionary<string, string>
		{
			{ "key", "" },
			{ "points_encoded", "false" },
			{ "locale", "ru" },
			{ "vehicle", "car" }
		};

		public GraphHopperDirectionAdapter(string key)
		{
			parameters["key"] = key;
		}

		public IEnumerable<Point> GetDirection(Point start, Point finish)
		{
			string requestJsonResult = MakeRequest(start, finish);
			double[][] points = RetrievePointsFromResponse(requestJsonResult);

			List<Point> pointsList = new List<Point>();
			foreach (double[] point in points)
			{
				pointsList.Add(new Point(point[1], point[0]));
			}

			return pointsList;
		}

		private double[][] RetrievePointsFromResponse(string json)
		{
			var definitionOfObject = new { paths = new { coordinates = new double[][] { new double[] { } } } };
			var points = JsonConvert.DeserializeAnonymousType(json, definitionOfObject).paths.coordinates;

			return points;
		}

		private string MakeRequest(Point start, Point finish)
		{
			StringBuilder requestParamsBuilder = new StringBuilder(REQUEST_URL);
			requestParamsBuilder.Append($"point={start.Lat},{start.Long}&point={finish.Lat},{finish.Long}");
			foreach(var parameter in parameters)
			{
				requestParamsBuilder.Append($"&{parameters}{parameter.Key}={parameter.Value}");
			}

			var response = Client.GetAsync(requestParamsBuilder.ToString()).Result;
			response.EnsureSuccessStatusCode();

			return response.Content.ReadAsStringAsync().Result;
		}
	}
}
