using Microsoft.AspNetCore.Mvc;
using Moq;
using MvcTest.Controllers;
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
    public class ProductControllerTest
    {
        [Fact]
        public void Index_Test()
        {
            //Arange
            //List<Product> products = new List<Product>()
            //{
            //     new Product { Id=1, Description ="x"
            //     , Name="Iphone x " , Price=1500}
            //};
            MoqData moqData = new MoqData();
            var moq = new Mock<IProductServies>();
            moq.Setup(p=>p.GetALL()).Returns(moqData.GetAll());
            ProductController productController = new ProductController(moq.Object);
            //act
            var result = productController.Index();

            //asert
            Assert.IsType<ViewResult>(result);
            var viewresult = result as ViewResult; ///tabdil kard be view result
            Assert.IsAssignableFrom<List<Product>>(viewresult.Model);
        }   
        [Theory]
        [InlineData(2,-2)]
        public void Details_Test(int validId , int inValidId)
        {
            //arrang
            MoqData moqData = new MoqData();
            var moq = new Mock<IProductServies>();
            moq.Setup(p => p.GetById(validId)).Returns(moqData.GetAll().FirstOrDefault(p=>p.Id== validId));
            ProductController productController = new ProductController(moq.Object);
            //act
            var result = productController.Details(validId);
            //asser
            Assert.IsType<ViewResult>(result);
            var viewresult = result as ViewResult;

            Assert.IsAssignableFrom<Product>(viewresult.Model);
            //----

            //arrang 
            moq.Setup(p => p.GetById(inValidId)).Returns(moqData.GetAll().FirstOrDefault(p => p.Id == inValidId));
            //act
            var isvalidresult = productController.Details(inValidId)  ;
            

            //assert
            Assert.IsType<NotFoundObjectResult>(isvalidresult);
        }
        [Fact]
        public void Create_Test()
        {
            //arreng
            var moq = new Mock<IProductServies>();


            ProductController productController =
                new ProductController(moq.Object);
            Product product = new Product()
            {
                Id = 2,
                Description = "xx",
                Name = " samsung",
                Price = 4500,
            };
            //act
            var result = productController.Create(product);

            //assert
            var redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirect.ActionName);
            Assert.Null(redirect.ControllerName);

            //areange 

            Product invalidProduct = new Product()
            {
                Price = 5,
            };

            productController.ModelState.AddModelError("Name", "نام را وارد کنید ");

            //act 
            var invalidresult = productController.Create(invalidProduct);
            //asser
            Assert.IsType<BadRequestObjectResult>(invalidresult);


        }
        [Theory]
        [InlineData(2 ,-5)]
        public void Delete_Test(int invalid , int isnotvalid)
        {
            //arreng 
            MoqData moqData = new MoqData();
            var mock = new Mock<IProductServies>();
            mock.Setup(p => p.Remove(invalid));
            ProductController productController = new ProductController(mock.Object);

            var prudoct = productController.Delete(invalid);

            Assert.IsType<ViewResult>(prudoct);

            //
            mock.Setup(p => p.Remove(isnotvalid));
            ProductController controller = new ProductController(mock.Object);
            var nullablee = controller.Delete(isnotvalid);
            Assert.IsNotType<Product>(nullablee);

        }
    }
}
