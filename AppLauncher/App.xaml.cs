using AppLauncher.Contracts;
using AppLauncher.Services;
using AppLauncher.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace AppLauncher
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // Registrar servicios
            services.AddSingleton<IAuthService, MockAuthService>();
            services.AddSingleton<IUpdateService, MockUpdateService>();
            services.AddSingleton<IDownloadService, MockDownloadService>();
            services.AddSingleton<IAppLaunchService, MockAppLaunchService>();
            services.AddSingleton<ISettingsService, MockSettingsService>();
            services.AddSingleton<INavigationService, NavigationService>();

            // Registrar ViewModels
            services.AddSingleton<NavigationViewModel>();
            services.AddTransient<LoginViewModel>();
            services.AddTransient<LauncherViewModel>();
            services.AddTransient<DownloadViewModel>();

            // Registrar la ventana principal
            services.AddSingleton<MainWindow>();
        }
    }
}