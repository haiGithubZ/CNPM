using Microsoft.EntityFrameworkCore;
using SportSvc.Domain.Abstractions;
using SportSvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SportSvc.Infrastructure
{
    public class SportSvcDbContext : DbContext, ISportSvcDbContext
    {
        public SportSvcDbContext(DbContextOptions<SportSvcDbContext> options) : base(options)
        {

        }
        public DbSet<Country> Countrys { get; set; }
        public DbSet<Address> Addresss { get; set; }
        public DbSet<City> Citys { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<administrative_regions> administrative_regions { get; set; }
        public DbSet<administrative_units> administrative_units { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(true, cancellationToken);
        }
    }
}
