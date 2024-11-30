using Microsoft.EntityFrameworkCore;
using ReciclajeApp.Models;
using webaplicationPFSonsonate.Models; 

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options){}
    //aplicando el contexto de la base de datos.
    public DbSet<Testimonio> Testimonios { get; set; }
    public DbSet<PreguntaFrecuente> PreguntasFrecuentes { get; set; }
    public DbSet<Documento> Documentos { get; set; }
    public DbSet<BuenaPractica> BuenasPracticas { get; set; }
    public DbSet<EmpresaReciclaje> EmpresaReciclaje { get; set; }

}