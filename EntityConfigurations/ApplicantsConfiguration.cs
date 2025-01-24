namespace BlazorAppServer;

public class ApplicantsConfiguration : IEntityTypeConfiguration<Applicant>
{
    public void Configure(EntityTypeBuilder<Applicant> modelBuilder)
    {
        modelBuilder.ToTable("Applicants");

        modelBuilder.HasKey(e => e.Id);
        modelBuilder.HasIndex(e => e.Name).IsUnique();

        modelBuilder.Property(e => e.Id).IsRequired();
        modelBuilder.Property(e => e.Id).HasMaxLength(5);
        modelBuilder.Property(e => e.Name).IsRequired();
        modelBuilder.Property(e => e.Name).HasMaxLength(50);
        modelBuilder.Property(e => e.Mobile).HasMaxLength(20);
        modelBuilder.Property(e => e.Age).HasMaxLength(2);
        modelBuilder.Property(e => e.Age).HasDefaultValue(18);

        modelBuilder.Property(e => e.SecondarySchoolName).HasMaxLength(500);

    }
}
