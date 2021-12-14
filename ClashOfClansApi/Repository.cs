using ClashOfClansApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashOfClansApi
{
    //Windows forms -> IClashOfClans data (clans, players, countries, ...) -> IDataProvider (ims domenis is  api.clashofclans.com)
    //Testams IDataProviderFake (bus sukurtas netikras provideris)

    public class Repository
    {
        private readonly IDataProvider m_provider;
        public Repository(IDataProvider provider)
        {
            m_provider = provider;
        }


        public IEnumerable<Location> SortLocationByParameter(int param)  //0=ASC 1=DESC, 
        {
            var location = m_provider.GetLocations();
            if (param == 0)
            {
                List<Location> LocationOrder = location.OrderBy(order => order.name).ToList();
                foreach (var item in LocationOrder)
                {
                    Console.WriteLine(item.name);
                    Console.WriteLine(item.id);
                    Console.WriteLine("===============");
                }
                return LocationOrder;
            }
            else if (param == 1)
            {
                List<Location> LocationOrder = location.OrderByDescending(order => order.name).ToList();
                foreach (var item in LocationOrder)
                {
                    Console.WriteLine(item.name);
                    Console.WriteLine(item.id);
                    Console.WriteLine("===============");
                }
                return LocationOrder;
            }
            else
            {
                return null;
            }
        }

        public int PlayerBestTrophiesForAllTime(string player_tag)
        {
           var player = m_provider.GetPlayerDataByTag(player_tag);
           return player.bestTrophies + player.bestVersusTrophies;
        }

        public int PlayerAllAttackWins(string player_tag)
        {
            var player = m_provider.GetPlayerDataByTag(player_tag);
            return player.attackWins + player.versusBattleWins;
        }

        public Ranking HighestPlayerLevel(int country_id, int limit)
        {
            Ranking max = null;
            foreach (var r in m_provider.GetRankingsForLocation(country_id, limit))
            {
                if (max == null || max.expLevel <= r.expLevel)
                    max = r;
            }
            return max;
        }

        public int TrophiesCountOfTop(int country_id, int limit, int? count_limit)
        {
            if(count_limit.HasValue)
            {   
                return m_provider.GetRankingsForLocation(country_id, limit)
                    .Take(count_limit.Value).Sum(r => r.trophies);
            }
            else
            {
                return m_provider.GetRankingsForLocation(country_id, limit)
                .Sum(r => r.trophies);
            }
        }

        public int HowManyAttacksAndDefences(int country_id, int limit)
        {
            int AttackWin = m_provider.GetRankingsForLocation(country_id, limit)
                .Sum(a => a.attackWins);
            int DefenseWin = m_provider.GetRankingsForLocation(country_id, limit)
                .Sum(a => a.defenseWins);

            return AttackWin + DefenseWin;
        }

        public string GetLocationNameByTag(string country_tag)
        {
            var locations = m_provider.GetLocations();
            foreach(var location in locations)
            {
                if (location.id == country_tag)
                    return location.name;
            }
            return "No country";
        }
    }
}
