using System;
using System.Collections.Generic;
using System.Linq;
namespace Lab3
{
    public abstract class GroundTransport : Transport
    {
        private double RestInterval { get; set; } // час

        public GroundTransport(string name, double speed, double restInterval) : base(name, speed)
        {
            RestInterval = restInterval;
        }
        
         public override double Run(double distance)
        {
            double time = 0.0;
            var stopNum = 1;
            while (distance > 0)
            {
                distance -= Speed * RestInterval;
                time += RestInterval;
                if (distance <= 0)
                    break;
                time += RestDuration(stopNum);
                stopNum++;
            }
            return time;
        }

        public abstract double RestDuration(int n);
        
        public override void Info()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Speed: " + Speed);
            Console.WriteLine("RestInterval: " + RestInterval);
        }
        
    }
}