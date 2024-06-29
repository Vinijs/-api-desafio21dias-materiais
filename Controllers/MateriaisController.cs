using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using api.Models;
using api.Servicos;
using EntityFrameworkPaginateCore;
using web_renderizacao_server_side.Helpers;

namespace api.Controllers
{
    [ApiController]
    [Logado]
    public class MateriaisController : ControllerBase
    {
        private readonly DbContexto _context;
        private const int QUANTIDADE_POR_PAGINA = 3;

        public MateriaisController(DbContexto context)
        {
            _context = context;
        }

        // GET: /materiais
        [HttpGet]
        [Route("/materiais/")]
        public async Task<IActionResult> Index(int page = 1)
        {
            //   var materiaisPaginados = await _context.Materiais.OrderBy(m => m.Id)
            //         .Skip((page - 1) * qtdPage)
            //         .Take(qtdPage)
            //         .ToListAsync();

            //   return StatusCode(200, materiaisPaginados);

             return StatusCode(200, await _context.Materiais.OrderBy(a => a.Id).PaginateAsync(page, QUANTIDADE_POR_PAGINA));
        }

        // GET: /materiais/5
        [HttpGet]
        [Route("/materiais/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Materiais == null)
            {
                return NotFound();
            }

            var material = await _context.Materiais
                .FirstOrDefaultAsync(m => m.Id == id);
            if (material == null)
            {
                return NotFound();
            }

            return StatusCode(200, material);
        }

        // POST: /materiais
        [HttpPost]
        [Route("/materiais")]
        public async Task<IActionResult> Create(Material material)
        {
            if (ModelState.IsValid)
            {
                if(! await AlunoServico.ValidarAluno(material.AlunoId))
                {
                    return StatusCode(400, new {Mensagem = "O aluno passado não é válido ou não está cadastrado"});
                }

                _context.Add(material);
                await _context.SaveChangesAsync();
                return  StatusCode(201, material);
            }
            return StatusCode(400, new {Mensagem = "O material passado é inválido"});
        }

        // PUT: /materiais/5
        [HttpPut]
        [Route("/materiais/{id}")]
        public async Task<IActionResult> Edit(int id,Material material)
        {
            if (ModelState.IsValid)
            {
                if(! await AlunoServico.ValidarAluno(material.AlunoId))
                {
                    return StatusCode(400, new {Mensagem = "O aluno passado não é válido ou não está cadastrado"});
                }
                
                try
                {
                    material.Id = id;
                    _context.Update(material);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialExists(material.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return StatusCode(200, material);
            }
            return StatusCode(200, material);
        }

        // DELETE: /materiais/5
        [HttpDelete]
        [Route("/materiais/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Materiais == null)
            {
                return Problem("Entity set 'DbContexto.Materiais'  is null.");
            }
            var material = await _context.Materiais.FindAsync(id);
            if (material != null)
            {
                _context.Materiais.Remove(material);
            }
            
            await _context.SaveChangesAsync();
            return StatusCode(204);
        }

        private bool MaterialExists(int id)
        {
          return _context.Materiais.Any(e => e.Id == id);
        }
    }
}
