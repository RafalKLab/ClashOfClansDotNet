using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashOfClansApi.Models
{
   public class Ranking
    {
        public string tag { get; set; }
        public string name { get; set; }
        public int expLevel { get; set; }
        public int trophies { get; set; }
        public int attackWins { get; set; }
        public int defenseWins { get; set; }
        public int rank { get; set; }

        public override string ToString()
        {
            return $"{name}, {expLevel}, {tag}, {rank}";
        }
    }
}
