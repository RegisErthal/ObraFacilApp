using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObraFacilApp.Models
{
    [Table("Login")]
    public class Login
    {
        [Column("Id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("UserName")]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Column("Senha")]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

    }
}


