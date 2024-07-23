using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talbat.core.Entities;

namespace talbat.core.Repositery
{
    public interface IGenericRepo<T> where T : BaseEnitity
    {
       Task<IEnumerable<T>> GetAllAsyn();  
       Task<T> GetbyIdAsync(int id);   

    }
}
