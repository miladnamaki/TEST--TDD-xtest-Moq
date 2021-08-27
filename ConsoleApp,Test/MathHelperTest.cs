using Consolelinq;
using Consolelinq.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace ConsoleApp_Test
{
    public class MathHelperTest
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public MathHelperTest(ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
        }

        //[Fact(Skip ="برای بحث اموزش این رو غیر فعال کنید")]
        [Theory(Skip = "برای بحث اموزش این رو غیر فعال کنید")]
        [InlineData(10,20,30)]
        [InlineData(-5,-5,-10)]
        [InlineData(1000,1000,2000) ]
        public void JamTest ( int x , int y , int expected)
        {
            MathHelper mathHelper = new MathHelper();
            
           var result =   mathHelper.jam(x, y);

            Assert.Equal(expected, result);
            Assert.IsType<int>(result);

        }
        [Theory]
        [Trait("service","cart")]
        [MemberData(nameof(DataForTest.GetData),MemberType =typeof(DataForTest))]        
        public void MemberDAta ( int x , int y , int expected)
        {
            MathHelper mathHelper = new MathHelper();
            
           var result =   mathHelper.jam(x, y);
            _testOutputHelper.WriteLine("this is a Test ");
            _testOutputHelper.WriteLine(x.ToString());
            Assert.Equal(expected, result);
            Assert.IsType<int>(result);

        }
        [Theory]
        [Trait("Service","order")]
        [ClassData(typeof(MemberClassDatacs))]
        public void GETDATAOBJEct(int x, int y, int expected)
        {
            MathHelper mathHelper = new MathHelper();

            var result = mathHelper.jam(x, y);

            Assert.Equal(expected, result);
            Assert.IsType<int>(result);

        }
        
    }
}
