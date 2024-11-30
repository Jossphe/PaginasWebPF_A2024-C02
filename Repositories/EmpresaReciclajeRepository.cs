using Microsoft.EntityFrameworkCore;
using System.Data;
using ReciclajeApp.Models;

namespace ReciclajeApp.Repositories
{
    public class EmpresaReciclajeRepository : IEmpresaReciclajeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmpresaReciclajeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<EmpresaReciclaje>> ObtenerEmpresasReciclajeAsync()
        {
            return await _context.EmpresaReciclaje.ToListAsync();
        }

        public async Task<EmpresaReciclaje> ObtenerEmpresaPorIdAsync(int id)
        {
            return await _context.EmpresaReciclaje
                 .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task CrearEmpresaReciclajeAsync(EmpresaReciclaje empresa)
        {
            _context.EmpresaReciclaje.Add(empresa);
            await _context.SaveChangesAsync();
        }
    }
}
