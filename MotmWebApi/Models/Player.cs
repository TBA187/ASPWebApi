using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MotmWebApi.Models
{
    public class Player
    {
        public int playerId { get; set; }
        public string playerName { get; set; }
        public int playerNr { get; set; }
        public string position { get; set; }
    }
}