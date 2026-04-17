using Microsoft.EntityFrameworkCore;
using Eventos.Models;

namespace Eventos.Data;

public class MysqlConnexion : DbContext 
{
    public MysqlConnexion(DbContextOptions<MysqlConnexion> options) : base(options)
    {
        
    }   
    public DbSet<Evento>  Eventos { get; set; }
}