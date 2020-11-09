using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var f1 = new Formula("5 + 3*x ; x < 2");
            var dblHumpedCamel = new GroundTransport("Двугорбый верблюд",10,30,f1);
            var fastCamel = new GroundTransport("Верблюд быстроход",40,10,"5+1.5x;x<3");
            var kent = new GroundTransport("Кентавр",15,8,"2");
            var boots = new GroundTransport("Ботинки-вездеходы",6,60,"10-5x;x<2");
            
            var groundRacers = new List<GroundTransport>() {dblHumpedCamel, fastCamel, kent, boots};
            var groundRace = new GroundRace(1000, groundRacers);
            var groundWinner = groundRace.GetWinner();
            //groundWinner.Info();
            
            //Console.WriteLine("=================================");
            var f2 = new DistanceReducer("1000:0 ; 5000:3 ; 10000:10; 0:5;");
            var plane = new AirTransport("Самолёт", 10, f2);
            var stupa = new AirTransport("Ступа", 8, "0:6;");
            var broom = new AirTransport("Метла", 20, "/1000:1;");
            
            var airRace = new AirRace(5000, new List<AirTransport>() {plane, stupa, broom});
            var airWinner = airRace.GetWinner();
            //airWinner.Info();
            

        }
    }
}