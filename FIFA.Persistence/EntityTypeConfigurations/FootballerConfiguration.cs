using FIFA.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FIFA.Persistence.EntityTypeConfigurations
{
    public class FootballerConfiguration : IEntityTypeConfiguration<Footballer>
    {
        public void Configure(EntityTypeBuilder<Footballer> builder)
        {
            builder.HasKey(footballer => footballer.Id);
            builder.HasIndex(footballer => footballer.Id).IsUnique();
            builder.Property(footballer => footballer.FirstName).HasMaxLength(150);
        }
    }
}
