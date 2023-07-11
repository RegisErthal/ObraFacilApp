using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ObraFacilApp.Models
{
    [Table("Eletrica")]
    public class EletricaModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        [Display(Name = "Código")]
        public int? Id { get; set; }

        [Column("ProjetoId")]
        [Display(Name = "ProjetoId")]
        public int? ProjetoId { get; set; }

        [Column("LigacaoMonofasica")]
        [Display(Name = "Ligação monofasica")]
        public bool LigacaoMonofasica { get; set; }
        public bool LigacaoMonofasicaOk { get; set; }

        [Column("LigacaoTrifasica")]
        [Display(Name = "Ligação trifasica")]
        public bool LigacaoTrifasica { get; set; } = false;
        public bool LigacaoTrifasicaOk { get; set; } = false;

        [Column("QtdDisjuntores")]
        [Display(Name = "Quantidade de disjuntores")]
        public double QtdDisjuntores { get; set; }
        public bool QtdDisjuntoresOk { get; set; }

        [Column("QtdTomadas")]
        [Display(Name = "Quantidade de tomadas")]
        public double QtdTomadas { get; set; }
        public bool QtdTomadasOk { get; set; }

        [Column("QtdLampadas")]
        [Display(Name = "Quantidade de lampadas")]
        public double QtdLampadas { get; set; }
        public bool QtdLampadasOk { get; set; }

        [Column("PrevisaoCusto")]
        [Display(Name = "Previsao de custo da etapa")]
        public double PrevisaoCusto { get; set; }

        [Column("DataInicioEletrica")]
        [Display(Name = "Previsão de ínicio")]
        public DateTime DataInicioEletrica { get; set; }
        public bool DataInicioEletricaOk{ get; set; }

        [Column("DataConclusaoEletrica")]
        [Display(Name = "Previsão de conclusão")]
        public DateTime DataConclusaoEletrica { get; set; }
        public bool DataConclusaoEletricaOk { get; set; }
        public ProjetoModel? Projeto { get; set; }
    }
}
