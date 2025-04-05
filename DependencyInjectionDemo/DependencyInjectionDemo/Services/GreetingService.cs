using DependencyInjectionDemo.Services.Interfaces;

namespace DependencyInjectionDemo.Services
{
    public class GreetingService(string greetingTemplate) : IGreetingService
    {
        private readonly string _greetingTemplate = greetingTemplate;

        public string GetGreeting(string name)
        {
            return string.Format(_greetingTemplate, name);
        }
    }
}
