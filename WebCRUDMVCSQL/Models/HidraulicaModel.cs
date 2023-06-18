using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ObraFacilApp.Models
{
    [Table("Hidraulica")]
    public class HidraulicaModel
    {   
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("ProjetoId")]
        [Display(Name = "ProjetoId")]
        public int ProjetoId { get; set; }

        [Column("QtdTorneiras")]
        [Display(Name = "Quantidade de torneiras")]
        public double QtdTorneiras { get; set; }
        public bool QtdTorneirasOK { get; set; }

        [Column("QtdRalos")]
        [Display(Name = "Quantidade de saídas para esgoto")]
        public double QtdRalos { get; set; }
        public bool QtdRalosOK { get; set; }

        [Column("DataInicioHidraulica ")]
        [Display(Name = "Data de previsao de ínicio da eletrica")]
        public DateTime DataInicioHidraulica { get; set; }
        public bool DataInicioHidraulicaOK { get; set; }

        [Column("DataConclusaoHidraulica")]
        [Display(Name = "Data de previsao de conclusão da eletrica")]
        public DateTime DataConclusaoHidraulica { get; set; }
        public bool DataConclusaoHidraulicaOK { get; set; }
        public ProjetoModel? Projeto { get; set; }

    }
}
