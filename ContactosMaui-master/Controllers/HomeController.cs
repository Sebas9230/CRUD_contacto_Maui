using Org.Apache.Http.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ContactosMaui.Services;
using ContactosMaui.Models;

namespace ContactosMaui.Controllers;

public class HomeController : Controller

{
    private readonly IServicioApi _servicioApi;

    public HomeController(IServicioApi servicioApi)
    {
        _servicioApi = servicioApi;
    }

    public async Task<IActionResult> Index()
    {
        List<Contacto> listContacto= new List<Contacto>();
        try
        {
            listContacto = await _servicioApi.ListarContactos();
        }
        catch (Exception ex)
        {

        }

        //ViewBag.model = listProducto;
        return View(listProducto);
    }

    public async Task<IActionResult> Contacto(int id)
    {
        Contacto contacto = new Contacto();

        ViewBag.Accion = "Nuevo Contacto";
        if (id != null)
        {
            contacto = await _servicioApi.ObtenerContacto(id);
            ViewBag.Accion = "Editar Contacto";
        }

        //ViewBag.model = listProducto;
        return View(contacto);
    }



    [HttpPost]
    public async Task<IActionResult> Guardar(Contacto contacto)
    {
        string httpStatusCode = HttpStatusCode.BadRequest.ToString();
        if (contacto.id == null)
        {
            httpStatusCode = await _servicioApi.GuardarContacto(contacto);
        }
        else
        {
            httpStatusCode = await _servicioApi.EditarContacto(contacto.id, contacto);
        }

        if (httpStatusCode.Equals(HttpStatusCode.OK.ToString()))
        {
            return RedirectToAction("Index");
        }
        else
        {
            return NoContent();
        }

        //ViewBag.model = listProducto;

    }

    [HttpGet]
    public async Task<IActionResult> Guardar(int id)
    {
        string httpStatusCode = HttpStatusCode.BadRequest.ToString();

        httpStatusCode = await _servicioApi.BorrarContacto(id);


        if (httpStatusCode.Equals(HttpStatusCode.OK.ToString()))
        {
            return RedirectToAction("Index");
        }
        else
        {
            return NoContent();
        }

        //ViewBag.model = listProducto;

    }


    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Page2()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
