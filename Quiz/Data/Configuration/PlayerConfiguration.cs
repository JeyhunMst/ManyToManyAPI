using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Quiz.Models;

namespace Quiz.Data.Configuration
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Player> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(30).IsRequired(true);
            builder.Property(p => p.Surname).HasMaxLength(30).IsRequired(true);
            builder.Property( p=> p.Age).IsRequired(true);
            builder.Property(p=>p.ExperienceTime).IsRequired(true);
        }
    }
}
