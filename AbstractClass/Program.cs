using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Person person = new Person();
            int sum = person.sum(10, 20);
            Console.WriteLine(sum);
            Console.WriteLine(person.name);
            Console.WriteLine(person.email);
            Console.ReadKey();

        }
    }










}
