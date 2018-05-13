using BrassaWeb.Models;
using DataRepository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrassaWeb.Data.Repositories
{
    public class RBrasseiro : Repository<Brasseiro>
    {
        public RBrasseiro(IDataRepositoryContext contexto) : base(contexto)
        {
        }
    }
}
