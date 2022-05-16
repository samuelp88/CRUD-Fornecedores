using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD_Fornecedores.Data;
using CRUD_Fornecedores.Models.ViewModels;
using CRUD_Fornecedores.Data.DataParser.Abstract;

namespace CRUD_Fornecedores.Controllers
{
    public class ProvidersController : Controller
    {
        private readonly CRUD_FornecedoresContext _context;
        private readonly IProviderParser _providerParser;
        public ProvidersController(CRUD_FornecedoresContext context, IProviderParser providerParser)
        {
            _context = context;
            _providerParser = providerParser;
        }

        // GET: Providers
        public async Task<IActionResult> Index()
        {
              return _context.Provider != null ? 
                          View(_providerParser.Parse(await _context.Provider.ToListAsync())) :
                          Problem("Entity set 'CRUD_FornecedoresContext.Provider'  is null.");
        }

        // GET: Providers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Provider == null)
            {
                return NotFound();
            }

            var provider = await _context.Provider
                .FirstOrDefaultAsync(m => m.ID == id);
            if (provider == null)
            {
                return NotFound();
            }

            var providerViewModel = _providerParser.Parse(provider);
            return View(providerViewModel);
        }

        // GET: Providers/Create
        public IActionResult Create()
        {
            var providerViewModel = new ProviderViewModel();
            return View(providerViewModel);
        }

        // POST: Providers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,CNPJ,Speciality")] ProviderViewModel providerViewModel)
        {
            if (ModelState.IsValid && ValidateProviderSpeciality(providerViewModel.Speciality))
            {
                _context.Add(_providerParser.Parse(providerViewModel));
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(providerViewModel);
        }

        // GET: Providers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Provider == null)
            {
                return NotFound();
            }

            var provider = await _context.Provider.FindAsync(id);
            if (provider == null)
            {
                return NotFound();
            }

            var providerViewModel = _providerParser.Parse(provider);
            return View(providerViewModel);
        }

        // POST: Providers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,CNPJ,Speciality")] ProviderViewModel providerViewModel)
        {
            if (id != providerViewModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid && ValidateProviderSpeciality(providerViewModel.Speciality))
            {
                try
                {
                    _context.Update(_providerParser.Parse(providerViewModel));
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProviderViewModelExists(providerViewModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(providerViewModel);
        }

        // GET: Providers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Provider == null)
            {
                return NotFound();
            }

            var provider = await _context.Provider
                .FirstOrDefaultAsync(m => m.ID == id);
            if (provider == null)
            {
                return NotFound();
            }

            var providerViewModel = _providerParser.Parse(provider);
            return View(providerViewModel);
        }

        // POST: Providers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Provider == null)
            {
                return Problem("Entity set 'CRUD_FornecedoresContext.ProviderViewModel'  is null.");
            }
            var providerViewModel = await _context.Provider.FindAsync(id);
            if (providerViewModel != null)
            {
                _context.Provider.Remove(providerViewModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProviderViewModelExists(int id)
        {
          return (_context.Provider?.Any(e => e.ID == id)).GetValueOrDefault();
        }

        private bool ValidateProviderSpeciality(string speciality)
        {
            return Enum.GetNames<Specialties>().Any(x => x.Equals(speciality));
        }
    }
}
