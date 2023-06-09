using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ObraFacilApp.Models;

namespace ObraFacilApp.Map
{
    public class AlvenariaMap : IEntityTypeConfiguration<AlvenariaModel>
    {
        public void Configure(EntityTypeBuilder<AlvenariaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Projeto);

        }
    }
}
