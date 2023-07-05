using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using restaurant.Models;

namespace restaurant.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Producto> DataProducto  {get;set;}
    public DbSet<CategoriaProducto> DataCategoriaProducto  {get;set;}
    public DbSet<Tarjeta> DataTarjeta  {get;set;}
    public DbSet<Persona> DataPersona  {get;set;}
    public DbSet<Repartidor> DataRepartidor {get;set;}
    public DbSet<Usuario> DataUsuario {get;set;}
}
