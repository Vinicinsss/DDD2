using Microsoft.AspNetCore.Mvc;
using SistemaUniversitario.Application.DTOs;
using SistemaUniversitario.Application.Interfaces;
using System.Threading.Tasks;

namespace SistemaUniversitario.Web.Controllers
{
    public class CursosController : Controller
    {
        private readonly ICursoService _cursoService;

        public CursosController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        // GET: /Cursos
        public async Task<IActionResult> Index()
        {
            var cursos = await _cursoService.ObterTodosAsync();
            return View(cursos);
        }

        // Action chamada pelo AJAX
        [HttpGet]
        public async Task<IActionResult> BuscarCursos(string termo)
        {
            if (string.IsNullOrWhiteSpace(termo))
            {
                // Se a busca estiver vazia, retorna todos
                var todos = await _cursoService.ObterTodosAsync();
                return PartialView("_TabelaCursos", todos);
            }

            var cursosFiltrados = await _cursoService.PesquisarAsync(termo);
            return PartialView("_TabelaCursos", cursosFiltrados);
        }

        // GET: /Cursos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Cursos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CursoDTO cursoDto)
        {
            if (ModelState.IsValid)
            {
                await _cursoService.AdicionarAsync(cursoDto);
                return RedirectToAction(nameof(Index));
            }
            return View(cursoDto);
        }
        
        // GET: /Cursos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var curso = await _cursoService.ObterPorIdAsync(id);
            if (curso == null)
            {
                return NotFound();
            }
            return View(curso);
        }

        // POST: /Cursos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CursoDTO cursoDto)
        {
            if (id != cursoDto.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _cursoService.AtualizarAsync(cursoDto);
                return RedirectToAction(nameof(Index));
            }
            return View(cursoDto);
        }

        // GET: /Cursos/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var curso = await _cursoService.ObterPorIdAsync(id);
            if (curso == null)
            {
                return NotFound();
            }
            return View(curso);
        }

        // POST: /Cursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _cursoService.RemoverAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}