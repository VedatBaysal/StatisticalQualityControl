namespace StatisticalQualityControl.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StatisticalQualityControlModel : DbContext
    {
        public StatisticalQualityControlModel()
            : base("name=StatisticalQualityControl")
        {
        }

        public virtual DbSet<Manufacture> Manufactures { get; set; }
        public virtual DbSet<ManufactureMistake> ManufactureMistakes { get; set; }
        public virtual DbSet<MaterialMeasuresOfProduct> MaterialMeasuresOfProducts { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Measurement> Measurements { get; set; }
        public virtual DbSet<MeasuresOfManufactureProduct> MeasuresOfManufactureProducts { get; set; }
        public virtual DbSet<MistakeOccurenceFactorDetail> MistakeOccurenceFactorDetails { get; set; }
        public virtual DbSet<MistakeOccurrenceFactor> MistakeOccurrenceFactors { get; set; }
        public virtual DbSet<Mistake> Mistakes { get; set; }
        public virtual DbSet<ProductColor> ProductColors { get; set; }
        public virtual DbSet<ProductMaterial> ProductMaterials { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Sector> Sectors { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<StaffLeaveDay> StaffLeaveDays { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manufacture>()
                .HasMany(e => e.ManufactureMistakes)
                .WithRequired(e => e.Manufacture)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MaterialMeasuresOfProduct>()
                .HasMany(e => e.MeasuresOfManufactureProducts)
                .WithRequired(e => e.MaterialMeasuresOfProduct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Material>()
                .HasMany(e => e.ProductMaterials)
                .WithRequired(e => e.Material)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Material>()
                .HasMany(e => e.Mistakes)
                .WithMany(e => e.Materials)
                .Map(m => m.ToTable("MaterialMistake").MapLeftKey("MaterialID").MapRightKey("MistakeID"));

            modelBuilder.Entity<Measurement>()
                .HasMany(e => e.MaterialMeasuresOfProducts)
                .WithRequired(e => e.Measurement)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MistakeOccurenceFactorDetail>()
                .HasMany(e => e.ManufactureMistakes)
                .WithRequired(e => e.MistakeOccurenceFactorDetail)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MistakeOccurrenceFactor>()
                .HasMany(e => e.MistakeOccurenceFactorDetails)
                .WithRequired(e => e.MistakeOccurrenceFactor)
                .HasForeignKey(e => e.MistakeOccurenceFactorID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Mistake>()
                .Property(e => e.MistakeName)
                .IsUnicode(false);

            modelBuilder.Entity<Mistake>()
                .HasMany(e => e.ManufactureMistakes)
                .WithRequired(e => e.Mistake)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductMaterial>()
                .HasMany(e => e.MaterialMeasuresOfProducts)
                .WithRequired(e => e.ProductMaterial)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasOptional(e => e.Manufacture)
                .WithRequired(e => e.Product);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductColors)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductMaterials)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Sectors)
                .WithMany(e => e.Products)
                .Map(m => m.ToTable("ProductSectors").MapLeftKey("ProductID").MapRightKey("SectorID"));

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Roles)
                .Map(m => m.ToTable("UserInRoles").MapLeftKey("RolesID").MapRightKey("UserID"));

            modelBuilder.Entity<Staff>()
                .Property(e => e.Salary)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Staff>()
                .HasMany(e => e.Manufactures)
                .WithRequired(e => e.Staff)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Staff>()
                .HasMany(e => e.StaffLeaveDays)
                .WithRequired(e => e.Staff)
                .WillCascadeOnDelete(false);
        }
    }
}
