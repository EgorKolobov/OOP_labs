using System;
using System.Collections.Generic;
using System.Linq;
namespace Lab3
{
    public class GroundRace : Race<GroundTransport>
    {
        public GroundRace(double distance, List<GroundTransport> racers) : base(distance, racers) {}

    }
}