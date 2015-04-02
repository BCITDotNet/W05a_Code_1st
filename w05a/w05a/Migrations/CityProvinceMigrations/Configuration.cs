namespace w05a.Migrations.CityProvinceMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using w05a.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<w05a.Models.CityProvinceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\CityProvinceMigrations";
        }

        protected override void Seed(w05a.Models.CityProvinceContext context)
        {
            var provinces = new List<Province>
            {
                new Province { ProvCode = "p1", ProvName = "Prov1", }, 
                new Province { ProvCode = "p2", ProvName = "Prov2", }
            };
            provinces.ForEach(s => context.Provinces.Add(s));
            context.SaveChanges();



            var cities = new List<City>
            {
                new City { CityId = 1, CityName = "city1", Population = 10000, 
                    ProvinceId = context.Provinces.FirstOrDefault(s=> s.ProvCode == "p1").ProvinceId}, 
                new City { CityId = 2, CityName = "city2", Population = 110000,
                ProvinceId = context.Provinces.FirstOrDefault(s=> s.ProvCode == "p1").ProvinceId},
                new City { CityId = 3, CityName = "city3", Population = 25000 ,
              ProvinceId = context.Provinces.FirstOrDefault(s=> s.ProvCode == "p2").ProvinceId},
              new City { CityId = 4, CityName = "city4", Population = 25000 ,
              ProvinceId = context.Provinces.FirstOrDefault(s=> s.ProvCode == "p2").ProvinceId},
              new City { CityId = 5, CityName = "city5", Population = 25000 ,
              ProvinceId = context.Provinces.FirstOrDefault(s=> s.ProvCode == "p2").ProvinceId}
            };
            cities.ForEach(s => context.Cities.Add(s));
            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
