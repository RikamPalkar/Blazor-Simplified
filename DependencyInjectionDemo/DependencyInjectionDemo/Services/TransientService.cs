using DependencyInjectionDemo.Services.Interfaces;

namespace DependencyInjectionDemo.Services
{
    public class TransientService : ITransientService
    {
        public string GenerateUniqueId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
