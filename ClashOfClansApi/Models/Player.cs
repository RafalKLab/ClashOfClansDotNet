using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashOfClansApi.Models
{
    public class Player
    {
        public string tag { get; set; }
        public string name { get; set; }
        public int townHallLevel { get; set; }
        public int townHallWeaponLevel { get; set; }
        public int expLevel { get; set; }
        public int trophies { get; set; }
        public int bestTrophies { get; set; }
        public int warStars { get; set; }
        public int attackWins { get; set; }
        public int defenseWins { get; set; }
        public int builderHallLevel { get; set; }
        public int versusTrophies { get; set; }
        public int bestVersusTrophies { get; set; }
        public int versusBattleWins { get; set; }
        public string role { get; set; }
        public string warPreference { get; set; }
        public int donations { get; set; }
        public int donationsReceived { get; set; }
    }
}
