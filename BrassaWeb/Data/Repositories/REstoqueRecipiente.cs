using BrassaWeb.Models;
using DataRepository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace BrassaWeb.Data.Repositories
{
    public class REstoqueRecipiente : Repository<EstoqueRecipiente>
    {
        public REstoqueRecipiente(IDataRepositoryContext contexto) : base(contexto)
        {
        }

        public override IEnumerable<EstoqueRecipiente> GetList(Expression<Func<EstoqueRecipiente, bool>> predicate)
        {
            ApplicationDbContext contexto = _contexto as ApplicationDbContext;
            return contexto.EstoqueRecipiente.Include("Brasseiro").Include("Recipiente").Where(predicate);
        }
    }
}
