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
            HttpContext.Session.SetInt32("usuarioId", intentoIntegrante.id);
            return RedirectToAction("Perfil", new { idSolicitado = intentoIntegrante.id });
        }
    }
    public IActionResult LogOut()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    public IActionResult Perfil(int idSolicitado)
    {
        int? idUsuario = HttpContext.Session.GetInt32("usuarioId");
        if (idUsuario == null)
        {
            return RedirectToAction("Index");
        }

        BD miBd = new BD();
        Integrante intentoIntegrante = miBd.BuscarIntegrantePorId(idUsuario.Value);

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
