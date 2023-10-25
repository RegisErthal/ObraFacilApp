using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ObraFacilApp.Models
{
    [Table("Cobertura")]
    public class CoberturaModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        [Display(Name = "Código")]
        public int? Id { get; set; }

        [Column("ProjetoId")]
        [Display(Name = "ProjetoId")]
        public int? ProjetoId { get; set; }

        [Column("TamanhoCobertura")]
        [Display(Name = "Metragem² da cobertura")]
        public double TamanhoCobertura { get; set; }
        public bool TamanhoCoberturaOK { get; set; }

        [Column("PossueLaje")]
        [Display(Name = "Possui laje")]
        public bool PossueLaje { get; set; }

        [Column("EspessuraLaje")]
        [Display(Name = "Espessura da laje em metros")]
        public double EspessuraLaje { get; set; }
        public bool EspessuraLajeOK { get; set; }

        [Column("MetragemCubicaLage")]
        [Display(Name = "Metragem³ de cimento da laje")]
        public double MetragemCubicaLage { get; set; }
        public bool MetragemCubicaLageOk { get; set; }

        [Column("PrevisaoCusto")]
        [Display(Name = "Previsao de custo da etapa")]
        public double PrevisaoCusto { get; set; }

        [Column("DataInicioCobertura")]
        [Display(Name = "Previsão de ínicio")]
        public DateTime DataInicioCobertura { get; set; }
        public bool DataInicioCoberturaOK { get; set; }

        [Column("DataConclusaoCobertura")]
        [Display(Name = "Previsao de conclusão")]
        public DateTime DataConclusaoCobertura { get; set; }
        public bool DataConclusaoCoberturaOK { get; set; }
        public ProjetoModel? Projeto { get; set; }
        [NotMapped]
        public List<IFormFile>? UploadCobertura { get; set; }

        [NotMapped]
        public List<ImagensModel>? Imagens { get; set; }
        [NotMapped]
        public List<ComentariosModel>? Comentarios { get; set; }

    }
}
