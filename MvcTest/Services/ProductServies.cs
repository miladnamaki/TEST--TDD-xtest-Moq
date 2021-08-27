using MvcTest.Models;
using System.Collections.Generic;
using System.Linq;

namespace MvcTest.Services
{
    public class ProductServies : IProductServies
    {
        private readonly DataBaseContext _db;

        public ProductServies(DataBaseContext db)
        {
            _db = db;
        }

        public Product Add(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
            return product;
        }

        public void edit(Product model)
        {
            if (model!= null && model.Id>0)
            {
                var result = _db.Products.FirstOrDefault(x => x.Id==model.Id);
                if (result!=null)
                {
                    result.Id = model.Id;
                    result.Name = model.Name;
                    result.Price = model.Price;
                    result.Description = model.Description;
                    _db.SaveChanges();
                }
               
            }
        }

        public IEnumerable<Product> GetALL()
        {
            return _db.Products.ToList();
        }

        public Product GetById(long id)
        {
            return  _db.Products.Find(id);
             
        }

        public void Remove(long id)
        {
            var prodoct = _db.Products.Find(id);
            _db.Products.Remove(prodoct);
            _db.SaveChanges();
        }
    }
}
