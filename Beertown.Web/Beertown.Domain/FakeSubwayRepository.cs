using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beertown.Domain
{
    public class FakeSubwayRepository : ISubwayRepository
    {
        const int ID_СТАРОПРАМЕН = 1;
        const int ID_КРУШОВИЦЕ = 2;
        const int ID_КОЗЕЛ = 3;
        const int ID_ВЕЛЬВЕТ = 4;
        const int ID_БУДВАЙЗЕР = 5;
        const int ID_УРКВЕЛЛ = 6;
        const int ID_ГАМБРИНУС = 7;
        const int ID_ОЧАКОВСКОЕ = 8;
        const int ID_БАЛТИКА = 9;
        const int ID_ОХОТА = 10;
        const int ID_ЖИГУЛИ = 11;
        const int ID_БОЧКА = 12;
        const int ID_ХАМОВНИКИ = 13;
        const int ID_АФАНАСИЙ = 14;
        const int ID_ХУГАРДЕН = 15;
        const int ID_БАВАРИЯ = 16;
        const int ID_КАРЛСБЕРГ = 17;
        const int ID_ЛЕФФЕ = 18;
        const int ID_СТЕЛЛА = 19;
        const int ID_ХАЙНЕКЕН = 20;
        const int ID_ТУБОРГ = 21;
        const int ID_ЛОВЕНБРОЙ = 22;
        const int ID_ВАРШТАЙНЕР = 23;
        const int ID_ГЕССЕР = 24;
        const int ID_БЕКС = 25;
        const int ID_ПАУЛАНЕР = 26;
        const int ID_КРОМБАХЕР = 27;
        const int ID_АМСТЕЛ = 28;

        Line[] _Lines = new Line[]
        {
            new Line { LineId = 1, LineName = "Оранжевая", LineNameDativeCase = "Оранжевой", LineColorCode = "orange"},
            new Line { LineId = 2, LineName = "Фиолетовая", LineNameDativeCase = "Фиолетовой", LineColorCode = "violet"},
            new Line { LineId = 3, LineName = "Красная", LineNameDativeCase = "Красной", LineColorCode = "red"},
            new Line { LineId = 4, LineName = "Зеленая", LineNameDativeCase = "Зелёной", LineColorCode = "green"},
        };

        LineTarif[] _LineTarifs = new LineTarif[]
        {
            new LineTarif {LineId = 1, Cost = 2, ActualDate = DateTime.MinValue, ActualEndDate = DateTime.MaxValue},
            new LineTarif {LineId = 2, Cost = 1, ActualDate = DateTime.MinValue, ActualEndDate = DateTime.MaxValue},
            new LineTarif {LineId = 3, Cost = 4, ActualDate = DateTime.MinValue, ActualEndDate = DateTime.MaxValue},
            new LineTarif {LineId = 4, Cost = 3, ActualDate = DateTime.MinValue, ActualEndDate = DateTime.MaxValue},
        };

        Station[] _Stations = new Station[]
        {
            new Station {StationId = ID_СТАРОПРАМЕН, LineId = 1, StationName = "СТАРОПРАМЕН"},
            new Station {StationId = ID_КРУШОВИЦЕ, LineId = 1, StationName = "КРУШОВИЦЕ"},
            new Station {StationId = ID_КОЗЕЛ, LineId = 1, StationName = "КОЗЕЛ"},
            new Station {StationId = ID_ВЕЛЬВЕТ, LineId = 1, StationName = "ВЕЛЬВЕТ"},
            new Station {StationId = ID_БУДВАЙЗЕР, LineId = 1, StationName = "БУДВАЙЗЕР"},
            new Station {StationId = ID_УРКВЕЛЛ, LineId = 1, StationName = "УРКВЕЛЛ"},
            new Station {StationId = ID_ГАМБРИНУС, LineId = 1, StationName = "ГАМБРИНУС"},

            new Station {StationId = ID_ОЧАКОВСКОЕ, LineId = 2, StationName = "ОЧАКОВСКОЕ"},
            new Station {StationId = ID_БАЛТИКА, LineId = 2, StationName = "БАЛТИКА"},
            new Station {StationId = ID_ОХОТА, LineId = 2, StationName = "ОХОТА"},
            new Station {StationId = ID_ЖИГУЛИ, LineId = 2, StationName = "ЖИГУЛИ"},
            new Station {StationId = ID_БОЧКА, LineId = 2, StationName = "БОЧКА"},
            new Station {StationId = ID_ХАМОВНИКИ, LineId = 2, StationName = "ХАМОВНИКИ"},
            new Station {StationId = ID_АФАНАСИЙ, LineId = 2, StationName = "АФАНАСИЙ"},

            new Station {StationId = ID_ХУГАРДЕН, LineId = 3, StationName = "ХУГАРДЕН"},
            new Station {StationId = ID_БАВАРИЯ, LineId = 3, StationName = "БАВАРИЯ"},
            new Station {StationId = ID_КАРЛСБЕРГ, LineId = 3, StationName = "КАРЛСБЕРГ"},
            new Station {StationId = ID_ЛЕФФЕ, LineId = 3, StationName = "ЛЕФФЕ"},
            new Station {StationId = ID_СТЕЛЛА, LineId = 3, StationName = "СТЕЛЛА"},
            new Station {StationId = ID_ХАЙНЕКЕН, LineId = 3, StationName = "ХАЙНЕКЕН"},
            new Station {StationId = ID_ТУБОРГ, LineId = 3, StationName = "ТУБОРГ"},

            new Station {StationId = ID_ЛОВЕНБРОЙ, LineId = 4, StationName = "ЛОВЕНБРОЙ"},
            new Station {StationId = ID_ВАРШТАЙНЕР, LineId = 4, StationName = "ВАРШТАЙНЕР"},
            new Station {StationId = ID_ГЕССЕР, LineId = 4, StationName = "ГЕССЕР"},
            new Station {StationId = ID_БЕКС, LineId = 4, StationName = "БЕКС"},
            new Station {StationId = ID_ПАУЛАНЕР, LineId = 4, StationName = "ПАУЛАНЕР"},
            new Station {StationId = ID_КРОМБАХЕР, LineId = 4, StationName = "КРОМБАХЕР"},
            new Station {StationId = ID_АМСТЕЛ, LineId = 4, StationName = "АМСТЕЛ"},
        };

        ConnectingPassage[] _ConnectingPassages = new ConnectingPassage[]
        {
            new ConnectingPassage {ConnectingPassageId = 1, Station1Id = ID_ОХОТА, Station2Id = ID_ГЕССЕР, DurationMins = 4 },
            new ConnectingPassage {ConnectingPassageId = 2, Station1Id = ID_ЖИГУЛИ, Station2Id = ID_ЛЕФФЕ, DurationMins = 3 },
            new ConnectingPassage {ConnectingPassageId = 3, Station1Id = ID_БОЧКА, Station2Id = ID_ВЕЛЬВЕТ, DurationMins = 1 },
            new ConnectingPassage {ConnectingPassageId = 4, Station1Id = ID_БЕКС, Station2Id = ID_СТЕЛЛА, DurationMins = 5 },
            new ConnectingPassage {ConnectingPassageId = 5, Station1Id = ID_ПАУЛАНЕР, Station2Id = ID_БУДВАЙЗЕР, DurationMins = 3 },
            new ConnectingPassage {ConnectingPassageId = 6, Station1Id = ID_КАРЛСБЕРГ, Station2Id = ID_КОЗЕЛ, DurationMins = 4 },
        };

        Haul[] _Hauls = new Haul[]
        {
            new Haul { HaulId = 1, Station1Id=ID_ОЧАКОВСКОЕ, Station2Id=ID_БАЛТИКА, DurationMins=7 },
            new Haul { HaulId = 2, Station1Id=ID_БАЛТИКА, Station2Id=ID_ОХОТА, DurationMins=8 },
            new Haul { HaulId = 3, Station1Id=ID_ОХОТА, Station2Id=ID_ЖИГУЛИ, DurationMins=2 },
            new Haul { HaulId = 4, Station1Id=ID_ЖИГУЛИ, Station2Id=ID_БОЧКА, DurationMins=1 },
            new Haul { HaulId = 5, Station1Id=ID_БОЧКА, Station2Id=ID_ХАМОВНИКИ, DurationMins=3 },
            new Haul { HaulId = 6, Station1Id=ID_ХАМОВНИКИ, Station2Id=ID_АФАНАСИЙ, DurationMins=4 },
            new Haul { HaulId = 7, Station1Id=ID_ЛОВЕНБРОЙ, Station2Id=ID_ВАРШТАЙНЕР, DurationMins=5 },
            new Haul { HaulId = 8, Station1Id=ID_ВАРШТАЙНЕР, Station2Id=ID_ГЕССЕР, DurationMins=7 },
            new Haul { HaulId = 9, Station1Id=ID_ГЕССЕР, Station2Id=ID_БЕКС, DurationMins=2 },
            new Haul { HaulId = 10, Station1Id=ID_БЕКС, Station2Id=ID_ПАУЛАНЕР, DurationMins=4 },
            new Haul { HaulId = 11, Station1Id=ID_ПАУЛАНЕР, Station2Id=ID_КРОМБАХЕР, DurationMins=3 },
            new Haul { HaulId = 12, Station1Id=ID_КРОМБАХЕР, Station2Id=ID_АМСТЕЛ, DurationMins=9 },
            new Haul { HaulId = 13, Station1Id=ID_ХУГАРДЕН, Station2Id=ID_БАВАРИЯ, DurationMins=5 },
            new Haul { HaulId = 14, Station1Id=ID_БАВАРИЯ, Station2Id=ID_КАРЛСБЕРГ, DurationMins=4 },
            new Haul { HaulId = 15, Station1Id=ID_КАРЛСБЕРГ, Station2Id=ID_ЛЕФФЕ, DurationMins=5 },
            new Haul { HaulId = 16, Station1Id=ID_ЛЕФФЕ, Station2Id=ID_СТЕЛЛА, DurationMins=3 },
            new Haul { HaulId = 17, Station1Id=ID_СТЕЛЛА, Station2Id=ID_ХАЙНЕКЕН, DurationMins=5 },
            new Haul { HaulId = 18, Station1Id=ID_ХАЙНЕКЕН, Station2Id=ID_ТУБОРГ, DurationMins=8 },
            new Haul { HaulId = 19, Station1Id=ID_СТАРОПРАМЕН, Station2Id=ID_КРУШОВИЦЕ, DurationMins=7 },
            new Haul { HaulId = 20, Station1Id=ID_КРУШОВИЦЕ, Station2Id=ID_КОЗЕЛ, DurationMins=3 },
            new Haul { HaulId = 21, Station1Id=ID_КОЗЕЛ, Station2Id=ID_ВЕЛЬВЕТ, DurationMins=4 },
            new Haul { HaulId = 22, Station1Id=ID_ВЕЛЬВЕТ, Station2Id=ID_БУДВАЙЗЕР, DurationMins=3 },
            new Haul { HaulId = 23, Station1Id=ID_БУДВАЙЗЕР, Station2Id=ID_УРКВЕЛЛ, DurationMins=3 },
            new Haul { HaulId = 24, Station1Id=ID_УРКВЕЛЛ, Station2Id=ID_ГАМБРИНУС, DurationMins=8 },
        };

        public IEnumerable<Line> Lines { get { return _Lines; } }
        public IEnumerable<ConnectingPassage> ConnectingPassages { get { return _ConnectingPassages; } }
        public IEnumerable<LineTarif> LineTarifs { get { return _LineTarifs; } }
        public IEnumerable<Station> Stations { get { return _Stations; } }
        public IEnumerable<Haul> Hauls { get { return _Hauls; } }

        public FakeSubwayRepository()
        {
            InitLinks();
        }

        private void InitLinks()
        {
            // Инициализация коллекций и ссылок для эмуляции работы EntitiesFramework

            // Для _Lines
            foreach (var line in _Lines)
            {
                line.LineTarifs = new HashSet<LineTarif>();
                line.Stations = new HashSet<Station>();

                foreach (var t in _LineTarifs.Where(p => p.LineId == line.LineId))
                {
                    line.LineTarifs.Add(t);
                    t.Line = line;
                }

                foreach (var s in _Stations.Where(p => p.LineId == line.LineId))
                {
                    line.Stations.Add(s);
                    s.Line = line;
                }
            }

            // Для _LineTarifs - не нужно (заполняется в _Lines).

            // Для _Stations
            foreach (var station in _Stations)
            {
                station.ConnectingPassagesIn = new HashSet<ConnectingPassage>();
                station.ConnectingPassagesOut = new HashSet<ConnectingPassage>();
                station.HaulsIn = new HashSet<Haul>();
                station.HaulsOut = new HashSet<Haul>();

                foreach (var cp in _ConnectingPassages.Where(p => p.Station1Id == station.StationId))
                {
                    station.ConnectingPassagesOut.Add(cp);
                    cp.StationIn = station;
                }

                foreach (var cp in _ConnectingPassages.Where(p => p.Station2Id == station.StationId))
                {
                    station.ConnectingPassagesIn.Add(cp);
                    cp.StationOut = station;
                }

                foreach (var h in _Hauls.Where(p => p.Station1Id == station.StationId))
                {
                    station.HaulsOut.Add(h);
                    h.StationIn = station;
                }

                foreach (var h in _Hauls.Where(p => p.Station2Id == station.StationId))
                {
                    station.HaulsIn.Add(h);
                    h.StationOut = station;
                }
            }

            // Для _ConnectingPassages - не нужно (заполняется в _Stations)

            // Для _Hauls - не нужно (заполняется в _Stations)


        }
    }
}
