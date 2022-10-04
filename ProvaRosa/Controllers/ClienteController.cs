using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prova.Data;
using Prova.Models;

namespace Prova.Controllers
{
    public class ClienteController : Controller
    {
        private readonly AppCont _appCont;

        public ClienteController(AppCont appCont)
        {
            _appCont = appCont;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Nome, Email, Cpf, DataNascimento")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _appCont.Add(cliente);
                await _appCont.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(cliente);
        }

        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
                return NotFound();

            var cliente = await _appCont.Clientes.FirstOrDefaultAsync(m => m.Id == id);

            if (cliente == null)
                return NotFound();

            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _appCont.Clientes.FindAsync(id);
            _appCont.Clientes.Remove(cliente);
            await _appCont.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
