using System;
using System.Collections.Generic;
using System.Linq;
namespace Lab3
{
    public class AirRace : Race
    {
        private double Distance { get; set; }
        private readonly List<AirTransport> _racers;
        private AirTransport Winner {get; set; }

        public AirRace(double distance, List<AirTransport> racers)
        {
            Distance = distance;
            _racers = racers;
        }
        
        public AirTransport GetWinner()
        {
            var time = Double.MaxValue;
            foreach (var racer in _racers)
            {
                var t = racer.Run(Distance);
                if (t >= time) continue;
                time = t;
                Winner = racer;
            }
            return Winner;
        }

    }
}