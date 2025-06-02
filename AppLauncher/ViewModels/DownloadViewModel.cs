using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AppLauncher.Contracts;

namespace AppLauncher.ViewModels
{
    public partial class DownloadViewModel : ObservableObject
    {
        private readonly IDownloadService downloadService;
        private readonly IUpdateService updateService;
        private readonly INavigationService navigationService;

        public DownloadViewModel(
            IDownloadService downloadService,
            IUpdateService updateService,
            INavigationService navigationService)
        {
            this.downloadService = downloadService;
            this.updateService = updateService;
            this.navigationService = navigationService;
        }

        [ObservableProperty] private double downloadProgress;
        [ObservableProperty] private bool isDownloading;

        [RelayCommand]
        public async Task StartDownloadAsync()
        {
            IsDownloading = true;
            DownloadProgress = 0;

            var progress = new Progress<double>(p => DownloadProgress = p);

            await downloadService.DownloadFileAsync("mockUrl", "mockPath", progress);

            IsDownloading = false;

            var latest = await updateService.GetLatestVersionAsync();
            updateService.SetInstalledVersion(latest.VersionNumber);

            navigationService.NavigateTo<LauncherViewModel>();
        }

        [RelayCommand]
        private void NavigateToLauncher()
        {
            navigationService.NavigateTo<LauncherViewModel>();
        }
    }
}
