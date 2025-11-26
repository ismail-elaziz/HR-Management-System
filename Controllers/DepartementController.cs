using Microsoft.AspNetCore.Mvc;
using Projet_DotNet.Data; // Changez avec votre namespace
using Projet_DotNet.Models;
using System.Linq;

public class DepartementController : Controller
{
    private readonly GestionDbContext _context;

    public DepartementController(GestionDbContext context)
    {
        _context = context;
    }

    // GET: Departement/Index
    public IActionResult Index()
    {
        var departements = _context.Departements.ToList();
        return View(departements);
    }

    // GET: Departement/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Departement/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Departement model)
    {
        if (ModelState.IsValid)
        {
            _context.Departements.Add(model);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(model);
    }


    // GET: Departement/Edit/{id}
    public IActionResult Edit(int? id)
    {
        if (id == null || !_context.Departements.Any(d => d.DepartementId == id))
        {
            return NotFound();
        }

        var departement = _context.Departements.Find(id);
        return View(departement);
    }

    // POST: Departement/Edit
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Departement model)
    {
        if (ModelState.IsValid)
        {
            _context.Departements.Update(model);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(model);
    }
    // GET: Departement/Details/{id}
    public IActionResult Details(int? id)
    {
        if (id == null || !_context.Departements.Any(d => d.DepartementId == id))
        {
            return NotFound();
        }

        var departement = _context.Departements.Find(id);
        if (departement == null)
        {
            return NotFound();
        }

        return View(departement);
    }


    // GET: Departement/Delete/{id}
    public IActionResult Delete(int? id)
    {
        if (id == null || !_context.Departements.Any(d => d.DepartementId == id))
        {
            return NotFound();
        }

        var departement = _context.Departements.Find(id);
        return View(departement);
    }

    // POST: Departement/Delete
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var departement = _context.Departements.Find(id);
        if (departement != null)
        {
            _context.Departements.Remove(departement);
            _context.SaveChanges();
        }
        return RedirectToAction(nameof(Index));
    }
}
