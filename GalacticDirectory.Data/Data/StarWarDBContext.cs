﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalacticDirectory.DAL.Models;

namespace GalacticDirectory.DAL.Data
{
    public class StarWarDBContext:DbContext
    {

        public DbSet<People> People { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }    
     

        public StarWarDBContext(DbContextOptions<StarWarDBContext> options):base(options)
        {
          // Database.Migrate();
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("StarWarCon");
        //    //base.OnConfiguring(optionsBuilder);
        //}
    }
}