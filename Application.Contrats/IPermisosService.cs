using Application.Contracts.Input;
using Models;

namespace Application.Contracts
{
    public interface IPermisosService
    {
        //void Add(PermisosInput permisos);
        //void Add(PermisosInput input);
        Task<int> Add(PermisosInput input);
        Task<int> Update(PermisosInput input);
        IEnumerable<Permisos> List();
        Task<IEnumerable<PermisosElastic>> Listar();
    }
}
