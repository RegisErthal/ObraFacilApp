using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ObraFacilApp.Models
{
    [Table("Hidraulica")]
    public class Hidraulica
    {
        [Column("Id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("IdProjeto")]
        [Display(Name = "IdProjeto")]
        public int IdProjeto { get; set; }

        [Column("QtdTorneiras")]
        [Display(Name = "Quantidade de torneiras")]
        public double QtdTorneiras { get; set; }

        [Column("QtdRalos")]
        [Display(Name = "Quantidade de saídas para esgoto")]
        public double QtdRalos { get; set; }

        [Column("DataInicioEletrica")]
        [Display(Name = "Data de previsao de ínicio da eletrica")]
        public DateTime DataInicioEletrica { get; set; }

        [Column("DataConclusaoEletrica")]
        [Display(Name = "Data de previsao de conclusão da eletrica")]
        public DateTime DataConclusaoEletrica { get; set; }

    }
}
