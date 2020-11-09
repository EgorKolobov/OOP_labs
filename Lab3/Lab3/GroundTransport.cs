using System;
using System.Collections.Generic;
using System.Linq;
namespace Lab3
{
    public class GroundTransport : Transport
    {
        private double RestInterval { get; set; } // час
        private int StopNum { get; set; }
        private Formula RestDuration{ get; set; } // час

        public GroundTransport(string name, double speed, double restInterval, Formula rest) : base(name, speed)
        {
            RestDuration = rest;
            RestInterval = restInterval;
            StopNum = 0;
        }
        
        public GroundTransport(string name, double speed, double restInterval, string rest) : base(name, speed)
        {
            RestDuration = new Formula(rest);
            RestInterval = restInterval;
            StopNum = 0;
        }

        public override double Run(double distance)
        {
            while (distance > 0)
            {
                distance -= Speed * RestInterval;
                Time += RestInterval;
                if (distance <= 0)
                    break;
                Time += RestDuration.Count(StopNum);
                StopNum++;
            }
            return Time;
        }
        
        /*public override void Info()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Speed: " + Speed);
            Console.WriteLine("RestInterval: " + RestInterval);
            Console.WriteLine("Time: " + Time);
        }*/
        
    }
}