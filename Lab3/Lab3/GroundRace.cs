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

        public GroundRace(double distance, List<GroundTransport> racers)
        {
            Distance = distance;
            _racers = racers;
        }
        
        public GroundTransport GetWinner()
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