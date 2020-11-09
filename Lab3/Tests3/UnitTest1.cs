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
            var broom = new Broom();
            var plane = new Plane();
            var stupa = new Stupa();
            var airRacers = new List<AirTransport>() {broom, plane, stupa};
            var airRace =new AirRace(5000, airRacers);
            var airWinner = airRace.GetWinner();
            Assert.AreEqual(broom, airWinner);
        }

        [Test]
        public void Test2()
        {
            var dblHumpedCamell = new DblHumpedCamell();
            var fastCamell = new FastCamell();
            var boots = new Boots();
            var kent =new Kentavr();
            var groundRacers = new List<GroundTransport>() {boots, kent, fastCamell, dblHumpedCamell};
            var groundRace = new GroundRace(1000, groundRacers);
            var groundWinner = groundRace.GetWinner();
            Assert.AreEqual(fastCamell, groundWinner);
        }

        [Test]
        public void Test3()
        {
            var broom = new Broom();
            var plane = new Plane();
            var stupa = new Stupa();
            var dblHumpedCamell = new DblHumpedCamell();
            var fastCamell = new FastCamell();
            var boots = new Boots();
            var kent =new Kentavr();
            var racers = new List<Transport>() {boots, kent, fastCamell, dblHumpedCamell, broom, plane, stupa};
            var commonRace = new Race(10000, racers);
            var winner = commonRace.GetWinner();
            Assert.AreEqual(broom, winner);
        }

    }
}