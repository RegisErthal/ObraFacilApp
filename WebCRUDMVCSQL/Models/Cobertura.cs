using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ObraFacilApp.Models
{
    [Table("Cobertura")]
    public class Cobertura
    {
            [Column("Id")]
            [Display(Name = "Código")]
            public int Id { get; set; }

            [Column("IdProjeto")]
            [Display(Name = "IdProjeto")]
            public int IdProjeto { get; set; }
            
            [Column("TamanhoCobertura")]
            [Display(Name = "Metragem da cobertura")]
            public double TamanhoCobertura { get; set; }

            [Column("PossueLaje")]
            [Display(Name = "Possui laje")]
            public bool PossueLaje { get; set; }

            [Column("EspessuraLaje")]
            [Display(Name = "Espessura da laje")]
            public double EspessuraLaje { get; set; }

            [Column("DataInicioCobertura")]
            [Display(Name = "Data de previsao de ínicio da cobertura")]
            public DateTime DataInicioCobertura { get; set; }

            [Column("DataConclusaoCobertura")]
            [Display(Name = "Data de previsao de conclusão da alvenaria")]
            public DateTime DataConclusaoCobertura { get; set; }

    }
}
