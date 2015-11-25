using Beertown.Domain;
using Beertown.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Beertown.Web.Controllers
{
    public class HomeController : Controller
    {
        ISubwayRepository _SubwayRepository;

        public HomeController(ISubwayRepository subwayRepository)
        {
            _SubwayRepository = subwayRepository;
        }

        public ActionResult Index()
        {
            var model = new BeertownModel();

            InitLists(model);

            return View(model);
        }

        private void InitLists(BeertownModel model)
        {
            List<SelectListGroup> groups = _SubwayRepository.Lines.Select(p => new SelectListGroup { Name = p.LineName }).ToList();
            model.Stations = _SubwayRepository.Stations.Select(p => new SelectListItem { Value = p.StationId.ToString(), Text = p.StationName, Group = groups.First(pp => pp.Name == p.Line.LineName) });
        }

        private static void AddEdge(Dictionary<int, ISet<PathFinder.Edge>> graph, int stationId, int nextStationId, decimal duration)
        {
            PathFinder.Edge edge = new PathFinder.Edge { NextNodeId = nextStationId, EdgeVeight = duration };
            graph[stationId].Add(edge);
        }

        protected Dictionary<int, ISet<PathFinder.Edge>> CreateGraph()
        {
            Dictionary<int, ISet<PathFinder.Edge>> graph = new Dictionary<int, ISet<PathFinder.Edge>>();

            foreach (var s in _SubwayRepository.Stations)
            {
                graph[s.StationId] = new HashSet<PathFinder.Edge>();
                foreach (var h in s.HaulsIn)
                {
                    AddEdge(graph, s.StationId, h.StationIn.StationId, h.DurationMins);
                }
                foreach (var h in s.HaulsOut)
                {
                    AddEdge(graph, s.StationId, h.StationOut.StationId, h.DurationMins);
                }
                foreach (var c in s.ConnectingPassagesIn)
                {
                    AddEdge(graph, s.StationId, c.StationIn.StationId, c.DurationMins);
                }
                foreach (var c in s.ConnectingPassagesOut)
                {
                    AddEdge(graph, s.StationId, c.StationOut.StationId, c.DurationMins);
                }
            }
            return graph;
        }

        [HttpPost]
        public ActionResult Index(BeertownModel model)
        {
            // Составляем граф по данным из БД:
            Dictionary<int, ISet<PathFinder.Edge>> graph = CreateGraph();

            PathFinder pathFinder = new PathFinder(graph, model.StartStationId);
            // TODO: Хорошо бы кэшировать объект pathFinder для одинаковых значений StartStationId

            // Заполняем путь для отображения.
            model.Path = new List<BeertownModel.PathNode>();
            var toStation = _SubwayRepository.Stations.First(p => p.StationId == model.DestinationStationId);
            while (toStation.StationId != model.StartStationId)
            {
                var closestNode = pathFinder.ClosedNodes[toStation.StationId];
                var fromStation = _SubwayRepository.Stations.First(p => p.StationId == closestNode.NextNodeId);
                model.Path.Insert(0, new BeertownModel.PathNode
                {
                    Station = new BeertownModel.SubwayStation { StationId = toStation.StationId, StationName = toStation.StationName, LineColorCode = toStation.Line.LineColorCode, LineId = toStation.LineId },
                    Duration = closestNode.Distance
                });
                toStation = fromStation;
            }
            model.Path.Insert(0, new BeertownModel.PathNode
            {
                Station = new BeertownModel.SubwayStation { StationId = toStation.StationId, StationName = toStation.StationName, LineColorCode = toStation.Line.LineColorCode, LineId = toStation.LineId },
                Duration = 0
            });

            model.Cost = new List<BeertownModel.CostDetail>();
            foreach (var t in _SubwayRepository.LineTarifs.Where(p => p.ActualDate <= DateTime.Now && p.ActualEndDate >= DateTime.Now && model.Path.Select(pp => pp.Station.LineId).Contains(p.LineId)))
            {
                model.Cost.Add(new BeertownModel.CostDetail { Cost = t.Cost, CostItem = "проезд по " + t.Line.LineNameDativeCase + " линии", LineColorCode = t.Line.LineColorCode });
            }

            InitLists(model);
            return View(model);
        }
    }
}