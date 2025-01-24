using BlazorAppServer;

public class FacultyStaffConfiguration  : IEntityTypeConfiguration<Staff>
{
    public void Configure(EntityTypeBuilder<Staff> modelBuilder)
    {
        modelBuilder.ToTable("Staff");

        modelBuilder.HasKey(e => e.Id);
        modelBuilder.HasIndex(e => e.Name).IsUnique();

        modelBuilder.Property(e => e.Id).IsRequired();
        modelBuilder.Property(e => e.Id).HasMaxLength(5);
        modelBuilder.Property(e => e.Name).IsRequired();
        modelBuilder.Property(e => e.Name).HasMaxLength(50);
        modelBuilder.Property(e => e.Mobile).HasMaxLength(20);
        modelBuilder.Property(e => e.Age).HasMaxLength(2);
        modelBuilder.Property(e => e.Age).HasDefaultValue(18);

        modelBuilder.Property(e => e.Email).HasMaxLength(200);
        modelBuilder.Property(e => e.Department).HasMaxLength(100);
    }
}

