using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace LabbOmFotboll.Models
{
    public class Fotbollspelare
    {
        public int Id { get; set; }

        public string Namn { get; set; }

        public int Langd { get; set; }

        public int Vikt { get; set; }

        public int LagId { get; set; }

        public Lag Lag { get; set; }

    }
}

