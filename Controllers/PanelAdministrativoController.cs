using Microsoft.AspNetCore.Mvc;
using Eventos.Data;
using Eventos.Models;
using Microsoft.EntityFrameworkCore;

namespace Eventos.Controllers;
public class PanelAdministrativoController : Controller
{
    private readonly MysqlConnexion _conexion;

    public PanelAdministrativoController(MysqlConnexion conexion)
    {
        _conexion = conexion;
    }
    
    
    // GET
    public async Task<IActionResult> Index()
    {
        var eventos =   await _conexion.Eventos.ToListAsync();
        if (eventos.Count == 0)
        {
            return NotFound();
        }
        return View(eventos);
    }
    public  IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Evento evento)
    {
       await _conexion.Eventos.AddAsync(evento);
        await _conexion.SaveChangesAsync();
        return RedirectToAction("Index");
        
    }
    
    public  async Task<IActionResult> Show(int id)
    {
        var evento = await _conexion.Eventos.FindAsync(id);
        if (evento == null)
        {
            return NotFound();
        }
        return View(evento);
    }
    
    public  async Task<IActionResult> Edit(int id)
    {
        var evento =  await _conexion.Eventos.FindAsync(id);
        if (evento == null)
        {
            return NotFound();
        }
        return View(evento);
    }
    [HttpPost]
    public async Task<IActionResult> Update(Evento evento)
    {
        var NwEvento = await _conexion.Eventos.FindAsync(evento.Id);
        if (NwEvento == null)
        {
            return NotFound();
        }
        NwEvento.Nombre = evento.Nombre;
        NwEvento.Fecha = evento.Fecha;
        NwEvento.Descripcion = evento.Descripcion;
        NwEvento.Ubicacion = evento.Ubicacion;
        NwEvento.Imagen = evento.Imagen;
        await _conexion.SaveChangesAsync();
        return RedirectToAction("Index");
    }
    [HttpPost]
    public  async Task<IActionResult> Delete(int id)
    {
        var evento = await _conexion.Eventos.FindAsync(id);
        if (evento == null)
        {
            return NotFound();
        }
        _conexion.Eventos.Remove(evento);
        _conexion.SaveChanges();
        return RedirectToAction("Index");
    }
    
    
}