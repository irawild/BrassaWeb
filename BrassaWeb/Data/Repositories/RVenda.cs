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
    public class RVenda : Repository<Venda>, IRVenda
    {
        public RVenda(IDataRepositoryContext contexto) : base(contexto)
        {
        }

		public override Task<Venda> GetById(int id)
		{
			ApplicationDbContext contexto = _contexto as ApplicationDbContext;
            return contexto.Venda
                .Include("Degustador")
                .Include("Brasseiro")
                .Include("ItensVenda.Receita.Estilo")
                .Include("ItensVenda.Recipiente")
				           .FirstOrDefaultAsync(v => v.Id == id);
		}

		public override IEnumerable<Venda> GetList(Expression<Func<Venda, bool>> predicate)
        {
            ApplicationDbContext contexto = _contexto as ApplicationDbContext;
            return contexto.Venda
                .Include("Degustador")
                .Include("Brasseiro")
                .Include("ItensVenda.Receita.Estilo")
                .Include("ItensVenda.Recipiente")
                .Where(predicate);
        }
    }
}
