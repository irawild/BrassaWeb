using BrassaWeb.Models;
using DataRepository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrassaWeb.Data.Repositories
{
    public class RItemVenda : Repository<ItemVenda>
    {
        public RItemVenda(IDataRepositoryContext contexto) : base(contexto)
        {
        }

        public override async Task<ItemVenda> GetById(int id)
        {
            ApplicationDbContext contexto = _contexto as ApplicationDbContext;
            return await contexto.ItemVenda.Include("Receita").Include("Recipiente").FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
