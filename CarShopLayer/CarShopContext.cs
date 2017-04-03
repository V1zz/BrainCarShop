namespace CarShopLayer
{
    using System.Data.Entity;
    using Models.Entities;

    public sealed class CarShopContext : DbContext
    {

        public CarShopContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
        
        public DbSet<Brand> CarBrands { get; set; }
        public DbSet<Model> CarModels { get; set; }
        public DbSet<Price> CarPrices { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<ModelType> ModelTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
                        .HasMany(e => e.Models)
                        .WithRequired(e => e.Brand)
                        .HasForeignKey(e => e.BrandId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Model>()
                        .HasMany(e => e.Cars)
                        .WithRequired(e => e.Model)
                        .HasForeignKey(e => e.ModelId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<ModelType>()
                        .HasMany(e => e.Models)
                        .WithRequired(e => e.ModelType)
                        .HasForeignKey(e => e.ModelTypeId);

            modelBuilder.Entity<Car>()
                        .HasMany(e => e.Prices)
                        .WithRequired(e => e.Car)
                        .HasForeignKey(e => e.CarId);

            modelBuilder.Entity<Price>()
                        .Property(e => e.Value)
                        .HasPrecision(8, 2);

            #region OLD

            /* modelBuilder.Entity<Brand>()
                            .HasMany(e => e.Models)
                            .WithRequired(e => e.Brand)
                            .HasForeignKey(e => e.BrandId)
                            .WillCascadeOnDelete(false);
            
                        modelBuilder.Entity<Model>()
                            .HasMany(e => e.Cars)
                            .WithRequired(e => e.Model)
                            .HasForeignKey(e => e.ModelId)
                            .WillCascadeOnDelete(false);
            
                        modelBuilder.Entity<Price>()
                            .Property(e => e.Value)
                            .HasPrecision(30, 2);
            
                        modelBuilder.Entity<Car>()
                            .HasMany(e => e.Prices)
                            .WithRequired(e => e.Car)
                            .WillCascadeOnDelete(false);
            
                        modelBuilder.Entity<Currency>()
                            .HasMany(e => e.)
                            .WithRequired(e => e.Currency)
                            .WillCascadeOnDelete(false);*/

            #endregion
        }
    }
}
