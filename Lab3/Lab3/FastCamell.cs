namespace Lab3
{
    public class FastCamell: GroundTransport
    {
        public FastCamell(string name="Верблюд", double speed = 40, double restInterval=10) : base(name, speed, restInterval) {}

        public override double RestDuration(int n)
        {
            switch (n)
            {
                case 1:
                    return 5;
                case 2:
                    return 6.5;
                default:
                    return 8;
            }
        }
        

    }
}