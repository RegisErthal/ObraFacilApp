using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObraFacilApp.Models
{
    [Table("Projeto")]
    public class Projeto
    {
        [Column("Id")]
        [Display(Name ="Código")]
        public int Id { get; set; }

        [Column("NomeProjeto")]
        [Display(Name = "Nome do Projeto")]
        public string NomeProjeto { get; set; }
    }
}
