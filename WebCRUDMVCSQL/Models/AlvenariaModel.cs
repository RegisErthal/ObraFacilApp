using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ObraFacilApp.Models
{

    [Table("Alvenaria")]
    public class AlvenariaModel
    {
        [Column("Id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("IdProjeto")]
        [Display(Name = "IdProjeto")]
        public int IdProjeto { get; set; }

        [Column("QtdBlocos")]
        [Display(Name = "Quantidade de blocos blocos")]
        public double QtdBlocos { get; set; }
        public bool QtdBlocosOk { get; set; }

        [Column("AlturaBloco")]
        [Display(Name = "Altura dos blocos")]
        public double AlturaBloco { get; set; }
        public bool AlturaBlocoOk { get; set; }
        [Column("ComprimentoBlocos")]
        [Display(Name = "Comprimento dos blocos")]
        public double ComprimentoBlocos { get; set; }
        public bool ComprimentoBlocosOk { get; set; }
        [Column("QtdPilares")]
        [Display(Name = "Quantidade de pilares")]
        public double QtdPilares { get; set; }
        public bool QtdPilaresOk { get; set; }
        [Column("DataInicioAlvenaria")]
        [Display(Name = "Data de previsao de ínicio da alvenaria")]
        public DateTime DataInicioFundacao { get; set; }
        public bool DataInicioFundacaoOk { get; set; }
        [Column("DataConclusaoAlvenaria")]
        [Display(Name = "Data de previsao de conclusão da alvenaria")]
        public DateTime DataConclusaoAlvenaria { get; set; }
        public bool DataConclusaoAlvenariaOk { get; set; }

        public ProjetoModel? Projeto { get; set; }
    }
}
