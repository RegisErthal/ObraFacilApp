using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ObraFacilApp.Models;

namespace ObraFacilApp.Map
{
    public class CoberturaMap : IEntityTypeConfiguration<CoberturaModel>
    {
        public void Configure(EntityTypeBuilder<CoberturaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Projeto);

        }
    }
}
