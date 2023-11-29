using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObraFacilApp.Models
{
    public class TelaProjetosModel
    {
        public IEnumerable<ProjetoModel> Projetos { get; set; }
        public bool MostraBotaoCriar { get; set; }
        public bool IsAdmin { get; set; }
    
    }
}
