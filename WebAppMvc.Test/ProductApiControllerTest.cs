using Microsoft.AspNetCore.Mvc;
using Moq;
using MvcTest.Controllers.api;
using MvcTest.Models;
using MvcTest.Models.MoqData;
using MvcTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WebAppMvc.Test
{
     public class ProductApiControllerTest
    {
        [Fact]
        public void GetTest()
        {
            MoqData data = new MoqData();
            var moq = new Mock<IProductServies>();
            moq.Setup(p => p.GetALL()).Returns(data.GetAll());
            ProductApiController productApi = new ProductApiController(moq.Object);
            var resul = productApi.Get();
            Assert.IsType<OkObjectResult>(resul);
            var result2 = resul as OkObjectResult;
            Assert.IsType<List<Product>>(result2.Value);

        }
        [Theory]
        [InlineData(1,25)]
        public void GetByIdTest(int validid, int invalidid)
        {
            MoqData data = new MoqData();
            var moq = new Mock<IProductServies>();
            moq.Setup(x => x.GetById(validid)).Returns(data.GetAll().FirstOrDefault(p=>p.Id==validid));

            ProductApiController productApi = new ProductApiController(moq.Object);

            var reuslt = productApi.Get(validid);

            Assert.IsType<OkObjectResult>(reuslt);
            var prudoct = reuslt as ObjectResult;
            Assert.IsType<Product>(prudoct.Value);

            moq.Setup(p => p.GetById(invalidid)).Returns(data.GetAll().FirstOrDefault(p => p.Id == invalidid));

            var resultinvalid = productApi.Get(invalidid);
            Assert.IsType<NotFoundResult>(resultinvalid);
            
            
        }
        [Fact]
        public void Post_TEST()
        {
            var moq = new Mock<IProductServies>();
            ProductApiController controller = new ProductApiController(moq.Object);

            Product product = new Product()
            {
                Id=1,
                Name= "SHoshtar",
                Description="miladnamakiiii"
            };
            var pro = controller.Post(product);
            Assert.IsType<CreatedAtActionResult>(product.Id);
        }
        [Theory]
        [InlineData(1,-1)]
        public void DeleteAPi_TEst( int id , int invalidid)
        {
            var moq = new Mock<IProductServies>();
            MoqData data = new MoqData();
            moq.Setup(p => p.Remove(id));
            moq.Setup(p => p.GetById(id)).Returns(data.GetAll().FirstOrDefault(p=>p.Id==id));
            ProductApiController controller = new ProductApiController(moq.Object);

            var result = controller.Delete(id);
            Assert.IsType<OkResult>(result);
           
            var resultinvalid = controller.Delete(invalidid);
            Assert.IsType<NotFoundResult>(resultinvalid);



        }
    }
}
