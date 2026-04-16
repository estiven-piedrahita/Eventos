namespace Eventos.Models;

public class Evento
{
    int Id { get; set; }
    string Nombre { get; set; }
    DateTime Fecha  { get; set; } =  DateTime.Now;
    string Descripcion { get; set; }
    string Ubicacion { get; set; }
    string Imagen { get; set; }
}