using System.Linq;
namespace Lab3
{
    public class Transport
    {
        public string Name { get; set; }
        public double Speed { get; set; } // км/час
        public double Time { get; set; } // час

        internal Transport(string name, double speed)
        {
            Name = name;
            Speed = speed;
            Time = 0.0;
        }

        public Transport(Transport transport)
        {
            Name = transport.Name;
            Speed = transport.Speed;
            Time = transport.Time;
        }

        public virtual double Run(double distance)
        {
            return 0.0;
        }

        public virtual void Info() { }
    }
}