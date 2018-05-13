using System.Threading.Tasks;
using BrassaWeb.Models;
using DataRepository.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BrassaWeb.Data.Repositories
{
    public class REstado : Repository<Estado>
    {
        public REstado(IDataRepositoryContext contexto) : base(contexto)
        {
        }
    }
}
