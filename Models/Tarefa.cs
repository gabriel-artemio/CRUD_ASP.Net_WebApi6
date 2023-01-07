using ASP.NET_webAPi.Enums;

namespace ASP.NET_webAPi.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string? Nm_tarefa { get; set; }
        public string? Descricao { get; set; }
        public StatusTarefas Status { get; set; }
    }
}
