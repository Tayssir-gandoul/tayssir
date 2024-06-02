using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuickApp.Core.Models;
using QuickApp.Core.Models.Account;
using QuickApp.Core.Models.Shop;
using QuickApp.Core.Services.Account;
using System;

namespace QuickApp.Core.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private readonly IUserIdAccessor _userIdAccessor;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IUserIdAccessor userIdAccessor)
            : base(options)
        {
            _userIdAccessor = userIdAccessor ?? throw new ArgumentNullException(nameof(userIdAccessor));

            Compteurs = Set<Compteur>();
         
            Orders = Set<Order>();
            OrderDetails = Set<OrderDetail>();
            BillCalculations = Set<BillCalculationModel>();
        }

        public DbSet<BillCalculationModel> BillCalculations { get; set; }
        public DbSet<Compteur> Compteurs { get; set; }
  
 
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            const string priceDecimalType = "decimal(18,2)";
            const string tablePrefix = "App";

            builder.Entity<ApplicationUser>()
                .HasMany(u => u.Claims)
                .WithOne()
                .HasForeignKey(c => c.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ApplicationUser>()
                .HasMany(u => u.Roles)
                .WithOne()
                .HasForeignKey(r => r.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ApplicationRole>()
                .HasMany(r => r.Claims)
                .WithOne()
                .HasForeignKey(c => c.RoleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ApplicationRole>()
                .HasMany(r => r.Users)
                .WithOne()
                .HasForeignKey(r => r.RoleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Compteur>().Property(c => c.Reference).IsRequired().HasMaxLength(100);
            builder.Entity<Compteur>().HasIndex(c => c.Reference);
            builder.Entity<Compteur>().Property(c => c.NouveauIndex);
            builder.Entity<Compteur>().Property(c => c.AncienIndex);
            builder.Entity<Compteur>().Property(c => c.District).HasMaxLength(50);
            builder.Entity<Compteur>().Property(c => c.Adresse).HasMaxLength(50);
            builder.Entity<Compteur>().Property(c => c.DateInstallation);
            builder.Entity<Compteur>().ToTable($"{tablePrefix}{nameof(Compteures)}");

         

            builder.Entity<Order>().Property(o => o.Comments).HasMaxLength(500);
            builder.Entity<Order>().Property(p => p.Discount).HasColumnType(priceDecimalType);
            builder.Entity<Order>().ToTable($"{tablePrefix}{nameof(Orders)}");

            builder.Entity<OrderDetail>().Property(p => p.UnitPrice).HasColumnType(priceDecimalType);
            builder.Entity<OrderDetail>().Property(p => p.Discount).HasColumnType(priceDecimalType);
            builder.Entity<OrderDetail>().ToTable($"{tablePrefix}{nameof(OrderDetails)}");

            // Configuration pour BillCalculationModel
            builder.Entity<BillCalculationModel>(entity =>
            {
                entity.Property(e => e.PrixUnitaireJour).HasColumnType(priceDecimalType);
                entity.Property(e => e.PrixUnitaireNuit).HasColumnType(priceDecimalType);
                entity.Property(e => e.PrixUnitairePointe).HasColumnType(priceDecimalType);
                entity.Property(e => e.Bonification).HasColumnType(priceDecimalType);
                entity.Property(e => e.Penalite).HasColumnType(priceDecimalType);
                entity.Property(e => e.PrimePuissance).HasColumnType(priceDecimalType);
                entity.Property(e => e.LocationMateriel).HasColumnType(priceDecimalType);
                entity.Property(e => e.FraisIntervention).HasColumnType(priceDecimalType);
                entity.Property(e => e.FraisRelance).HasColumnType(priceDecimalType);
                entity.Property(e => e.FraisRetard).HasColumnType(priceDecimalType);
                entity.Property(e => e.TvaConsommation).HasColumnType(priceDecimalType);
                entity.Property(e => e.TvaRedevance).HasColumnType(priceDecimalType);
                entity.Property(e => e.ContributionRTT).HasColumnType(priceDecimalType);
                entity.Property(e => e.SurtaxeMunicipale).HasColumnType(priceDecimalType);
                entity.Property(e => e.ContributionGMG).HasColumnType(priceDecimalType);

                entity.HasOne(d => d.Compteur)
                    .WithMany(p => p.BillCalculations)
                    .HasForeignKey(d => d.CompteurId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private object Compteures()
        {
            throw new NotImplementedException();
        }

        public override int SaveChanges()
        {
            AddAuditInfo();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            AddAuditInfo();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddAuditInfo();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            AddAuditInfo();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void AddAuditInfo()
        {
            var currentUserId = _userIdAccessor.GetCurrentUserId();

            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IAuditableEntity &&
                           (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                var entity = (IAuditableEntity)entry.Entity;
                var now = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedDate = now;
                    entity.CreatedBy = currentUserId;
                }
                else
                {
                    base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                    base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                }

                entity.UpdatedDate = now;
                entity.UpdatedBy = currentUserId;
            }
        }
    }

}
