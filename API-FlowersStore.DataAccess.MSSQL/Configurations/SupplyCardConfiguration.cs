using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using API_FlowersStore.DataAccess.MSSQL.Entities;

namespace API_FlowersStore.DataAccess.MSSQL.Configurations
{
    public class SupplyCardConfiguration : IEntityTypeConfiguration<Supply>
    {
        public void Configure(EntityTypeBuilder<Supply> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
