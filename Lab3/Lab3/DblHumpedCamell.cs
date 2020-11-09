namespace Lab3
{
    public class DblHumpedCamell: GroundTransport
    {
        public DblHumpedCamell(string name="Дв верблюд", double speed = 10, double restInterval=30) : base(name, speed, restInterval) {}

        public override double RestDuration(int n)
        {
            return n == 1 ? 5 : 8;
        }
        

    }
}