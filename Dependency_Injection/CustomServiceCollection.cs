using Dependency_Injection.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Dependency_Injection
{
    public class CustomServiceCollection
    {
        public CustomServiceCollection()
        {
            IServiceCollection services = new ServiceCollection(); // Bu bizim dahili ioc mekanizmamız.
            // Custom servis eklemek istediğimizde .Add fonksiyonunu kullanabiliyoruz.
            services.Add(new ServiceDescriptor(typeof(ConsoleLog),new ConsoleLog()));
            services.Add(new ServiceDescriptor(typeof(TextLog),new TextLog()));
        }
    }
}
