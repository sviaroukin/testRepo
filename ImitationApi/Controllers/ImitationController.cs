using Geo.Models;
using ImitationApi.Hubs;
using ImitationApi.ViewModels;
using Imitator.Implementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ImitationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImitationController : ControllerBase
    {
        private IHubContext<ImitationHub> hub;

        public ImitationController(IHubContext<ImitationHub> hub)
        {
            this.hub = hub;
        }

        [HttpPost]
        public IActionResult Post([FromBody]MarkerPathPointsRequest request)
        {
            //var timerManager = new TimerManager(() =>
            //{

            //}, 0, 200);

            var points = MoveImitator.GetPathPoints(request.Line, request.Speed, request.Delay);
            //var d1 = DateTime.Now;
            //foreach (var point in points)
            //{
            //    hub.Clients.All.SendAsync("pointsUpdate", new List<Point>() { point }.ToArray());
            //    Thread.CurrentThread.Join(1000);
            //}
            //var d2 = DateTime.Now;
            return Ok(new { latlngs = points.Select(point => new double[] { point.Lat, point.Long }) });
        }
    }
}