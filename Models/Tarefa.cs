using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIO_GerenciadorTarefaDOTNET.Models
{
    public class Tarefa
    {
        public int ID { get; set; }
        public string Titulo { get;set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public EnumStatusTarefa Status { get; set; }
    }
}
