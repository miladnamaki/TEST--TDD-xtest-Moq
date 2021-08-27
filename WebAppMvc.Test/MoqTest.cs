using Moq;
using Moq.Protected;
using MoqMvc.Controllers;
using MoqMvc.Models;
using MoqMvc.Services;
using Xunit;

namespace WebAppMvc.Test
{
    public class MoqTest
    {
        [Fact]
        public void Test_MochBehavior()
        {
            // strick = bayad mock hatman setup dashte bahse  
            //lose  =  mock ehtiaji be setup nadarad 
            var moq = new Mock<IProductServiceMock>(MockBehavior.Strict);
            moq.Setup(p => p.GetProductPrice(1)).Returns(1500);
            var result = moq.Object.GetProductPrice(1);

        }
        [Fact]
        public void Tests_PropertySetupTest()
        {
            var moq = new Mock<IProductServiceMock>(MockBehavior.Strict);
            moq.Setup(p => p.Productcount).Returns(25);

        }
        [Fact]
        public void Test_ADD_Product_saveStat()
        {
            var moq = new Mock<IProductServiceMock>(MockBehavior.Strict);
            Product product = new Product()
            {
                Id = 1,
                Name = "test"

            };
            moq.Setup(p => p.Add(product)).Returns(product);
            moq.SetupProperty(p => p.Productcount);
            HomeMockController homeMock = new HomeMockController(moq.Object, null) ;
            homeMock.AddProduct(product);

            Assert.Equal(1, moq.Object.Productcount);
        }
        [Fact]
        public void Test_SetupSequence()
        {
            // baraye tavali anjam dadan yani returns bade har bar ejra ye meghdare dige ro bar migardone 
            var moq = new Mock<IProductServiceMock>(MockBehavior.Strict);
            moq.SetupSequence(p => p.GetProductPrice(1)).Returns(1500).Returns(2500).Returns(5000);
            var result = moq.Object.GetProductPrice(1);


        }

        public void TEst_ProtectedMock()
        {
            var moq = new Mock<CarService>();
            moq.Protected().Setup<int>("GetPrice").Returns(1500);

        }
        [Fact]
        public void Test_zt()
        {
            var moq = new Mock<IProductServiceMock>();
            int[] id = new int[] {1,2,250,2134,12 };
            moq.Setup(p => p.GetProductPrice(It.IsAny<int>())).Returns(1500);
            moq.Setup(p => p.GetProductPrice(It.IsInRange(1, 100, Moq.Range .Exclusive))).Returns(1250);//adade aval va akharo dar nazar nemigire 
            moq.Setup(p => p.GetProductPrice(It.IsInRange(1, 100, Moq.Range.Inclusive))).Returns(1250);//adad aval va akhar ro dar nazar migire 
            moq.Setup(p => p.GetProductPrice(It.IsNotIn(id))).Returns(0);
            moq.Setup(p => p.GetProductPrice(It.IsIn(id))).Returns(1);



        }
        [Fact]
        public void Test_GetPrice()
        {
            var moq = new Mock<IProductServiceMock>();
            int price = 0;
            moq.Setup(p => p.GetProductPrice(1, out price));
        }

        [Fact]
        public void Test_ChainTEsT()
        {
            var moq = new Mock<IProductServiceMock>();
            //moq.Setup(p => p.BrandId.BrandId).Returns(150);
            moq.Setup(p => p.brandIDProxy.BrandId.BrandId).Returns(150);

        }
        [Fact]
        public void TEst_Behiver_sendMesage()
        {
            var moq = new Mock<IMessage>();
            HomeMockController controller = new HomeMockController(null, moq.Object);

            controller.Message("salam", 2, Message.MEssageType.Email);
           //moq.Verify(p => p.Sms(It.IsAny<string>(), It.IsAny<int>()), "اس ام اس ارسال نشد "); // chek mikone bebine email ejra shude ya na 2ta vorodi b/*a it  frestade shud 
            moq.Verify(p => p.Sms(It.IsAny<string>(), It.IsAny<int>()),Times.AtLeast(2)); // tedad dafato neshon mide 

        }
    }
}
