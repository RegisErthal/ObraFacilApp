using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ObraFacilApp.Models
{

    [Table("Alvenaria")]
    public class AlvenariaModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        [Display(Name = "Código")]
        public int? Id { get; set; }

        [Column("ProjetoId")]
        [Display(Name = "ProjetoId")]
        public int? ProjetoId { get; set; }

        [Column("MetrosDeParede")]
        [Display(Name = "Metros² de paredes")]
        public double MetrosDeParede { get; set; }
        public bool MetrosDeParedeOK { get; set; }

        [Column("QtdBlocos")]
        [Display(Name = "Quantidade de blocos")]
        public double QtdBlocos { get; set; }
        public bool QtdBlocosOk { get; set; }

        [Column("AlturaBloco")]
        [Display(Name = "Altura dos blocos em metros")]
        public double AlturaBloco { get; set; }
        
        [Column("ComprimentoBlocos")]
        [Display(Name = "Comprimento dos blocos em metros")]
        public double ComprimentoBlocos { get; set; }
        
        [Column("QtdPilares")]
        [Display(Name = "Quantidade de pilares")]
        public double QtdPilares { get; set; }
        public bool QtdPilaresOk { get; set; }

        [Column("PrevisaoCusto")]
        [Display(Name = "Previsao de custo da etapa")]
        public double PrevisaoCusto { get; set; }
        

        [Column("DataInicioAlvenaria")]
        [Display(Name = "Previsão de ínicio")]
        public DateTime DataInicioAlvenaria { get; set; }
        public bool DataInicioAlvenariaOk { get; set; }
        
        [Column("DataConclusaoAlvenaria")]
        [Display(Name = "Previsão de conclusão")]
        public DateTime DataConclusaoAlvenaria { get; set; }
        public bool DataConclusaoAlvenariaOk { get; set; }

        public ProjetoModel? Projeto { get; set; }
    }
}
