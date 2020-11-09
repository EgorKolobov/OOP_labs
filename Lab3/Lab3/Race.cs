using System;
using System.Collections.Generic;
using System.Linq;
namespace Lab3
{
    public class Race : Race<Transport>
    {
        public Race(double distance, List<Transport> racers) : base(distance,  racers) {}
    }
    
    public class Race<T> where T : Transport
    {
        private double Distance { get; set; }
        private readonly List<T> _racers;
        private T Winner {get; set; }

        public Race(double distance, List<T> racers)
        {
            Distance = distance;
            _racers = racers;
        }

        public T GetWinner()
        {
            var time = Double.MaxValue;
            foreach (var racer in _racers)
            {
                double t = racer.Run(Distance);
                if (t >= time) continue;
                time = t;
                Winner = racer;
            }
            return Winner;
        }
    }
}