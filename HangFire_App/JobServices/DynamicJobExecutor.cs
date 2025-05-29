using System.Reflection;

namespace HangFire_App.JobServices
{
    public class DynamicJobExecutor
    {
        private readonly IServiceProvider _serviceProvider;

        public DynamicJobExecutor(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Execute(string className, string methodName)
        {
            try
            {
                var type = Type.GetType(className);
                if (type == null)
                    throw new InvalidOperationException($"class '{className}' not found  .");

                var methodInfo = type.GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance);
                if (methodInfo == null)
                    throw new InvalidOperationException($"method '{methodName}' in class   '{className}'  not found   .");

                using (var scope = _serviceProvider.CreateScope())
                {
                    var service = scope.ServiceProvider.GetRequiredService(type);
                    methodInfo.Invoke(service, null); // بدون پارامتر
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
