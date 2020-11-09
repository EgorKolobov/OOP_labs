using System;
using System.Linq;
namespace Lab3
{
    public abstract class AirTransport : Transport
    {
        
        public AirTransport(string name, double speed) : base(name,speed) {}

        public override double Run(double distance)
        {
            var newdist = DistanceReducer(distance);
            return newdist / Speed;
        }

        public abstract double DistanceReducer(double distance);
        
        public override void Info()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Speed: " + Speed);
        }
    }
}