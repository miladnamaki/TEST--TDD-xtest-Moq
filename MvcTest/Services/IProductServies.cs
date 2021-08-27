using MvcTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcTest.Services
{
    public interface IProductServies
    {
        IEnumerable<Product> GetALL();

        Product Add(Product product);
        Product GetById(long id);
        void Remove(long id);
        void edit(Product product);
    }
}
