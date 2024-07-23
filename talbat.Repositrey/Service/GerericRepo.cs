using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talbat.core.Entities;
using talbat.core.Repositery;

namespace talbat.Repositrey.Service
{
    public class GerericRepo<T> : IGenericRepo<T> where T : BaseEnitity
    {
        private readonly dbcontext _dbcontext;

        public GerericRepo(dbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<IEnumerable<T>> GetAllAsyn()
{
 if (typeof(T) == typeof(Product))
   return (IEnumerable<T>)await _dbcontext.products.Include(P => P.ProductBrand).Include(P => P.productType).ToListAsync();

else
                return await _dbcontext.Set<T>().ToListAsync();

        }

        public async Task<T> GetbyIdAsync(int id)
        => await _dbcontext.Set<T>().FindAsync(id);
    }
}
