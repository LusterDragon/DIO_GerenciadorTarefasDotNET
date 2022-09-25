using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIO_GerenciadorTarefaDOTNET.Models;
using Microsoft.EntityFrameworkCore;

namespace DIO_GerenciadorTarefaDOTNET.Context
{
    public class ListaTarefaContext:DbContext
    {
        public ListaTarefaContext(DbContextOptions<ListaTarefaContext> context) : base(context)
        {

        }
        public DbSet<Tarefa> Tarefas { get; set; }
    }
}
