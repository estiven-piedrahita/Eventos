using Microsoft.AspNetCore.Mvc;
using Eventos.Data;
using Eventos.Models;

namespace Eventos.Controllers;
public class PanelAdministrativoController : Controller
{
    private readonly MysqlConnexion _conexion;

    public PanelAdministrativoController(MysqlConnexion conexion)
    {
        _conexion = conexion;
    }
    
    
    
    // GET
    public IActionResult Index()
    {
        var eventos = _conexion.Eventos.ToList();
        return View(eventos);
    }
    public  IActionResult Create()
    {
        return View();
    }

    public IActionResult Create(Evento evento)
    {
        _conexion.Eventos.Add(evento);
        _conexion.SaveChanges();
        return RedirectToAction("Index");
        
    }
    
    public  IActionResult Show(int id)
    {
        var evento = _conexion.Eventos.Find(id);
        return View(evento);
    }
    
    public  IActionResult Edit(int id)
    {
        var evento = _conexion.Eventos.Find(id);
        return View(evento);
    }

    public IActionResult Update(Evento evento)
    {
        var NwEvento = _conexion.Eventos.Find(evento.Id);
        NwEvento.Nombre = evento.Nombre;
        NwEvento.Fecha = evento.Fecha;
        NwEvento.Descripcion = evento.Descripcion;
        NwEvento.Ubicacion = evento.Ubicacion;
        NwEvento.Imagen = evento.Imagen;
        _conexion.SaveChanges();
        return RedirectToAction("Index");
    }
    public  IActionResult Delete(int id)
    {
        var evento = _conexion.Eventos.Find(id);
        _conexion.Eventos.Remove(evento);
        _conexion.SaveChanges();
        return RedirectToAction("Index");
    }
    
    
}