using Application.Contracts.Input;
using Models;

namespace Application.Contracts
{
    public interface ITipoPermisosService
    {
        void Add(TipoPermisosInput tipopermiso);

        IEnumerable<TipoPermisos> List();
    }
}
