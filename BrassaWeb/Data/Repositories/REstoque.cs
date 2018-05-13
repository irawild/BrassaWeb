using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BrassaWeb.Models;
using DataRepository.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BrassaWeb.Data.Repositories
{
    public class REstoque : Repository<EstoqueReceita>
    {
        public REstoque(IDataRepositoryContext contexto) : base(contexto)
        {
        }

        public override IEnumerable<EstoqueReceita> GetList(Expression<Func<EstoqueReceita, bool>> predicate)
        {
            ApplicationDbContext contexto = _contexto as ApplicationDbContext;
            //var lista = contexto.EstoqueReceita.Include("Receita.Estilo").Include("Avaliacoes").Where(predicate);
            //foreach (var item in lista)
            //{
                
            //}
            return contexto.EstoqueReceita.Include("Receita.Estilo").Include("Avaliacoes").Where(predicate);
        }

        public override Task<EstoqueReceita> GetById(int id)
        {
            ApplicationDbContext contexto = _contexto as ApplicationDbContext;
            return contexto.EstoqueReceita.Include("Brasseiro").Include("Receita.Estilo").FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
