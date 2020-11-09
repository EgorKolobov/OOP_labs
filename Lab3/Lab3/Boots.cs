namespace Lab3
{
    public class Boots: GroundTransport
    {
        public Boots(string name="Ботинки-скороходы", double speed = 6, double restInterval=60) : base(name, speed, restInterval) {}

        public override double RestDuration(int n)
        {
            return n == 1 ? 10 : 5;
        }
        

    }
}