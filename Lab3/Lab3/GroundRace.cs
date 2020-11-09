using System;
using System.Collections.Generic;
using System.Linq;
namespace Lab3
{
    public class GroundRace : Race
    {
        private double Distance { get; set; }
        private readonly List<GroundTransport> _racers;
        private GroundTransport Winner {get; set; }
        private double Time { get; set; }

        public GroundRace(double distance, List<GroundTransport> racers)
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