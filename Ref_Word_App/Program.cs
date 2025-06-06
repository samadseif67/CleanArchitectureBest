using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ref_Word_App
{
    internal class Program
    {
        //وقتی از رف استفاده می‌کنی، متغییر واقعی   به متد منتقل می‌شود. بنابراین، هر تغییری روی آن متغییر درون متد، روی متغییر اصلی هم اعمال خواهد شد.

        static void Main(string[] args)
        {
            Program program = new Program();
           // program.MethodwithRef();
            program.MethodwithOutRef();
        }


        //***************************************************************************************************

        public void MethodwithRef()
        {
            Program program = new Program();
            person person = new person();
            person.name = "A1";
            Console.WriteLine(person.name);//A1


            program.ChangePerson(ref person);

            Console.WriteLine(person.name);//A2

            Console.ReadKey();
        }


        //وقتی هر تغییری داخل این تابع انجام شود روی متغییر اصلی که ورودی هست تاثیر میگذارد
        //اتفاق بالا چه رف داشته باشد و چه نداشته باشد باعث تغییر در تابع بالا میشود
        public void ChangePerson(ref person person)
        {
            person.name = "A2";
        }
        //************************************************************************************************

        //متد های بدون رف باید به صورتی طراحی شود که آبجکت ارسال شونده به تابغ دیگر در تابع اصلی تغییر نکند بنابرابن یک کپی باید از آن ارسال کرد
        public void MethodwithOutRef()
        {
            Program program = new Program();
            person person = new person();
            person.name = "A1";
            Console.WriteLine(person.name);//A1

            person person1= program.DeepCopy(person);//برای اینکه تعییرات تابع روی متغییر اصلی تاثیر نگذارد باید یک کپی عمیق بگیریم
            program.ChangePersonwithOutRef(person1);

            Console.WriteLine(person.name);//A1

            Console.ReadKey();
        }

        public void ChangePersonwithOutRef(person person)
        {
            person.name = "A2";
        }
        person DeepCopy(person obj)
        {
            var json = JsonSerializer.Serialize(obj);
            return JsonSerializer.Deserialize<person>(json);
        }







    }




    public class person
    {
        public int ID { get; set; }
        public string name { get; set; }
    }




}
