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
        private double Time { get; set; }

        public AirRace(double distance, List<AirTransport> racers)
        {
            Distance = distance;
            _racers = racers;
            Time = Double.MaxValue;
        }

        public override Transport GetWinner()
        {
            foreach (var racer in _racers)
            {
                var t = racer.Run(Distance);
                if (t >= Time) continue;
                Time = t;
                Winner = racer;
            }
            return Winner;
        }
        
    }
}