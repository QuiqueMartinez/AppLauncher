using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLauncher.Contracts
{
    public record VersionInfo(
        string VersionNumber,
        string DownloadUrl,
        string ExpectedHash
    );

    public interface IUpdateService
    {
        Task<VersionInfo> GetLatestVersionAsync();
        string GetInstalledVersion();
        void SetInstalledVersion(string versionNumber);
    }
}
