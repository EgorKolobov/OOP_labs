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
        private double Time { get; set; }

        public Race() {}

        public Race(double distance, List<Transport> racers)
        {
            Distance = distance;
            _racers = racers;
            Time = Double.MaxValue;
        }

        public virtual Transport GetWinner()
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