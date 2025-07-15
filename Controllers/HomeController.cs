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
        ViewBag.mensaje = null;
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
            string rutaFoto = "/images/default.png";
            switch(intentoIntegrante.nombre.ToLower())
            {
                case "jazarbe": rutaFoto = "/images/jaz.jfif"; break;
                case "domix": rutaFoto = "/images/dami.jfif"; break;
                case "jonina": rutaFoto = "/images/jona.jfif"; break;
            }
            HttpContext.Session.SetString("fotoPerfil", rutaFoto);
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
    public IActionResult OlvideContra()
    {
        return View();
    }

    public IActionResult CambiarContra(string nombre, string nuevaContra)
    {
        BD miBd = new BD();
        Integrante integrante = miBd.BuscarIntegrantePorNombre(nombre);
        if (integrante == null)
        {
            ViewBag.mensaje = "El usuario no existe";
            return View("OlvideContrasenia");
        }

        miBd.CambiarContra(nombre, nuevaContra);

        ViewBag.mensaje = "Contraseña cambiada correctamente";
        return View("Index");
    }
    public IActionResult SignIn()
    {
        return View();
    }
    public IActionResult CrearCuenta(string nombre, string contra, string email, DateTime fechaNac, string telefono, string direccion, string rol)
    {
        BD miBd = new BD();

        if (miBd.BuscarIntegrantePorNombre(nombre) != null)
        {
            ViewBag.mensaje = "El nombre de usuario ya existe";
            return View("SignIn");
        }

        miBd.AgregarIntegrante(nombre, contra, email, fechaNac, telefono, direccion, rol);

        ViewBag.mensaje = "Cuenta creada correctamente";
        return View("Index");
    }
}
