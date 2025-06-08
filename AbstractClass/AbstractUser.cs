using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    public abstract class AbstractUser
    {
        public string name { get; set; } = "ali";
        public abstract string email { get; set; }

        public int sum(int a, int b)
        {
            return a + b;   
        }

        public abstract int Deffertion(int a, int b);//در صورتی که نیاز نباشد اینجا پیاده شود شود باید کلمه ابسترکت بقبل از نوع حروجی اضافه شود


    }


    public class Person : AbstractUser
    {
        public override string email { get; set; } = "ali@gmail.com";//حتما باید کلمه اورراید نوشته شود

        public override int Deffertion(int a, int b)
        {
            return a - b;
        }

        public new  int sum(int a, int b)//در صورتی که این تابع در بالا پیاده سازی شده باشد میتوانیم از کلمه نیو یا همان جدید قبل از خروجی تابع نوشت
        {
            return a + b+10;
        }

    }




}
