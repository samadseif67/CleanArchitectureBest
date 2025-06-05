using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPropGetSet
{
    public class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("ali", "mohamadi", 18);
            Person person2 = new Person("naser", "mohamadi", 19);

            Console.Write("\t"+person1.name);
            Console.Write("\t" + person1.family);
            Console.Write("\t" + person1.age);

            Console.WriteLine();

            Console.Write("\t" + person2.name);
            Console.Write("\t" + person2.family);
            Console.Write("\t" + person2.age);

            Console.ReadKey();
        }
    }
}
