using ClashOfClansApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClashOfClansApi
{
    public class DataProvider : IDataProvider
    {
        private RestClient m_client;
        public DataProvider()
        {
            m_client = new RestClient($"https://api.clashofclans.com/v1/");
            m_client.Timeout = -1;
            m_client.AddDefaultHeader("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6ImMwNzM2Njc0LWMxZDctNDMyYi04NGQ5LTcyMTIyZjY1Nzc5MCIsImlhdCI6MTYzOTA2ODMxMSwic3ViIjoiZGV2ZWxvcGVyLzY1MTI0Y2RkLTMzZDYtMTFjMy0wMTFlLWM4NzBmOTE0MTMwYyIsInNjb3BlcyI6WyJjbGFzaCJdLCJsaW1pdHMiOlt7InRpZXIiOiJkZXZlbG9wZXIvc2lsdmVyIiwidHlwZSI6InRocm90dGxpbmcifSx7ImNpZHJzIjpbIjUuMjAuMTU1Ljc2Il0sInR5cGUiOiJjbGllbnQifV19.uq0gUtlra8e-H26t7gYRi8Xs9SUqKuKrLCd14vhV9hd3bTC3rWIqwUdZR7iAeSKilgGeDHblqbbrzmHc9MapGg");
            //this token works only for one private ip
        }

        public IEnumerable<Ranking> GetRankingsForLocation(int location_id, int limit)
        {

             var request = new RestRequest($"locations/{location_id}/rankings/players?limit={limit}", Method.GET);
             IRestResponse response = m_client.Execute(request);
             if (response.StatusCode == HttpStatusCode.OK)
             {
                JObject o = JObject.Parse(response.Content);
                List<Ranking> list = JsonConvert.DeserializeObject<List<Ranking>>(o["items"].ToString());
                return list;
             }
            return null;      
        }
        public IList<Location> GetLocations()
        {
            try
            {
                var request = new RestRequest("locations?limit=261", Method.GET);
                IRestResponse response = m_client.Execute(request);
                JObject o = JObject.Parse(response.Content);
                List<Location> list = JsonConvert.DeserializeObject<List<Location>>(o["items"].ToString());
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }


        public Player GetPlayerDataByTag(string player_tag)
        {
            try
            {
                var request = new RestRequest($"players/%23{player_tag}", Method.GET);
                IRestResponse response = m_client.Execute(request);
                Player player = JsonConvert.DeserializeObject<Player>(response.Content);
                return player;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

    }
}
