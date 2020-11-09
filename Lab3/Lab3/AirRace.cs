using System;
using System.Collections.Generic;
using System.Linq;
namespace Lab3
{
    public class AirRace : Race<AirTransport>
    {
        public AirRace(double distance, List<AirTransport> racers) : base(distance, racers) {}
    }
}