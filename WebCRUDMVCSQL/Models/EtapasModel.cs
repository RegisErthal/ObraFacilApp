namespace ObraFacilApp.Models
{
    public class EtapasModel
    {
        public int Id { get; set; }
        public decimal FundacaoPerc { get; set; }
        public bool TemFundacao { get; set; }
        public decimal AlvenariaPerc { get; set; }
        public bool TemAlvenaria { get; set; }
        public decimal CoberturaPerc { get; set; }
        public bool TemCobertura { get; set; }
        public decimal EletricaPerc { get; set; }
        public bool TemEletrica { get; set; }
        public decimal HidraulicaPerc { get; set; }
        public bool TemHidraulica { get; set; }
        public bool MostraCronograma { get; set; }
        public bool UsuarioIsAdmin { get; set; }

    }
}
