using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Models;
using mvc.Models.Entities;

namespace mvc.Controllers;

public class JobsController : PrincipalBaseController
{
    private readonly ApplicationDbContext _db;
    public JobsController(ApplicationDbContext db)
    {
        _db = db;
    }
    // interfaz es un contrato
    public async Task<IActionResult> Index()
    {
        var jobs = await _db.Jobs
            .OrderBy(x => x.JobName)
            .ToListAsync();
        return View(jobs);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Save(JobCreateViewModel model)
    {
        if (ModelState.IsValid)
        {
            await _db.AddAsync(new Job
            {
                JobName = model.JobName,
                JobDescription = model.JobDescription
            });

            await _db.SaveChangesAsync();
            return ResponseMessage(false, "Trabajo registrado correctamente");
            
        }

        return ResponseMessage(true, "Existen errores de validacion");
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return ResponseMessage(true, "El id es requerido");
        
        var job = await _db.Jobs.FindAsync((int)id);
        if (job == null)
        {
            TempData["ErrorMessage"] = "El trabajo a eliminar no fue encontrado en la base de datos";
            return RedirectToAction("Index");
        }

        _db.Jobs.Remove(job);
        await _db.SaveChangesAsync();
        TempData["SuccessMessage"] = "Trabajo eliminado correctamente";
        return RedirectToAction("Index");
    }


}