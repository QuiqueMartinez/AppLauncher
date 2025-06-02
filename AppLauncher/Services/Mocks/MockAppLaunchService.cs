using AppLauncher.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppLauncher.Services
{
    internal class MockAppLaunchService : IAppLaunchService
    {

            public void LaunchApp(string executablePath, string version, string arguments = "")
            {
                MessageBox.Show($"Aplicación lanzada con versión {version}", "Launcher");
        }
        
    }
}
