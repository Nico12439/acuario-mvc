using Microsoft.AspNetCore.Mvc;
using AcuarioMvc.Models;

namespace AcuarioMvc.Controllers;

public class PecesController : Controller
{

    private static List<Pez> peces = new List<Pez>
    {
        new Pez { Id = 1, Nombre = "Guppy", TipoAgua = "Agua dulce", Cantidad = 5, FechaRegistro = DateTime.Now },
        new Pez { Id = 2, Nombre = "Betta", TipoAgua = "Agua dulce", Cantidad = 2, FechaRegistro = DateTime.Now },
        new Pez { Id = 3, Nombre = "Neón", TipoAgua = "Agua dulce", Cantidad = 8, FechaRegistro = DateTime.Now },
        new Pez { Id = 4, Nombre = "Pez payaso", TipoAgua = "Agua salada", Cantidad = 2, FechaRegistro = DateTime.Now },
        new Pez { Id = 5, Nombre = "Pez cirujano", TipoAgua = "Agua salada", Cantidad = 1, FechaRegistro = DateTime.Now },
        new Pez { Id = 6, Nombre = "Pez ángel", TipoAgua = "Agua salada", Cantidad = 3, FechaRegistro = DateTime.Now }
    };
    private static int siguienteId = 7;

    // GET: /Peces?tipoAgua=Agua dulce
    // Muestra la lista y aplica el filtro si viene en la URL
    public IActionResult Index(string? tipoAgua)
    {
        List<Pez> lista = peces;

        if (!string.IsNullOrEmpty(tipoAgua))
        {
            lista = peces.Where(p => p.TipoAgua == tipoAgua).ToList();
        }

        ViewBag.TipoAgua = tipoAgua;
        ViewBag.TotalPeces = lista.Sum(p => p.Cantidad);

        return View(lista);
    }

    // GET: /Peces/Create
    // Muestra el formulario vacío
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    // POST: /Peces/Create
    // Recibe el formulario, valida y guarda el pez
    [HttpPost]
    public IActionResult Create(Pez pez)
    {
        if (!ModelState.IsValid)
        {
            return View(pez);
        }

        pez.Id = siguienteId++;
        pez.FechaRegistro = DateTime.Now;
        peces.Add(pez);

        return RedirectToAction("Index");
    }
}
