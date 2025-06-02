using AppLauncher.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace AppLauncher.Services
{
    public class NavigationService(IServiceProvider serviceProvider) : INavigationService
    {
        private readonly IServiceProvider serviceProvider = serviceProvider;
        public Action<object>? OnNavigate { get; set; }

        public void NavigateTo<TViewModel>() where TViewModel : class
        {
            var vm = serviceProvider.GetRequiredService<TViewModel>();
            OnNavigate?.Invoke(vm);
        }
    }
}
