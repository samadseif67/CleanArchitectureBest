using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfOnelineShop.Services;

namespace WpfOnelineShop
{
   
    public partial class PersonWindow : Window
    {
        PersonRepository PersonRepository;
        Person Person;
        public PersonWindow(PersonRepository personRepository, Person person)
        {
            InitializeComponent();
            PersonRepository = personRepository;
            Person = person;

            Txt_FirstName.Text = person.Name;
            Txt_LastName.Text = person.Family;
        }



        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            Person person1 = new Person();
            person1.Id = Person.Id;
            person1.Name = Txt_FirstName.Text;
            person1.Family = Txt_LastName.Text;


            bool isValidate = true;

            if(Txt_FirstName.Text.Trim().Length==0 && isValidate)
            {
                Label_ValidationPerson.Content = "please a enter name";
                isValidate = false;
            }
            if (Txt_LastName.Text.Trim().Length == 0 && isValidate)
            {
                Label_ValidationPerson.Content = "please a enter lastname";
                isValidate = false;
            }

            if(isValidate)
            {
                if (Person.Id == 0)
                {
                    PersonRepository.AddPerson(person1);
                }
                else
                {
                    PersonRepository.EditPerson(Person, person1);
                }
                this.Close();
            }
         
        }
    }
}
