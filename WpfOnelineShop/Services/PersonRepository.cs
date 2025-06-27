using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfOnelineShop.Services
{
    public class PersonRepository
    {

        //تفاوت ObservableCollection با list
        //وقتی به یک لیست داده ای اضافه میشود و بخواهیم در یک گرید نمایش داده شود باید دو باره عملیات رفرش انجام شود
        //اما در ابزروبل کالکشن بمحض اینکه دادهی اضافه شود خودش به گرافیک یا همان سمت فرانت اطلاع میدهد که رفرش شود مثلا به دیتا گرید اطلاع میدهد که رفرش شود




        public ObservableCollection<Person> LstPerson { get; set; } = new ObservableCollection<Person>();
        public PersonRepository()
        {
            LstPerson.Add(new Person()
            {
                Id = 1,
                Name = "mohamad",
                Family = "nasri"
            });
            LstPerson.Add(new Person()
            {
                Id = 2,
                Name = "rahim",
                Family = "rahimi"
            });
            LstPerson.Add(new Person()
            {
                Id = 3,
                Name = "ali",
                Family = "alimoradi"
            });
        }

        public void AddPerson(Person person)
        {
            person.Id = LstPerson.Count() == 0 ? 1 : LstPerson.Max(x => x.Id) + 1;
            LstPerson.Add(person);
        }
        public void EditPerson(Person personold,Person person)
        {
            int indexnumber = LstPerson.IndexOf(personold);
            LstPerson[indexnumber] = person;

        }
        public Person GetPerson(int PersonId)
        {
            var result = LstPerson.FirstOrDefault(x => x.Id == PersonId);
            return result;
        }

        public ObservableCollection<Person> GetAllPerson()
        {
            var result = LstPerson;
            return result;
        }
        public void DeletePerson(Person person)
        {
            LstPerson.Remove(person);    
        }

    }
}
