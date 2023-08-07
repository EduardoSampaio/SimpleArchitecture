using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleArchiteture.Domain.Entities;

namespace SimpleArchiteture.Data.EntitiesEfMap
{
    public class RentCarTypeConfiguration : IEntityTypeConfiguration<RentCar>
    {
        public void Configure(EntityTypeBuilder<RentCar> builder)
        {
            builder.ToTable(nameof(RentCar));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PickUpLocation).HasMaxLength(100);
            builder.Property(x => x.TotalPayable).HasPrecision(12,2);
            builder.Property(x => x.Discount).HasPrecision(12,2);
            builder.Property(x => x.DailyPrice).HasPrecision(12, 2);
        }
    }
}
