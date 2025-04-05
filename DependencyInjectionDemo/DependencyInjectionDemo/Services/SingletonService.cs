using DependencyInjectionDemo.Services.Interfaces;

namespace DependencyInjectionDemo.Services
{
    public class SingletonService : ISingletonService
    {
        private readonly DateTime _startTime;
        public SingletonService()
        {
            _startTime = DateTime.Now;
        }
        public DateTime GetApplicationStartTime()
        {
            return _startTime;
        }
    }
}
