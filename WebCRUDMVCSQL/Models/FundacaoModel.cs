using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ObraFacilApp.Models
{
 
        [Table("Fundacao")]
        public class FundacaoModel
        {
            [Column("Id")]
            [Display(Name = "Código")]
            public int Id { get; set; }

            [Column("IdProjeto")]
            [Display(Name = "IdProjeto")]
            public int IdProjeto { get; set; }

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
            public bool QtdBlocosAlicerceÒK { get; set; }

        [Column("AlturaPedra")]
            [Display(Name = "Altura bloco do alicerce")]
            public double AlturaPedra { get; set; }
            public bool AlturaPedraOK { get; set; }

        [Column("ComprimentoPedra")]
            [Display(Name = "Comprimento bloco do alicerce")]
            public double ComprimentoPedra { get; set; }
            public bool ComprimentoPedraOK { get; set; }

        [Column("AlturaVigaBaldrame")]
            [Display(Name = "Altura viga baldrame")]
            public double AlturaVigaBaldrame { get; set; }
            public bool AlturaVigaBaldrameOK { get; set; }

        [Column("ComprimentoVigaBaldrame")]
            [Display(Name = "Comprimento da viga baldrame")]
            public double ComprimentoVigaBaldrame { get; set; }
            public bool ComprimentoVigaBaldrameOK { get; set; }

        [Column("LarguraVigaBaldrame")]
            [Display(Name = "Largura da viga baldrame")]
            public double LarguraVigaBaldrame { get; set; }
            public bool LarguraVigaBaldrameOK { get; set; }

        [Column("MetragemCubicaCimentoVigaBaldrama")]
            [Display(Name = "Metragem cubica de cimento")]
            public double MetragemCubicaCimentoVigaBaldrama { get; set; }
            public bool MetragemCubicaCimentoVigaBaldramaOK { get; set; }

        [Column("QtdMicro")]
            [Display(Name = "Quantidade de micro estacas")]
            public double QtdMicro { get; set; }
            public bool QtdMicroOK { get; set; }

        [Column("DataInicioFundacao")]
            [Display(Name = "Data de inicio da fundação")]
            public DateTime DataInicioFundacao { get; set; }
            public bool DataInicioFundacaoOK { get; set; }

        [Column("DataConclusaoFundacao")]
            [Display(Name = "Data de conclusão da fundação")]
            public DateTime DataConclusaoFundacao { get; set; }
            public bool DataConclusaoFundacaoOK { get; set; }

            public ProjetoModel Projeto { get; set; }

        }
}
