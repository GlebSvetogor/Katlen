﻿using Katlen.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katlen.DAL.EF
{
    public class KatlenContext : DbContext
    {
        public DbSet<Image> Images { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<ProductSeason> ProductSeasons { get; set; }

        public KatlenContext(DbContextOptions<KatlenContext> options) : base(options) 
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductSize>()
                .HasKey(productSize => new { productSize.ProductId, productSize.SizeId });
            modelBuilder.Entity<ProductSeason>()
                .HasKey(productSeason => new { productSeason.ProductId, productSeason.SeasonId });
        }
    }
}
