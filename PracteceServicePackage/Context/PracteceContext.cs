using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace PracteceServicePackage.Context
{
    public partial class PracteceContext : DbContext
    {
        public PracteceContext()
        {
        }

        public PracteceContext(DbContextOptions<PracteceContext> options)
            : base(options)
        {
        }


        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Sale> Sale { get; set; }
        public virtual DbSet<SaleStatus> SaleStatus { get; set; }
        public virtual DbSet<Product> Product { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Apps\\customer-service\\PracteceServicePackage\\App_Data\\develop.mdf;Integrated Security=True");
        //    }
        //}
    }
}
