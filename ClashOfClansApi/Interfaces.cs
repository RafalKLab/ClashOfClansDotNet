using ClashOfClansApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashOfClansApi
{
    public interface IDataProvider
    {

        //Get possible clan location list .../locations
        IList<Location> GetLocations();

        //Get player rankings for a specific location
        IEnumerable<Ranking> GetRankingsForLocation(int location_id, int limit);

        //Get information about a single player by player tag
        Player GetPlayerDataByTag(string player_tag);

    }
}
