using System.Collections.Generic;
using MyStore.web.Models;

namespace MyStore.web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyStore.web.DataAccess.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyStore.web.DataAccess.StoreContext context)
        {
            var categories = new List<PieCategory>
            {
                new PieCategory { Name = "Cheese cakes" },
                new PieCategory { Name = "Fruit" },
                new PieCategory { Name = "Seasonal" }
            };

            categories.ForEach(c => context.PieCategories.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();

            var pies = new List<Pie>
            {
                new Pie
                {
                    Name = "Cheese cake", Description = "Plain cheese cake. Plain pleasure.", Price = 12.95M,
                    PieCategoryID = categories.Single(c => c.Name == "Cheese cakes").ID
                },
                new Pie
                {
                    Name = "Blueberry cheese cake	", Description = "You'll love it!", Price = 17.95M,
                    PieCategoryID = categories.Single(c => c.Name == "Cheese cakes").ID
                },
                new Pie
                {
                    Name = "Strawberry Cheese cake", Description = "One of the best cheese cakes you'll ever find!", Price = 18.95M,
                    PieCategoryID = categories.Single(c => c.Name == "Cheese cakes").ID
                },
                new Pie
                {
                    Name = "Apple pie", Description = "Our famous apple pie", Price = 4.99M,
                    PieCategoryID = categories.Single(c => c.Name == "Fruit").ID
                },
                new Pie
                {
                    Name = "Cranberry pie", Description = "Christmas favorite", Price = 4.99M,
                    PieCategoryID = categories.Single(c => c.Name == "Fruit").ID
                },
                new Pie
                {
                    Name = "Cherry pie", Description = "Summer classic", Price = 4.99M,
                    PieCategoryID = categories.Single(c => c.Name == "Fruit").ID
                },
                new Pie
                {
                    Name = "Peach pie", Description = "Sweet as a peach", Price = 4.99M,
                    PieCategoryID = categories.Single(c => c.Name == "Fruit").ID
                },
                new Pie
                {
                    Name = "Rhubarb  pie", Description = "Amazing!", Price = 4.99M,
                    PieCategoryID = categories.Single(c => c.Name == "Fruit").ID
                },
                new Pie
                {
                    Name = "Strawberry pie", Description = "The one and only!", Price = 4.99M,
                    PieCategoryID = categories.Single(c => c.Name == "Fruit").ID
                },
                new Pie
                {
                    Name = "Pumpkin pie", Description = "Our Halloween fave", Price = 4.99M,
                    PieCategoryID = categories.Single(c => c.Name == "Seasonal").ID
                }
            };

            pies.ForEach(c => context.Pies.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();
        }
    }
}
