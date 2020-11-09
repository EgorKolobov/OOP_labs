using System;
using System.Collections.Generic;
using System.Linq;
namespace Lab3
{
    public class Race
    {
        private double Distance { get; set; }
        private readonly List<Transport> _racers;
        private Transport Winner {get; set; }

        public Race() {}

        public Race(double distance, List<Transport> racers)
        {
            Distance = distance;
            _racers = racers;
        }

        public Transport GetWinner()
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