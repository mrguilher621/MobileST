using MobileStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MobileStore.Contexts
{
    public class EFContext : DbContext
    {
        public EFContext() : base("BancoMobile")
        {
            Database.SetInitializer<EFContext>(new DropCreateDatabaseIfModelChanges<EFContext>());
        }

        public DbSet<Product> Product { get; set; }
    }
}