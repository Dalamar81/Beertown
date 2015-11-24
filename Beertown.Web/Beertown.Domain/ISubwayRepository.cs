using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beertown.Domain
{
    public interface ISubwayRepository
    {
        IEnumerable<Line> Lines { get; }
        IEnumerable<LineTarif> LineTarifs { get; }
        IEnumerable<Station> Stations { get; }
        IEnumerable<ConnectingPassage> ConnectingPassages { get; }
        IEnumerable<Haul> Hauls { get; }
    }
}
