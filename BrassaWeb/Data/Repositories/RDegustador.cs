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
    public class RDegustador : Repository<Degustador>
    {
        public RDegustador(IDataRepositoryContext contexto) : base(contexto)
        {
        }

        public override IEnumerable<Degustador> GetList(Expression<Func<Degustador, bool>> predicate)
        {
            ApplicationDbContext context = _contexto as ApplicationDbContext;
            return context.Degustador.Include("Cidade").Where(predicate);
        }
    }
}
