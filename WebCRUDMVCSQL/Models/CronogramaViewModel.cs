namespace ObraFacilApp.Models
{
    public class CronogramaViewModel
    {
       public string NomeEtapa { get; set; }
       public string PercentEtapa { get; set; }
       public DateTime DataInicio { get; set; }
       public DateTime DataFim { get; set; }
       public bool DataInicioOk { get; set; }
       public bool DataFimOk { get; set; }


    }
}
