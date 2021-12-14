using ClashOfClansApi;
using ClashOfClansApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Moq;

namespace MoqTest
{
    [TestClass]
    public class PlayerDataMoqTest
    {
        [TestMethod]
        public void TestPlayerDataCaching()
        {
            var data = new Player
            {
                tag = "abc123", 
                name = "testname", 
                townHallLevel = 10, 
                townHallWeaponLevel = 3, 
                expLevel = 200, 
                trophies = 4000, 
                bestTrophies = 4100, 
                warStars = 100,
                attackWins = 10,
                defenseWins = 12,
                builderHallLevel = 5,
                versusTrophies = 2000,
                bestVersusTrophies = 2100,
                versusBattleWins = 100,
                role = "admin",
                warPreference = "Out",
                donations = 250,
                donationsReceived = 300
            };

            var provider = new Mock<IDataProvider>();
            var cachingProvider = new CachingProvider(provider.Object);
            cachingProvider.GetPlayerDataByTag("TEST");
            provider.Verify(x => x.GetPlayerDataByTag("TEST"), Times.Once());

            cachingProvider.GetPlayerDataByTag("TEST");
            provider.Verify(x => x.GetPlayerDataByTag("TEST"), Times.Once());

            cachingProvider.GetPlayerDataByTag("FAKE");
            provider.Verify(x => x.GetPlayerDataByTag("FAKE"), Times.Once());

        }

        [TestMethod]
        public void TestPlayerTrophiesMethod()
        {
            var provider = new Mock<IDataProvider>();
            provider.Setup(m => m.GetPlayerDataByTag("test"))
                .Returns(new Player
                {
                    tag = "abc123",
                    name = "testname",
                    townHallLevel = 10,
                    townHallWeaponLevel = 3,
                    expLevel = 200,
                    trophies = 4000,
                    bestTrophies = 4100,
                    warStars = 100,
                    attackWins = 10,
                    defenseWins = 12,
                    builderHallLevel = 5,
                    versusTrophies = 2000,
                    bestVersusTrophies = 2100,
                    versusBattleWins = 100,
                    role = "admin",
                    warPreference = "Out",
                    donations = 250,
                    donationsReceived = 300
                });
            var repository = new Repository(provider.Object);
            Assert.AreEqual(6200, repository.PlayerBestTrophiesForAllTime("test"));
        }

        [TestMethod]
        public void TestPlayerAllAttackWinsMethod()
        {
            var provider = new Mock<IDataProvider>();
            provider.Setup(m => m.GetPlayerDataByTag("test"))
                .Returns(new Player
                {
                    tag = "abc123",
                    name = "testname",
                    townHallLevel = 10,
                    townHallWeaponLevel = 3,
                    expLevel = 200,
                    trophies = 4000,
                    bestTrophies = 4100,
                    warStars = 100,
                    attackWins = 10,
                    defenseWins = 12,
                    builderHallLevel = 5,
                    versusTrophies = 2000,
                    bestVersusTrophies = 2100,
                    versusBattleWins = 100,
                    role = "admin",
                    warPreference = "Out",
                    donations = 250,
                    donationsReceived = 300
                });
            var repository = new Repository(provider.Object);
            Assert.AreEqual(110, repository.PlayerAllAttackWins("test"));
        }
    }
}
