using CommunityToolkit.Mvvm.ComponentModel;
using AppLauncher.Services;
using AppLauncher.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace AppLauncher.ViewModels
{
    public partial class NavigationViewModel : ObservableObject
    {
        [ObservableProperty]
        private object currentView;

        private readonly INavigationService navigationService;
        private readonly IServiceProvider serviceProvider;

        public NavigationViewModel(INavigationService navigationService, IServiceProvider serviceProvider)
        {
            this.navigationService = navigationService;
            this.serviceProvider = serviceProvider;

            navigationService.OnNavigate = vm => CurrentView = vm;

            // Load fisrt view
            navigationService.NavigateTo<LoginViewModel>();
        }
    }
}