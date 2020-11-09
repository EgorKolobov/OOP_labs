namespace Lab3
{
    public class Plane: AirTransport
    {
        public Plane(string name="Ступа", double speed=10) : base(name, speed) {}

        public override double DistanceReducer(double distance)
        {
            if (distance < 1000)
                return distance;
            else if (distance < 5000)
                return 0.97 * distance;
            
            else if (distance < 10000)
                return 0.9 * distance;
            else 
                return 0.95 * distance;
        }
        
    }
}