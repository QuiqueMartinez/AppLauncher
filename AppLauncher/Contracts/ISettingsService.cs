using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLauncher.Contracts
{
    public interface ISettingsService
    {
        void SaveSetting(string key, string value);
        string? LoadSetting(string key);
    }
}
