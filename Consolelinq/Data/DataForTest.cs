using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolelinq.Data
{
    public static class DataForTest
    {
        public static  List<object[]> GetData()
         {
            List<object[]> myData = new List<object[]>();
            myData.Add(new object[] { 7, 13, 20 });
            myData.Add(new object[] { 357,350,707 });
            myData.Add(new object[] { 1300,1200,2500 });

            return myData;
         } 

    }
}
