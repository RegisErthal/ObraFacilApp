using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ObraFacilApp.Models;

namespace ObraFacilApp.Map
{
    public class FundacaoMap : IEntityTypeConfiguration<FundacaoModel>
    {
        public void Configure(EntityTypeBuilder<FundacaoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x);
        }
    }
}
