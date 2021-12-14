using ClashOfClansApi;
using ClashOfClansApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
{
    class FakeProvider : IDataProvider
    {
        List<Ranking> m_data;

        public FakeProvider(List<Ranking> data)
        {
            m_data = data;
        }

        IList<Location> IDataProvider.GetLocations()
        {
            throw new NotImplementedException();
        }

        Player IDataProvider.GetPlayerDataByTag(string player_tag)
        {

            throw new NotImplementedException();
        }

        IEnumerable<Ranking> IDataProvider.GetRankingsForLocation(int location_id, int limit)
        {
            return m_data;
        }
    }

    [TestClass]
    public class RankingDataUnitTest
    {
        [TestMethod]
        public void TestMethodTrophiesCountOfTop()
        {
            var data = new List<Ranking>
            {
               new Ranking { tag = "001", name = "test1", expLevel = 100, trophies = 1000, attackWins = 10, defenseWins = 1, rank = 1},
               new Ranking { tag = "001", name = "test1", expLevel = 100, trophies = 100, attackWins = 10, defenseWins = 1, rank = 1},
               new Ranking { tag = "001", name = "test1", expLevel = 100, trophies = 10, attackWins = 10, defenseWins = 1, rank = 1},
               new Ranking { tag = "001", name = "test1", expLevel = 100, trophies = 1, attackWins = 10, defenseWins = 1, rank = 1},
               new Ranking { tag = "001", name = "test1", expLevel = 100, trophies = 5, attackWins = 10, defenseWins = 1, rank = 1},
            };
            var provider = new FakeProvider(data);
            var repository = new Repository(provider);

            Assert.AreEqual(1100, repository.TrophiesCountOfTop(1,2,2));
            Assert.AreEqual(1000, repository.TrophiesCountOfTop(1,2,1));
            Assert.AreEqual(1116, repository.TrophiesCountOfTop(1,2, null));
            Assert.AreEqual(1116, repository.TrophiesCountOfTop(1, 2, 10));
            Assert.AreEqual(0, repository.TrophiesCountOfTop(1,2, 0));

        }

        [TestMethod]
        public void TestMethodHowManyAttacksAndDefences()
        {
            var data = new List<Ranking>
            {
               new Ranking { tag = "001", name = "test1", expLevel = 100, trophies = 1000, attackWins = 10, defenseWins = 1, rank = 1},
               new Ranking { tag = "001", name = "test1", expLevel = 100, trophies = 100, attackWins = 10, defenseWins = 1, rank = 1},
               new Ranking { tag = "001", name = "test1", expLevel = 100, trophies = 10, attackWins = 10, defenseWins = 1, rank = 1},
               new Ranking { tag = "001", name = "test1", expLevel = 100, trophies = 1, attackWins = 10, defenseWins = 1, rank = 1},
               new Ranking { tag = "001", name = "test1", expLevel = 100, trophies = 5, attackWins = 10, defenseWins = 1, rank = 1},
            };
            var provider = new FakeProvider(data);
            var repository = new Repository(provider);

            Assert.AreEqual(55, repository.HowManyAttacksAndDefences(1,2));

        }

        [TestMethod]
        public void TestMethodHighestPlayerLevel()
        {
            var data = new List<Ranking>
            {
               new Ranking { tag = "001", name = "test1", expLevel = 100, trophies = 1000, attackWins = 10, defenseWins = 1, rank = 1},
               new Ranking { tag = "002", name = "test2", expLevel = 200, trophies = 100, attackWins = 10, defenseWins = 1, rank = 1},
               new Ranking { tag = "003", name = "test3", expLevel = 300, trophies = 10, attackWins = 10, defenseWins = 1, rank = 1},
               new Ranking { tag = "004", name = "test4", expLevel = 850, trophies = 1, attackWins = 10, defenseWins = 1, rank = 1},
               new Ranking { tag = "005", name = "test5", expLevel = 500, trophies = 5, attackWins = 10, defenseWins = 1, rank = 1},
               new Ranking { tag = "006", name = "test6", expLevel = 850, trophies = 5, attackWins = 10, defenseWins = 1, rank = 1},
            };
            var provider = new FakeProvider(data);
            var repository = new Repository(provider);
            var max = repository.HighestPlayerLevel(1,2);
            Assert.AreEqual(data.Last(), repository.HighestPlayerLevel(1, 2));
            Assert.AreEqual("test6", max.name);
            
        }

    }
}
