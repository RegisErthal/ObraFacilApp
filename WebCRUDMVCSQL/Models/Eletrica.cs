using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ObraFacilApp.Models
{
    [Table("Eletrica")]
    public class Eletrica
    {
        [Column("Id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("IdProjeto")]
        [Display(Name = "IdProjeto")]
        public int IdProjeto { get; set; }

        [Column("LigacaoMonofasica")]
        [Display(Name = "Ligação monofasica")]
        public bool LigacaoMonofasica { get; set; }

        [Column("LigacaoTrifasica")]
        [Display(Name = "Ligação trifasica")]
        public bool LigacaoTrifasica { get; set; }

        [Column("QtdDisjuntores")]
        [Display(Name = "Quantidade de disjuntores")]
        public double QtdDisjuntores { get; set; }

        [Column("QtdTomadas")]
        [Display(Name = "Quantidade de tomadas")]
        public double QtdTomadas { get; set; }

        [Column("QtdLampadas")]
        [Display(Name = "Quantidade de lampadas")]
        public double QtdLampadas { get; set; }

        [Column("DataInicioEletrica")]
        [Display(Name = "Data de previsao de ínicio da eletrica")]
        public DateTime DataInicioEletrica { get; set; }

        [Column("DataConclusaoEletrica")]
        [Display(Name = "Data de previsao de conclusão da eletrica")]
        public DateTime DataConclusaoEletrica { get; set; }

    }
}
