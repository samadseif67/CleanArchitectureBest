using HangFire_App.JobServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace HangFire_App.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpPost]
        public ActionResult GetNamespaceFromClassName()
        {
            Type type = typeof(MyJobs);
            string namespaceName = type.Namespace;
            return Ok(namespaceName);
        }

        [HttpPost]
        public ActionResult GetNamespaceFromClassNameString()
        {
            string className = "MyJobs";
            Assembly targetAssembly = Assembly.Load("HangFire_App");
            Type foundType = targetAssembly.GetTypes().FirstOrDefault(t => t.Name == className);
            string namespaceName = foundType.Namespace;
            return Ok(foundType);
        }

        
    }
}
