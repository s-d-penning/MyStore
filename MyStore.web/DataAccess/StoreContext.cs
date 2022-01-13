using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

using MyStore.web.Models;

namespace MyStore.web.DataAccess
{
    public class StoreContext : DbContext
    {
        public DbSet<Pie> Pies { get; set; }
        public DbSet<PieCategory> PieCategories { get; set; }
    }
}