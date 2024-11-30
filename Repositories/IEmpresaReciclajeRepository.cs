using ReciclajeApp.Models;

namespace ReciclajeApp.Repositories
{
    public interface IEmpresaReciclajeRepository
    {
        Task<List<EmpresaReciclaje>> ObtenerEmpresasReciclajeAsync();
        Task<EmpresaReciclaje> ObtenerEmpresaPorIdAsync(int id);
        Task CrearEmpresaReciclajeAsync(EmpresaReciclaje empresa);
    }
}
