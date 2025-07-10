using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tpNoNum.Models;

namespace tpNoNum.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.mensaje = "¡Bienvenido!";
        return View();
    }

    public IActionResult LogIn(string nombre, string contraIntentada){
        BD miBd = new BD();
        Integrante intentoIntegrante = miBd.BuscarIntegrantePorNombre(nombre);
        if(intentoIntegrante == null){
            ViewBag.mensaje = "Nombre de usuario inexistente";
            return View("Index");
        }
        else if(contraIntentada != intentoIntegrante.contra){
            ViewBag.mensaje = "Contraseña incorrecta";
            return View("Index");
        }
        else{
            return RedirectToAction("Perfil", new { idSolicitado = intentoIntegrante.id });
        }
    }

    public IActionResult Perfil(int idSolicitado)
    {
        BD miBd = new BD();
        Integrante intentoIntegrante = miBd.BuscarIntegrantePorId(idSolicitado);
        ViewBag.nombre = intentoIntegrante.nombre;
        ViewBag.contra = intentoIntegrante.contra; 
        ViewBag.email = intentoIntegrante.email;
        ViewBag.fechaNac = intentoIntegrante.fechaNac;
        ViewBag.telefono = intentoIntegrante.telefono;
        ViewBag.direccion = intentoIntegrante.direccion;
        ViewBag.rol = intentoIntegrante.rol;
        return View();
    }
}
