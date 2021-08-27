using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoqMvc.Services
{
    public interface BrandIDProxy
    {
        BrandId BrandId { get; set; }
    }

    public interface BrandId
    {
        int BrandId { get; set;  }
    }
    public interface IProductServiceMock
    {
        int GetProductPrice (int id);
        void GetProductPrice (int id,out int price);
        int Productcount { get; set;  }
        Product Add(Product product);

        BrandIDProxy brandIDProxy { get; set; }


    }

    public class Product
    {
        public int Id { get; set;  }
        public string Name { get; set; }

    }
}
