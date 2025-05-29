using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Execute_Dynamic_ActionService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpPost]
        public ActionResult InvokeMethod()
        {
            string fullClassName = "UserRepository";
            string methodName = "GetName";



            //Execute_Dynamic_ActionService  نام پروژه می باشد

            Assembly targetAssembly = Assembly.Load("Execute_Dynamic_ActionService");
            Type foundType = targetAssembly.GetTypes().FirstOrDefault(t => t.Name == fullClassName);
            string namespaceName = foundType.Namespace;
            fullClassName = namespaceName + "." + fullClassName + ", Execute_Dynamic_ActionService";


            Type type = Type.GetType(fullClassName);
            if (type == null)
                throw new Exception($"کلاس '{fullClassName}' یافت نشد.");

            // 2. متد مورد نظر را پیدا کن
            MethodInfo methodInfo = type.GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance);
            if (methodInfo == null)
                throw new Exception($"متود '{methodName}' در کلاس '{fullClassName}' یافت نشد.");

            // 3. یک نمونه از کلاس بساز
            object instance = Activator.CreateInstance(type);

            // 4. متد را فراخوانی کن (بدون پارامتر)
            object result = methodInfo.Invoke(instance, null);


            return Ok(result);
        }



        [HttpPost]
        public ActionResult InvokeMethodPerson()
        {
            string fullClassName = "UserRepository";
            string methodName = "GetFullname";
            string parameterClassName = "Execute_Dynamic_ActionService.Services.Person";


            var parameterValues = new object[]
             {
            new object[] { "FirstName", "علی" },
            new object[] { "LastName", "احمدی" }
             };


            //دریافت نوع پارامتر
            Type paramType = Type.GetType(parameterClassName);
            if (paramType == null)
                throw new Exception($"کلاس پارامتر '{parameterClassName}' یافت نشد.");
            //ساخت آبجکت پارامتر
            object instanceParam = Activator.CreateInstance(paramType);


            // 4️⃣ تنظیم پراپرتی‌ها
            foreach (var prop in paramType.GetProperties())
            {
                var value = Array.Find(parameterValues, v => v is object[] arr && (string)arr[0] == prop.Name);
                if (value is object[] valArray)
                {
                    object propValue = valArray[1];
                    prop.SetValue(instanceParam, Convert.ChangeType(propValue, prop.PropertyType));
                }
            }





            //Execute_Dynamic_ActionService  نام پروژه می باشد

            Assembly targetAssembly = Assembly.Load("Execute_Dynamic_ActionService");
            Type foundType = targetAssembly.GetTypes().FirstOrDefault(t => t.Name == fullClassName);
            string namespaceName = foundType.Namespace;
            fullClassName = namespaceName + "." + fullClassName + ", Execute_Dynamic_ActionService";


            Type type = Type.GetType(fullClassName);
            if (type == null)
                throw new Exception($"کلاس '{fullClassName}' یافت نشد.");

            // 2. متد مورد نظر را پیدا کن
            MethodInfo methodInfo = type.GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance, new[] { paramType });
            if (methodInfo == null)
                throw new Exception($"متود '{methodName}' در کلاس '{fullClassName}' یافت نشد.");

            // 3. یک نمونه از کلاس بساز
            object instance = Activator.CreateInstance(type);

            // 4. متد را فراخوانی کن (بدون پارامتر)
            object result = methodInfo.Invoke(instance, new object[] { instanceParam });


            return Ok(result);
        }



    }
}
