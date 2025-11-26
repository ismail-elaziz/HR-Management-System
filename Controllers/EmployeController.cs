using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projet_DotNet.Data;
using Projet_DotNet.Models;
using System.IO;

namespace Projet_DotNet.Controllers
{
    public class EmployeController : Controller
    {
        private readonly GestionDbContext _context;

        public EmployeController(GestionDbContext context)
        {
            _context = context;
        }

        // GET: Employe/Index
        public IActionResult Index()
        {
            var Results = _context.Employes
                .Include(x => x.Departement)
                .OrderBy(x => x.NomEmploye)
                .ToList();
            return View(Results);
        }

        // GET: Employe/Create
        public IActionResult Create()
        {
            ViewBag.Departements = _context.Departements.OrderBy(x => x.NomDepartement).ToList();
            return View();
        }

        // POST: Employe/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employe employe)
        {
            if (ModelState.IsValid)
            {
                if (HttpContext.Request.Form.Files.Count > 0)
                {
                    var file = HttpContext.Request.Form.Files[0];
                    string NomImage = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    var fileStream = new FileStream(Path.Combine(@"wwwroot/Images", NomImage), FileMode.Create);
                    file.CopyTo(fileStream);
                    employe.UserImage = NomImage;
                }
                else
                {
                    employe.UserImage = "DefaultImage.jpg";
                }

                _context.Employes.Add(employe);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Departements = _context.Departements.OrderBy(x => x.NomDepartement).ToList();
            return View(employe);
        }

        // GET: Employe/Edit/{id}
        public IActionResult Edit(int? id)
        {
            if (id == null || !_context.Employes.Any(e => e.EmployeId == id))
            {
                return NotFound();
            }

            var employe = _context.Employes.Find(id);
            if (employe == null)
            {
                return NotFound();
            }

            ViewBag.Departements = _context.Departements.OrderBy(x => x.NomDepartement).ToList();
            return View(employe);
        }

        // POST: Employe/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employe model)
        {
            if (ModelState.IsValid)
            {
                // Fetch the existing employee record
                var existingEmploye = _context.Employes.Find(model.EmployeId);
                if (existingEmploye == null)
                {
                    return NotFound();
                }

                // Update the employee properties
                existingEmploye.NomEmploye = model.NomEmploye;
                existingEmploye.PrenomEmploye = model.PrenomEmploye;
                existingEmploye.DateNaissance = model.DateNaissance;
                existingEmploye.Salaire = model.Salaire;
                existingEmploye.DateEmbauche = model.DateEmbauche;
                existingEmploye.DepartementId = model.DepartementId;

                // Handle image update
                var file = HttpContext.Request.Form.Files;
                if (file.Count > 0)
                {
                    // Save new image
                    string NomImage = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", NomImage);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file[0].CopyTo(fileStream);
                    }

                    // Remove the old image if it's not the default
                    if (existingEmploye.UserImage != "DefaultImage.jpg" && !string.IsNullOrEmpty(existingEmploye.UserImage))
                    {
                        var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", existingEmploye.UserImage);
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    // Assign the new image name
                    existingEmploye.UserImage = NomImage;
                }
                else
                {
                    // Retain the existing image if no new file is uploaded
                    existingEmploye.UserImage = existingEmploye.UserImage;
                }


                // Save changes to the database
                _context.Employes.Update(existingEmploye);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));  // Redirecting to the Index page
            }

            // Reload departments for the view in case of validation error
            ViewBag.Departements = _context.Departements.OrderBy(x => x.NomDepartement).ToList();
            return View(model);
        }


        // GET: Employe/Delete/{id}
        public IActionResult Delete(int? id)
        {
            var Resultat = _context.Employes.Find(id);
            if (Resultat != null)
            {
                // Remove the old image if not the default
                if (Resultat.UserImage != "DefaultImage.jpg")
                {
                    var imagePath = Path.Combine(@"wwwroot/Images", Resultat.UserImage);
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                }

                _context.Employes.Remove(Resultat);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
