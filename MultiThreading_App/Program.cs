using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading_App
{
    public class Program
    {
        //مواقعی از مالتی ترید استفاده میکنیم که خط پایین وابستگی به خط بالا نداشته باشد
        static void Main(string[] args)
        {
            Program program = new Program();
            //program.FirstMethod();
            program.TwoMehtod();
            Console.ReadKey();

           

        }

        //روش اول
        public void FirstMethod()
        {
            Thread t1 = new Thread(MsgConsole);
            t1.Start();

            Thread t2 = new Thread(MsgConsole);
            t2.Start();


            Thread t3 = new Thread(MsgConsole);
            t3.Start();


            t1.Join();//ابتدا ترید های بالا انجام شود سپس کد های پایین
            t2.Join();
            t3.Join();


            Console.WriteLine("Test2");
        }

        public void MsgConsole()
        {
            Thread.Sleep(3000); 
            Console.WriteLine("Test1");
        }



        //*********************************************************
        //روش دوم
        public void TwoMehtod()
        {
            Task.Run(MsgConsole);
            Task.Run(MsgConsole);
            Task.Run(MsgConsole);


        }







    }
}
