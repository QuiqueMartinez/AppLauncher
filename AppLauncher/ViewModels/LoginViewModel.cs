using AppLauncher.Contracts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppLauncher.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly IAuthService authService;
        private readonly INavigationService navigationService;
        private readonly IServiceProvider serviceProvider;

        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private string password;

        public LoginViewModel(
            IAuthService authService,
            INavigationService navigationService,
            IServiceProvider serviceProvider)
        {
            this.authService = authService;
            this.navigationService = navigationService;
            this.serviceProvider = serviceProvider;
        }
        
        [RelayCommand]
        private async Task LoginAsync()
        {
            var success = await authService.LoginAsync(Username, Password);

            if (success)
            {
                navigationService.NavigateTo<LauncherViewModel>();
            }
        }
    }
}