using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beertown.Web
{
    /// <summary>
    /// Реализация алгоритма Дейкстры для поиска пути во взмешенном графе
    /// </summary>
    public class PathFinder
    {
        public class Edge
        {
            public int NextNodeId { get; set; }
            public decimal EdgeVeight { get; set; }
            public decimal Distance { get; set; }
        }

        Dictionary<int, ISet<Edge>> _Graph;
        Dictionary<int, Edge> _ClosestNodes;

        /// <summary>
        /// Ближаёшие к начальной вершине рёбра вершин. ClosedNodes[id] означает бижайшее ребро к начальной вершине для вершины с идентификатором id.
        /// </summary>
        public Dictionary<int, Edge> ClosedNodes { get { return _ClosestNodes; } }

        /// <summary>
        /// Инициализация и выполнение поиска
        /// </summary>
        /// <param name="graph">Граф в виде словаря &lt;идентификатор вершины, набор исходящих рёбер&gt;</param>
        /// <param name="startNode">Идентификатор начальной вершины</param>
        public PathFinder(Dictionary<int, ISet<Edge>> graph, int startNode)
        {
            _Graph = graph;
            _ClosestNodes = new Dictionary<int, Edge>();
            FindPath(startNode);
        }

        private void FindPath(int startNode)
        {
            List<int> unprocessedNodesIdxs = new List<int>();
            foreach(var n in _Graph.Keys)
            {
                _ClosestNodes[n] = new Edge { Distance = decimal.MaxValue };
                unprocessedNodesIdxs.Add(n);
            }
            _ClosestNodes[startNode].Distance = 0;

            while(unprocessedNodesIdxs.Count > 0)
            {
                var currentNodeIdx = unprocessedNodesIdxs.First(p => _ClosestNodes[p].Distance == unprocessedNodesIdxs.Min(pp => _ClosestNodes[pp].Distance));
                unprocessedNodesIdxs.Remove(currentNodeIdx);

                foreach(var outEdge in _Graph[currentNodeIdx])
                {
                    decimal currentDistance = _ClosestNodes[outEdge.NextNodeId].Distance;
                    decimal newDistance = Math.Min(currentDistance, _ClosestNodes[currentNodeIdx].Distance + outEdge.EdgeVeight);
                    if(newDistance < currentDistance)
                    {
                        _ClosestNodes[outEdge.NextNodeId].Distance = newDistance;
                        _ClosestNodes[outEdge.NextNodeId].NextNodeId = currentNodeIdx;
                    }
                }
            }
        }
    }
}