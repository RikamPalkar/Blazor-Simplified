using DependencyInjectionDemo.Services.Interfaces;

namespace DependencyInjectionDemo.Services
{
    public class ScopedService : IScopedService
    {
        private int _requestCount = 0;
        public int GetRequestCount()
        {
            return _requestCount++;
        }
    }
}
