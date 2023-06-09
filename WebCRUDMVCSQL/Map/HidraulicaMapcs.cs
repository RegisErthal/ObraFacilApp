using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ObraFacilApp.Models;

namespace ObraFacilApp.Map
{
    public class HidraulicaMap : IEntityTypeConfiguration<HidraulicaModel>
    {
        public void Configure(EntityTypeBuilder<HidraulicaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Projeto);

        }
    }
}
