using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIO_GerenciadorTarefaDOTNET.Context;
using DIO_GerenciadorTarefaDOTNET.Models;

namespace DIO_GerenciadorTarefaDOTNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ListaTarefaContext _context;

        public TarefaController(ListaTarefaContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var tarefa = _context.Tarefas.Find(id);
            if (tarefa == null)
            {
                return NotFound();
            }
            return Ok(tarefa);
        }
        [HttpGet("FindAll")]
        public IActionResult FindAll()
        {
            var tarefas = _context.Tarefas.ToList();
            return Ok(tarefas);
        }
        [HttpGet("GetByTitle")]
        public IActionResult ObterPorTitulo(string titulo)
        {
            var tarefas = _context.Tarefas.Where(x => x.Titulo == titulo);
            return Ok(tarefas);
        }

        [HttpGet("GetByDate")]
        public IActionResult FindByDate(DateTime data)
        {
            var tarefas = _context.Tarefas.Where(x => x.Data.Date == data.Date);
            return Ok(tarefas);
        }

        [HttpGet("GetByStatus")]
        public IActionResult ObterPorStatus(EnumStatusTarefa status)
        {
            var tarefas = _context.Tarefas.Where(x => x.Status == status);
            return Ok(tarefas);
        }

        [HttpPost]
        public IActionResult Create(Tarefa tarefa)
        {
            if (tarefa.Data == DateTime.MinValue)
            {

                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });
            }
            _context.Add(tarefa);
            _context.SaveChanges();
 
            return Ok(tarefa);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Tarefa tarefa)
        {
            var tarefaBanco = _context.Tarefas.Find(id);

            if (tarefaBanco == null)
            {
                return NotFound();
            }

            if (tarefa.Data == DateTime.MinValue)
            {
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });
            }
            // TODO: Atualizar as informações da variável tarefaBanco com a tarefa recebida via parâmetro
            // TODO: Atualizar a variável tarefaBanco no EF e salvar as mudanças (save changes)
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var tarefaBanco = _context.Tarefas.Find(id);

            if (tarefaBanco == null) 
            {
                return NotFound(); 
            }

            _context.Remove(tarefaBanco);
            return NoContent();
        }
    }
}
