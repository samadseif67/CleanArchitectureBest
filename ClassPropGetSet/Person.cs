using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPropGetSet
{
    public class Person
    {
        public string name { get; set; }
        public string family { get; set; }
        private int _age { get; set; }

        public Person(string name, string family, int age)
        {
            this.name = name;
            this.family = family;
            this.age = age;
        }

        public int age
        {
            get { return _age; }//when read
            set
            {
                if (value > 18)
                {
                    _age = 0;
                }
                else
                {
                    _age = value;
                }
            }//when wite
        }

    }
}
