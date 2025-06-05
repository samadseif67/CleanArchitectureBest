using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifierPublicPrivate
{
    internal class Program
    {
        static void Main(string[] args)
        {



        }
    }


    public class Test1
    {
        public int A { get; set; }    //در تمام قسمت های پروژه و اسمبلی ها پروژه های دیگر قابل استفاده است
        private int B { get; set; }  //فقط در محدوده همین کلاس که تعریف شده است قابل استفاده هست
        internal int C { get; set; }  //در تمام قسمت های این پروژه قابل دسترس هست اما اگر بعنوان رفرنس در پروژه دیگر استفاده شود قابل دسترس نیست
        protected int D { get; set; } //فقط زمانی قابل دسترس هست که در یک کلاس دیگر از همین کلاس ارث بری شده باشد
    }
}
