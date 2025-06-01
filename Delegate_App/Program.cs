using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();

            //روش اول
            //delegate
            //program.Test(program.Sum);
            //program.Test(program.Differentiation);
            //program.Test((A, B) => A + B);


            //روش دوم
            //Func
            //program.Test2(program.Sum);

            //روش سوم
            //Action
            program.Test3(program.Nothing);


            Console.ReadKey();
        }

        //*************************************************************************************
        //روش اول
        public delegate int SumTest(int A, int B);
        public void Test(SumTest sumTest)
        {
            Console.WriteLine(sumTest(10, 15));
        }
        public int Sum(int A, int B)
        {
            return A + B;
        }
        public int Differentiation(int A, int B)
        {
            return A - B;
        }
        //***************************************************************************************
        //روش دوم
        //در مثال پایین دو تا ورودی صحیح و یک خروجی صحیح برمیگرداند
        //و تابعی که بعنوان ورودی به این متد ارسال میشود باید دو تا ورودی و یک خروجی داشته باشد
        public void Test2(Func<int, int, int> func1)
        {
            var number = func1(14, 18);
            Console.WriteLine(number);
        }

        //***************************************************************************************
        //روش سوم
        //در این روش ورودی تابع داریم اما خروجی نداریم

        public void Test3(Action<int, int> action)
        {

            action(10, 12);
        }

        public void Nothing(int A, int B)
        {
            Console.WriteLine(A + B);
        }



        //**************************************************************************************
     




    }
}
