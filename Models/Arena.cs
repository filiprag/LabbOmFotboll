using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabbOmFotboll.Models
{
    public class Arena
    {
        public int Id { get; set; }
        public string arenaNamn { get; set; }
        public string Stad { get; set; }
        public string landsKod { get; set; }
        public int Kapacitet { get; set; }


    }
}
