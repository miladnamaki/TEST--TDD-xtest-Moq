using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.Models;
using Xunit;

namespace WebAppMvc.Test
{
    public class SumTest
    {
        [Theory()]
        [InlineData("1,2",3)]
        [InlineData("0",0)]
        [InlineData("",0)]
        [InlineData("30,50,20,",100)]
        public void Exeute_SumNumbers_when_StringNumber(string numbers , int expected)
        {
            //Arrange

            Sum sum = new Sum();
            //act
            var result = sum.Execute(numbers);
            // assert 
            Assert.Equal(expected, result);

        }

    }
}
