using ObraFacilApp.Models.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObraFacilApp.Models
{
    public class ComentariosModel
    {
        public int Id { get; set; }
        public int IdEntidade { get; set; }
        public TiposEntidadesEnum TiposEntidades { get; set; }
        public string Texto { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataCriacao { get; set; }
        [NotMapped]
        public string UserName { get; set; }
    }
}
