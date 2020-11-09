namespace Lab3
{
    public class Kentavr: GroundTransport
    {
        public Kentavr(string name="Кентавр", double speed = 15, double restInterval=8) : base(name, speed, restInterval) {}

        public override double RestDuration(int n)
        {
            return 2;
        }
        

    }
}