using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ObraFacilApp.Models;

namespace ObraFacilApp.Map
{
    public class EletricaMap : IEntityTypeConfiguration<EletricaModel>
    {
        public void Configure(EntityTypeBuilder<EletricaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Projeto);

        }
    }
}
