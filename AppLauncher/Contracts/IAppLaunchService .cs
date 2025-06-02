using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLauncher.Contracts
{
    public interface IAppLaunchService
    {
        public void LaunchApp(string executablePath, string version, string arguments = "");
    }
}
