namespace Eventos.Models;

public class Evento
{
   public  int Id { get; set; }
    public string? Nombre { get; set; }
    public DateTime Fecha  { get; set; } =  DateTime.Now;
    public string? Descripcion { get; set; }
    public string? Ubicacion { get; set; }
    public string? Imagen { get; set; }
}