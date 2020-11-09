using System.Collections.Generic;
using Lab3;
using NUnit.Framework;

namespace Tests3
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        
        [Test]
        public void Test1()
        {
            var f1 = new Formula("5 + 3*x ; x < 2");
            var dblHumpedCamel = new GroundTransport("Двугорбый верблюд",10,30,f1);
            var fastCamel = new GroundTransport("Верблюд быстроход",40,10,"5+1.5x;x<3");
            var kent = new GroundTransport("Кентавр",15,8,"2");
            var boots = new GroundTransport("Ботинки-вездеходы",6,60,"10-5x;x<2");
            
            var groundRacers = new List<GroundTransport>() {dblHumpedCamel, fastCamel, kent, boots};
            var groundRace = new GroundRace(1000, groundRacers);
            var groundWinner = groundRace.GetWinner();
            Assert.AreEqual(fastCamel,groundWinner);
        }

        [Test]
        public void Test2()
        {
            var f2 = new DistanceReducer("1000:0 ; 5000:3 ; 10000:10; 0:5;");
            var plane = new AirTransport("Самолёт", 10, f2);
            var stupa = new AirTransport("Ступа", 8, "0:6;");
            var broom = new AirTransport("Метла", 20, "/1000:1;");

            var airRace = new AirRace(5000, new List<AirTransport>() {plane, stupa, broom});
            var airWinner = airRace.GetWinner();
            Assert.AreEqual(broom,airWinner);
        }

        [Test]
        public void Test3()
        {
            var f1 = new Formula("5 + 3*x ; x < 2");
            var dblHumpedCamel = new GroundTransport("Двугорбый верблюд",10,30,f1);
            var fastCamel = new GroundTransport("Верблюд быстроход",40,10,"5+1.5x;x<3");
            var kent = new GroundTransport("Кентавр",15,8,"2");
            var boots = new GroundTransport("Ботинки-вездеходы",6,60,"10-5x;x<2");

            var f2 = new DistanceReducer("1000:0 ; 5000:3 ; 10000:10; 0:5;");
            var plane = new AirTransport("Самолёт", 10, f2);
            var stupa = new AirTransport("Ступа", 8, "0:6;");
            var broom = new AirTransport("Метла", 20, "/1000:1;");

            var commonRacers = new List<Transport>() {dblHumpedCamel, fastCamel, kent, boots,plane, stupa, broom};
            var commonRace = new Race(5000, commonRacers);
            var commonWinner = commonRace.GetWinner();
            Assert.AreEqual(fastCamel,commonWinner);
        }

        [Test]
        public void ExceptionTest1()
        {
            var ex = Assert.Throws<UserException>(() => new Formula("5 + 3*x ; x > 2"));
            Assert.That(ex.Message, Is.EqualTo("Invalid Formula. Can't parse Y."));
        }
        
        [Test]
        public void ExceptionTest2()
        {
            var ex = Assert.Throws<UserException>(() => new DistanceReducer("1000:0 ; 5000:3 ;"));
            Assert.That(ex.Message, Is.EqualTo("Invalid Distance Reducer. Distance Reducer should has 0 key."));
        }

    }
}