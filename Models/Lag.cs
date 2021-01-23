using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabbOmFotboll.Models
{
    public class Lag
    {
        public int Id { get; set; }

        public string lagNamn { get; set; }

        public List<Fotbollspelare> Fotbollspelares { get; set; }

    }
}
