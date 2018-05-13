using BrassaWeb.Models;
using DataRepository.Data;

namespace BrassaWeb.Data.Repositories
{
    public class RReceita : Repository<Receita>
    {
        public RReceita(IDataRepositoryContext contexto) : base(contexto)
        {
        }
    }
}
