using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tecnogas.Data;
using tecnogas.Models;

namespace tecnogas.Controllers;

public class SolicitudesController : Controller
{
    private readonly AppDbContext _context;

    public SolicitudesController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var solicitudes = await _context.Solicitudes.ToListAsync();
        return View(solicitudes);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(SolicitudServicio solicitud)
    {
        if (ModelState.IsValid)
        {
            solicitud.FechaRegistro = DateTime.Now;
            _context.Add(solicitud);
            await _context.SaveChangesAsync();
            TempData["Mensaje"] = "Solicitud registrada correctamente.";
            return RedirectToAction(nameof(Index));
        }

        var solicitudes = await _context.Solicitudes.ToListAsync();
        return View(solicitudes);
    }
}
