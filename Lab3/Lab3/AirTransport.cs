using System;
using System.Linq;
namespace Lab3
{
    public class AirTransport : Transport
    {
        private DistanceReducer DReducer { get; set; }

        public AirTransport(string name, double speed, DistanceReducer distanceReducer) : base(name,speed)
        {
            DReducer = distanceReducer;
        }
        
        public AirTransport(string name, double speed, string distanceReducer) : base(name,speed)
        {
            DReducer = new DistanceReducer(distanceReducer);
        }

        public override double Run(double distance)
        {
            var newDistance = DReducer.Count(distance);
            Time = newDistance / Speed;
            return Time;
        }
        
        /*public override void Info()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Speed: " + Speed);
            Console.WriteLine("Time: " + Time);
        }*/
    }
}