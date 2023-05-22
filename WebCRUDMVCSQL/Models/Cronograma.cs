using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ObraFacilApp.Models
{
    [Table("Cronograma")]
    public class Cronograma

    {
        [Column("Id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("DataConclusaoFundacao")]
        [Display(Name = "Data de conclusão da fundação")]
        public DateTime DataInicioFundacao { get; set; }
        public bool DataInicioFundacaoOk { get; set; }

        [Column("DataInicioAlvenaria")]
        [Display(Name = "Data de previsao de ínicio da alvenaria")]
        public DateTime DataConclusaoFundacao { get; set; }
        public bool DataConclusaoFundacaoOk { get; set; }
        [Column("DataConclusaoAlvenaria")]
        [Display(Name = "Data de previsao de conclusão da alvenaria")]
        public DateTime DataConclusaoAlvenaria { get; set; }
        public bool DataConclusaoAlvenariaOk { get; set; }
        [Column("DataInicioCobertura")]
        [Display(Name = "Data de previsao de ínicio da cobertura")]
        public DateTime DataInicioCobertura { get; set; }
        public bool DataInicioCoberturaOk { get; set; }
        [Column("DataConclusaoCobertura")]
        [Display(Name = "Data de previsao de conclusão da alvenaria")]
        public DateTime DataConclusaoCobertura { get; set; }


        [Column("DataInicioEletrica")]
        [Display(Name = "Data de previsao de ínicio da eletrica")]
        public DateTime DataInicioEletrica { get; set; }
        public bool DataInicioEletricaOk { get; set; }
        [Column("DataConclusaoEletrica")]
        [Display(Name = "Data de previsao de conclusão da eletrica")]
        public DateTime DataConclusaoEletrica { get; set; }
        public bool DataConclusaoEletricaOk { get; set; }
        [Column("DataInicioHidraulica ")]
        [Display(Name = "Data de previsao de ínicio da eletrica")]
        public DateTime DataInicioHidraulica { get; set; }
        public bool DataInicioHidraulicaOk { get; set; }
        [Column("DataConclusaoHidraulica")]
        [Display(Name = "Data de previsao de conclusão da eletrica")]
        public DateTime DataConclusaoHidraulica { get; set; }
        public bool DataConclusaoHidraulicaOk { get; set; }
      
    }
}