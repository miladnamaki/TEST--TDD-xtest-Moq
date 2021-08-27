using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoqMvc.Models;
using MoqMvc.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static MoqMvc.Services.Message;

namespace MoqMvc.Controllers
{
    public class HomeMockController : Controller
    {
        private readonly IProductServiceMock _mockserivec;
        private readonly IMessage _mess ;
        public HomeMockController(IProductServiceMock mockserivec, IMessage mess)
        {
            _mockserivec = mockserivec;
            _mess = mess;
        }


        public IActionResult AddProduct(Product product)
        {
            _mockserivec.Add(product);
            _mockserivec.Productcount += 1;
            return View();
        }

        public IActionResult Message(string message ,int Userid, MEssageType type )
        {
            switch (type)
            {
                case MEssageType.Sms:
                    _mess.Sms(message, Userid);
                    break;
                case MEssageType.Email:
                    _mess.Email(message, Userid);
                    break;
                case MEssageType.Notif:
                    _mess.Notif(message, Userid);
                    break;
               
            }

            return Json(true);

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
