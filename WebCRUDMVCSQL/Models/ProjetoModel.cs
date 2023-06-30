using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObraFacilApp.Models
{
    [Table("Projeto")]
    public class ProjetoModel
    {
        
        [Column("Id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("NomeProjeto")]
        [Display(Name = "Nome do Projeto")]
        public string NomeProjeto { get; set; }

        [Column("Responsavel")]
        [Display(Name = "Responsável")]
        public string Responsavel { get; set; }
        
        [Column("EmailResponsavel")]
        [Display(Name = "Email do Responsável")]
        public string EmailResponsavel { get; set; }

        [Column("MetragemQuadrada")]
        [Display(Name = "Valor de custo m²")]
        public string MetragemQuadrada { get; set; }

        [Column("CustoMetro")]
        [Display(Name = "Valor de custo m²")]
        public string CustoMetro { get; set; }

        [Column("DataInicio")]
        [Display(Name = "Data para ínicio da obra")]
        public DateTime DataInicio { get; set; }

        [Column("DataConclusao")]
        [Display(Name = "Data para coclusao da obra")]
        public DateTime DataConclusao { get; set; }

       
         public virtual List<FundacaoModel>? Fundacaos { get; set; }
         public virtual List<AlvenariaModel>? Alvenarias { get; set; }
         public virtual List<CoberturaModel>? Coberturas { get; set; }
         public virtual List<EletricaModel>? Eletricas { get; set; }
         public virtual List<HidraulicaModel>? Hidraulicas { get; set; }
    
    }
}
