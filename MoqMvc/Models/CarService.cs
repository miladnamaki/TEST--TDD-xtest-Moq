using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoqMvc.Models
{
    public class CarService
    {
        protected virtual int GetPrice()
        {
            return 2500;

        }
    }
}
