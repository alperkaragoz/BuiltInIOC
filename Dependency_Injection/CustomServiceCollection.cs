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
            services.Add(new ServiceDescriptor(typeof(ConsoleLog), new ConsoleLog(10)));
            services.Add(new ServiceDescriptor(typeof(TextLog), new TextLog()));

            // Eklenmiş değerleri aşağıdaki gibi elde edebiliyoruz.

            //İlgili container ı direkt olarak somut bir şekilde oluşturur ve içine istediğimiz servisleri çağırır.
            ServiceProvider provider = services.BuildServiceProvider();
            provider.GetService<ConsoleLog>();
            provider.GetService<TextLog>();
        }
    }
}
