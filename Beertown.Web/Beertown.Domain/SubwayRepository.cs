using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beertown.Domain
{
    public class SubwayRepository : ISubwayRepository
    {
        SubwayDatabaseEntities _SubwayDatabaseEntities = new SubwayDatabaseEntities();

        public IEnumerable<ConnectingPassage> ConnectingPassages { get { return _SubwayDatabaseEntities.ConnectingPassages; } }
        public IEnumerable<Haul> Hauls { get { return _SubwayDatabaseEntities.Hauls; } }
        public IEnumerable<Line> Lines { get { return _SubwayDatabaseEntities.Lines; } }
        public IEnumerable<LineTarif> LineTarifs { get { return _SubwayDatabaseEntities.LineTarifs; } }
        public IEnumerable<Station> Stations { get { return _SubwayDatabaseEntities.Stations; } }
    }
}
