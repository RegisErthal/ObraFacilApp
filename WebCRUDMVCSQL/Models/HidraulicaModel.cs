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

        [Column("QtdRegistros")]
        [Display(Name = "Quantidade de torneiras")]
        public decimal QtdRegistros { get; set; }
        public bool QtdRegistrosOk { get; set; }

        [Column("QtdRalos")]
        [Display(Name = "Quantidade de saídas para esgoto")]
        public double QtdRalos { get; set; }
        public bool QtdRalosOK { get; set; }

        [Column("QtdCaixaGordura")]
        [Display(Name = "Quantidade de caixa de gordura")]
        public decimal QtdCaixaGordura { get; set; }
        public bool QtdCaixaGorduraOk { get; set; }

        [Column("DataInicioHidraulica ")]
        [Display(Name = "Previsao de ínicio")]
        public DateTime DataInicioHidraulica { get; set; }
        public bool DataInicioHidraulicaOK { get; set; }

        [Column("DataConclusaoHidraulica")]
        [Display(Name = "Previsão de conclusão")]
        public DateTime DataConclusaoHidraulica { get; set; }
        public bool DataConclusaoHidraulicaOK { get; set; }
        public ProjetoModel? Projeto { get; set; }

    }
}
