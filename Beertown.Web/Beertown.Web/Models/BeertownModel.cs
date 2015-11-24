using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Beertown.Web.Models
{
    public class BeertownModel
    {
        public class SubwayStation
        {
            public int StationId { get; set; }
            public string StationName { get; set; }
            public int LineId { get; set; }
            public string LineColorCode { get; set; }
        }

        public class PathNode
        {
            public SubwayStation Station { get; set; }
            public decimal Duration { get; set; }
        }

        public class CostDetail
        {
            public string CostItem { get; set; }
            public decimal Cost { get; set; }
            public string LineColorCode { get; set; }
        }

        [DisplayName("Начальная станция")]
        public int StartStationId { get; set; }

        [DisplayName("Конечная станция")]
        public int DestinationStationId { get; set; }

        public IEnumerable<SelectListItem> Stations { get; set; }

        public IList<PathNode> Path { get; set; }

        public IList<CostDetail> Cost { get; set; }
    }
}