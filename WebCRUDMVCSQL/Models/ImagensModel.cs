using ObraFacilApp.Models.Enum;

namespace ObraFacilApp.Models
{
    public class ImagensModel
    {
        public int Id { get; set; }
        public int IdEntidade { get; set; }
        public TiposEntidadesEnum TiposEntidades { get; set; }

        public string FileName { get; set; }
        public string FilePath { get; set; }
    }
}
