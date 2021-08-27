using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.Controllers;
using Xunit;

namespace WebAppMvc.Test
{
    public  class HomeControllerTest
    { 
        [Fact]
        public void IndextTest()
        {
            ///arrange 
            HomeController Controler = new HomeController();

            ///act

            var result = Controler.Index();

            //assert

            Assert.IsType<ViewResult>(result);


        }
    }
}
