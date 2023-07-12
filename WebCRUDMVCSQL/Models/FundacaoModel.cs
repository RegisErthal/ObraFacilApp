using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ObraFacilApp.Models
{

    [Table("Fundacao")]
    public class FundacaoModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        [Display(Name = "Código")]
        public int? Id { get; set; }

        [Column("ProjetoId")]
        [Display(Name = "ProjetoId")]
        public int? ProjetoId { get; set; }

        [Column("ComprimentoAlicerce")]
        [Display(Name = "Comprimento do alicerce em metros")]
        public double ComprimentoAlicerce { get; set; }
        public bool ComprimentoAlicerceOK { get; set; }

        [Column("AlturaAlicerce")]
        [Display(Name = "Altura do alicerte em metros")]
        public double AlturaAlicerce { get; set; }
        public bool AlturaAlicerceOK { get; set; }

        [Column("QtdBlocosAlicerce")]
        [Display(Name = "Quantidade blocos do alicerce")]
        public double QtdBlocosAlicerce { get; set; }
        public bool QtdBlocosAlicerceOK { get; set; }

        [Column("AlturaPedra")]
        [Display(Name = "Altura bloco do alicerce em metros")]
        public double AlturaPedra { get; set; }
        public bool AlturaPedraOK { get; set; }

        [Column("ComprimentoPedra")]
        [Display(Name = "Comprimento bloco do alicerce em metros")]
        public double ComprimentoPedra { get; set; }
        public bool ComprimentoPedraOK { get; set; }

        [Column("AlturaVigaBaldrame")]
        [Display(Name = "Altura viga baldrame em metros")]
        public double AlturaVigaBaldrame { get; set; }
        public bool AlturaVigaBaldrameOK { get; set; }

        [Column("ComprimentoVigaBaldrame")]
        [Display(Name = "Comprimento da viga baldrame em metros")]
        public double ComprimentoVigaBaldrame { get; set; }
        public bool ComprimentoVigaBaldrameOK { get; set; }

        [Column("LarguraVigaBaldrame")]
        [Display(Name = "Largura da viga baldrame")]
        public double LarguraVigaBaldrame { get; set; }
        public bool LarguraVigaBaldrameOK { get; set; }

        [Column("VigaBaldrameOK")]
        [Display(Name = "Viga baldrame conclusida ")]
        public bool VigaBaldrameOK { get; set; }

        [Column("AlicerceOK")]
        [Display(Name = "Alicerce concluido")]
        public bool AlicerceOK { get; set; }

        [Column("MetragemCubicaCimentoVigaBaldrama")]
        [Display(Name = "Metragem cubica de cimento  da viga baldrame")]
        public double MetragemCubicaCimentoVigaBaldrama { get; set; }
        public bool MetragemCubicaCimentoVigaBaldramaOK { get; set; }

        [Column("QtdMicro")]
        [Display(Name = "Quantidade de micro estacas")]
        public double QtdMicro { get; set; }
        public bool QtdMicroOK { get; set; }
        [Column("IpermeabilizacaoVigaBaldrame")]
        [Display(Name = "Ipermeabilização  da viga baldrame")]
        public bool IpermeabilizacaoVigaBaldrameOK { get; set; }

        [Column("PrevisaoCusto")]
        [Display(Name = "Previsao de custo da etapa")]
        public double PrevisaoCusto { get; set; }

        [Column("DataInicioFundacao")]
        [Display(Name = "Previsão de início ")]
        public DateTime DataInicioFundacao { get; set; }
        public bool DataInicioFundacaoOK { get; set; }

        [Column("DataConclusaoFundacao")]
        [Display(Name = "Previsão de conclusão")]
        public DateTime DataConclusaoFundacao { get; set; }
        public bool DataConclusaoFundacaoOK { get; set; }

        [NotMapped]
        public List <IFormFile>? UploadFundacao { get; set; }

        [NotMapped]
        public  List<ImagensModel>? Imagens { get; set; }

        public ProjetoModel? Projeto { get; set; }

    }
}
