using AppApi.Enities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AppApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }
        public DbSet<Influencer> Influencer { get; set; }
        public DbSet<YouTube> YouTube { get; set; }
        public DbSet<FaceBook> FaceBook { get; set; }
        public DbSet<Instagram> Instagram { get; set; }
        public DbSet<CountryMapData> Country { get; set; }
        public DbSet<CityMapData>   City { get; set; }

        public DbSet<Twitter>   Twitter { get; set; }


    }
}
