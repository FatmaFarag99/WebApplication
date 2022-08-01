namespace WebApplication.Core.Models.Configuration;
public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property<Guid>(e => e.Id).HasValueGenerator<GuidValueGenerator>();

        builder.Property(e => e.Name).IsRequired();

        builder.Property(e => e.CreationDate).HasDefaultValueSql("getDate()");
        builder.Property(e => e.ConcurrencyStamp).IsRowVersion();
    }
}