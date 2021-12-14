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
    public class LocationDataMoqTest
    {
        [TestMethod]
        public void TestSortLocationByParameterMethodAsc()
        {
            var provider = new Mock<IDataProvider>();
            provider.Setup(m => m.GetLocations())
                .Returns(new List<Location> {
                    new Location { name = "Beta", id = "5"},
                    new Location { name = "Alfa", id = "4"},
                    new Location { name = "Gama", id = "1"},
                    new Location { name = "Sesta", id = "3"},
                    new Location { name = "Zeta", id = "6"},
                    new Location { name = "Omega", id = "2"},
                    new Location { name = "Eta", id = "0"}
                });
            var repository = new Repository(provider.Object);
            var actualList = repository.SortLocationByParameter(0);
            var expectedList = actualList.OrderBy(order => order.name);
            Assert.IsTrue(expectedList.SequenceEqual(actualList));
        }

        [TestMethod]
        public void TestSortLocationByParameterMethodDesc()
        {
            var provider = new Mock<IDataProvider>();
            provider.Setup(m => m.GetLocations())
                .Returns(new List<Location> {
                    new Location { name = "Beta", id = "5"},
                    new Location { name = "Alfa", id = "4"},
                    new Location { name = "Gama", id = "1"},
                    new Location { name = "Sesta", id = "3"},
                    new Location { name = "Zeta", id = "6"},
                    new Location { name = "Omega", id = "2"},
                    new Location { name = "Eta", id = "0"}
                });
            var repository = new Repository(provider.Object);
            var actualList = repository.SortLocationByParameter(1);
            var expectedList = actualList.OrderByDescending(order => order.name);
            Assert.IsTrue(expectedList.SequenceEqual(actualList));
        }

        [TestMethod]
        public void TestSortLocationByParameterMethodNull()
        {
            var provider = new Mock<IDataProvider>();
            provider.Setup(m => m.GetLocations())
                .Returns(new List<Location> {
                    new Location { name = "Beta", id = "5"},
                    new Location { name = "Alfa", id = "4"},
                    new Location { name = "Gama", id = "1"},
                    new Location { name = "Sesta", id = "3"},
                    new Location { name = "Zeta", id = "6"},
                    new Location { name = "Omega", id = "2"},
                    new Location { name = "Eta", id = "0"}
                });
            var repository = new Repository(provider.Object);
            Assert.IsNull(repository.SortLocationByParameter(123));
            Assert.IsNull(repository.SortLocationByParameter(-1));
        }

        [TestMethod]
        public void TestMethodGetLocationNameByTag()
        {
            var provider = new Mock<IDataProvider>();
            provider.Setup(m => m.GetLocations())
                .Returns(new List<Location> {
                    new Location { name = "Litwa", id = "5"},
                    new Location { name = "Polska", id = "4"},
                    new Location { name = "Gama", id = "1"},
                    new Location { name = "Sesta", id = "3"},
                    new Location { name = "Zeta", id = "6"},
                    new Location { name = "Omega", id = "2"},
                    new Location { name = "Eta", id = "0"}
                });
            var repository = new Repository(provider.Object);
            Assert.AreEqual("Polska", repository.GetLocationNameByTag("4"));
            Assert.AreEqual("No country", repository.GetLocationNameByTag("40"));
        }
    }
}
