using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DrinkShop.core.Models.Db
{
    public partial class drinkShopContext : DbContext
    {
        public drinkShopContext()
        {
        }

        public drinkShopContext(DbContextOptions<drinkShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ice> Ice { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<OrderItems> OrderItems { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Size> Size { get; set; }
        public virtual DbSet<Sweetness> Sweetness { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ice>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Modified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_520_ci");

                entity.Property(e => e.Remarks)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_520_ci");
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AddPrice).HasColumnType("int(11)");

                entity.Property(e => e.BasePrice).HasColumnType("int(11)");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Modified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_520_ci");

                entity.Property(e => e.Remarks)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_520_ci");
            });

            modelBuilder.Entity<OrderItems>(entity =>
            {
                entity.HasIndex(e => e.IdIce)
                    .HasName("ID_Ice");

                entity.HasIndex(e => e.IdItem)
                    .HasName("ID_Item");

                entity.HasIndex(e => e.IdOrder)
                    .HasName("ID_Order");

                entity.HasIndex(e => e.IdSize)
                    .HasName("ID_Size");

                entity.HasIndex(e => e.IdSweetness)
                    .HasName("ID_Sweetness");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Count).HasColumnType("int(11)");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.IdIce)
                    .HasColumnName("ID_Ice")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdItem)
                    .HasColumnName("ID_Item")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdOrder)
                    .HasColumnName("ID_Order")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdSize)
                    .HasColumnName("ID_Size")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdSweetness)
                    .HasColumnName("ID_Sweetness")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Price).HasColumnType("int(11)");

                entity.Property(e => e.Modified).HasColumnType("datetime");

                entity.Property(e => e.Remarks)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_520_ci");

                entity.HasOne(d => d.IdIceNavigation)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.IdIce)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orderitems_ibfk_1");

                entity.HasOne(d => d.IdItemNavigation)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.IdItem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orderitems_ibfk_2");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.IdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orderitems_ibfk_3");

                entity.HasOne(d => d.IdSizeNavigation)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.IdSize)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orderitems_ibfk_4");

                entity.HasOne(d => d.IdSweetnessNavigation)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.IdSweetness)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orderitems_ibfk_5");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasColumnName("ClientID")
                    .HasColumnType("varchar(250)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_520_ci");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Modified).HasColumnType("datetime");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_520_ci");

                entity.Property(e => e.Price).HasColumnType("int(11)");

                entity.Property(e => e.Remarks)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_520_ci");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Modified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_520_ci");

                entity.Property(e => e.Remarks)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_520_ci");
            });

            modelBuilder.Entity<Sweetness>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Modified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_520_ci");

                entity.Property(e => e.Remarks)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_520_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        private void AddAuitInfo()
        {
            var entries = ChangeTracker.Entries()
                .Where(x => x.Entity is ITimeLogger && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((ITimeLogger)entry.Entity).Created = DateTime.UtcNow;
                }
                ((ITimeLogger)entry.Entity).Modified = DateTime.UtcNow;
            }
        }

        public override int SaveChanges()
        {
            AddAuitInfo();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            AddAuitInfo();
            return await base.SaveChangesAsync();
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
