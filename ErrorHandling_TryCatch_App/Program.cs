using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorHandling_TryCatch_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int i =Convert.ToInt32("A123");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.StackTrace);//شماره خطی که خطا داده است را چاپ میکند
                Console.WriteLine(ex.Message);//پیام خطا را نماش میدهد
                Console.ReadKey();
            }
        }
    }
}
