using Microsoft.AspNetCore.Mvc;
using CadastroPessoaMVC.Models;
using CadastroPessoaMVC.Services;

namespace CadastroPessoaMVC.Controllers
{
    public class PessoaController : Controller
    {
        private readonly PessoaService _service;

        public PessoaController(PessoaService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                if (_service.CpfValido(pessoa.CPF))
                {
                    await _service.AddAsync(pessoa);
                    return RedirectToAction(nameof(Index));
                } else
                {
                    throw new ArgumentException("CPF inválido");
                }
            }
            return View(pessoa);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var pessoa = await _service.GetByIdAsync(id);
            if (pessoa == null) return NotFound();
            return View(pessoa);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(pessoa);
                return RedirectToAction(nameof(Index));
            }
            return View(pessoa);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var pessoa = await _service.GetByIdAsync(id);
            if (pessoa == null) return NotFound();
            return View(pessoa);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}