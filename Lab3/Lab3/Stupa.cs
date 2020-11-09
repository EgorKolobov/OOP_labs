namespace Lab3
{
    public class Stupa: AirTransport
    {
        public Stupa(string name="Ступа", double speed=8) : base(name, speed) {}

        public override double DistanceReducer(double distance)
        {
            var newdist = 0.94*distance;
            return newdist;
        }
        
        
    }
}