using SFCTest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace SFCTest.DAL
{
    public class SfcContext: DbContext
    {
        public SfcContext(): base("SFCTest")
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<RoutingGroup> RoutingGroups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}