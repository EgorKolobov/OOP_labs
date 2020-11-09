namespace Lab3
{
    public class Broom : AirTransport
    {
        public Broom(string name="Метла", double speed=20) : base(name, speed) {}

        public override double DistanceReducer(double distance)
        {
            var newdist = 0.0;
            for (int i = 1; i <= distance / 1000; i++)
                newdist += 1000 * ((100 - i) / 100);
            return newdist;
        }
        
        
    }
}