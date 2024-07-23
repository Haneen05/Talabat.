using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace talbat.core.Entities
{
    public class Product:BaseEnitity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        public int? ProductBrandId { get; set; }
        public ProductBrand ProductBrand { get; set; }
        public int ? productTypeId { get; set; }

        public ProductType productType { get; set; }


    }
}
