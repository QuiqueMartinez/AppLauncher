
using AppLauncher.Contracts;

namespace AppLauncher.Services
{

    public class MockUpdateService : IUpdateService
    {
        private string installedVersion = "1.0.0";

        public string GetInstalledVersion()
        {
            return installedVersion;
        }

        public async Task<VersionInfo> GetLatestVersionAsync()
        {
            await Task.Delay(500);

            return new VersionInfo(
                VersionNumber: "1.1.0",
                DownloadUrl: "https://example.com/launcher/download",
                ExpectedHash: "ABC123DEF456"
            );
        }

        public void SetInstalledVersion(string versionNumber)
        {
            installedVersion = versionNumber;
        }
    }
}
