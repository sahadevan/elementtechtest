using Microsoft.EntityFrameworkCore;

namespace ElementMaterialsTechnology.Models;

public partial class TechTestContext : DbContext
{
    public TechTestContext()
    {
    }

    public TechTestContext(DbContextOptions<TechTestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Quotation> Quotations { get; set; }

    public virtual DbSet<QuotationDetail> QuotationDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-MCEOISR\\SQLEXPRESS;Database=TechTest;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Customer");

            entity.Property(e => e.Address)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Address2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Address3)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Address4)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CompanyId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CompanyID");
            entity.Property(e => e.Country)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");
            entity.Property(e => e.CreatedUser)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CustomerId)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("smalldatetime");
            entity.Property(e => e.ModifiedUser)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PayTerms)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Telephone)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Website)
                .HasMaxLength(80)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CompanyId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CompanyID");
            entity.Property(e => e.DepartmentId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("DepartmentID");
            entity.Property(e => e.DivId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("DivID");
            entity.Property(e => e.GroupId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("GroupID");
            entity.Property(e => e.GroupName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("numeric(18, 3)");
            entity.Property(e => e.ProdCode)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Prod_Code");
            entity.Property(e => e.ProdName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Prod_Name");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Tat).HasColumnName("TAT");
            entity.Property(e => e.TestingMethod)
                .HasMaxLength(75)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Quotation>(entity =>
        {
            entity.HasKey(e => e.QuotationNo);

            entity.ToTable("Quotation");

            entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");
            entity.Property(e => e.CreatedUser)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CustomerId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.ModifiedDate).HasColumnType("smalldatetime");
            entity.Property(e => e.ModifiedUser)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.QuotationDate).HasColumnType("smalldatetime");
            entity.Property(e => e.Status)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Subject)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Value).HasColumnType("numeric(10, 2)");
        });

        modelBuilder.Entity<QuotationDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Quotatio__3214EC27B2FB03BE");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Amount).HasColumnType("numeric(18, 3)");
            entity.Property(e => e.Price).HasColumnType("numeric(18, 3)");
            entity.Property(e => e.ProdCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Prod_code");
            entity.Property(e => e.ProdName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Prod_Name");
            entity.Property(e => e.Qty).HasColumnType("numeric(18, 3)");
            entity.Property(e => e.RowNo).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.QuotationNoNavigation).WithMany(p => p.QuotationDetails)
                .HasForeignKey(d => d.QuotationNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_QuotationDetails_Quotation");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
