using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LabbOmFotboll.Models;

namespace LabbOmFotboll.Models
{
    public class DbModel : DbContext
    {
        public DbSet<Fotbollspelare> Fotbollspelares { get; set; }

        public DbSet<Lag> Lags { get; set; }

        public DbModel()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source = Fotboll.db");
        }


    }
}
