using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcTest.Models.MoqData
{
    public class MoqData
    {
        public List<Product> GetAll()
        {
             List<Product> products = new List<Product>()
            {
                new Product { Id=1 ,Description="x"
                , Name="Iphone x " , Price=1500},
                new Product { Id=2 ,Description="x2"
                , Name="Iphone xd " , Price=2500},
                new Product { Id=3 ,Description="x3"
                , Name="Iphone 5 " , Price=800},
                new Product { Id=4 ,Description="x4"
                , Name="samsung " , Price=3500},
                new Product { Id=5 ,Description="x5" ,
                 Name="nokia " , Price=6000},

            };
            return products;
        }

        public Product DeleteById (int id)
        {
            List<Product> products = new List<Product>()
            {
                new Product { Id=1 ,Description="x"
                , Name="Iphone x " , Price=1500},
                new Product { Id=2 ,Description="x2"
                , Name="Iphone xd " , Price=2500},
                new Product { Id=3 ,Description="x3"
                , Name="Iphone 5 " , Price=800},
                new Product { Id=4 ,Description="x4"
                , Name="samsung " , Price=3500},
                new Product { Id=5 ,Description="x5" ,
                 Name="nokia " , Price=6000},

            };
            Product result = products.FirstOrDefault(p => p.Id == id) ;
            return result;
        }
    }
}
