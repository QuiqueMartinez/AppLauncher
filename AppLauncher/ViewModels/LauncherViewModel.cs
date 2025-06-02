using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AppLauncher.Contracts;
using System.Threading.Tasks;
using System;
using System.Windows;

namespace AppLauncher.ViewModels
{
    public partial class LauncherViewModel : ObservableObject
    {
        private readonly IUpdateService updateService;
        private readonly IDownloadService downloadService;
        private readonly IAppLaunchService appLaunchService;
        private readonly IAuthService authService;
        private readonly INavigationService navigationService;

        public LauncherViewModel(
            IUpdateService updateService,
            IDownloadService downloadService,
            IAppLaunchService appLaunchService,
            IAuthService authService,
            INavigationService navigationService)
        {
            this.updateService = updateService;
            this.downloadService = downloadService;
            this.appLaunchService = appLaunchService;
            this.authService = authService;
            this.navigationService = navigationService;

            LoadVersions();
        }

        [ObservableProperty] private string installedVersion = string.Empty;
        [ObservableProperty] private string latestVersion = string.Empty;
        [ObservableProperty] private bool isUpdateAvailable;
        [ObservableProperty] private bool isDownloading;
        [ObservableProperty] private double downloadProgress;

        private void LoadVersions()
        {
            InstalledVersion = updateService.GetInstalledVersion();

            Task.Run(async () =>
            {
                var latest = await updateService.GetLatestVersionAsync();
                LatestVersion = latest.VersionNumber;

                IsUpdateAvailable = InstalledVersion != latest.VersionNumber;
            });
        }


        [RelayCommand]
        private void LaunchApp()
        {
            appLaunchService.LaunchApp("", LatestVersion);
        }

        [RelayCommand]
        private void Logout()
        {
            authService.LogoutAsync();
            navigationService.NavigateTo<LoginViewModel>();
        }

        [RelayCommand]
        private void NavigateToDownload()
        {
            authService.LogoutAsync();
            navigationService.NavigateTo<DownloadViewModel>();
        }
    }
}
