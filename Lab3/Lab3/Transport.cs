using System.Linq;
namespace Lab3
{
    public abstract class Transport
    {
        protected string Name { get; private set; }
        protected double Speed { get; private set; } // км/час

        internal Transport(string name, double speed)
        {
            Name = name;
            Speed = speed;
        }

        public abstract double Run(double distance);

        public virtual void Info() { }
    }
}