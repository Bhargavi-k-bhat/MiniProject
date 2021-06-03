using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LimeLemon.Models
{
    public partial class MiniProject1Context : DbContext
    {
        public MiniProject1Context()
        {
        }

        public MiniProject1Context(DbContextOptions<MiniProject1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=DESKTOP-QVO4CN3;Database=MiniProject1;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ItemName)
                    .HasName("PK__Products__A3F6DE851D3A39A9");

                entity.Property(e => e.ItemName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("itemName");

                entity.Property(e => e.ItemPrice)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("itemPrice");

                entity.Property(e => e.ItemType)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("itemType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
