using AppLauncher.Contracts;
using System;
using System.Threading.Tasks;

namespace AppLauncher.Services
{
    public class MockDownloadService : IDownloadService
    {
        public async Task DownloadFileAsync(string url, string destinationPath, IProgress<double> progress)
        {
            for (int i = 1; i <= 100; i++)
            {
                await Task.Delay(50); 
                progress?.Report(i);
            }
        }

        public bool VerifyFile(string filePath, string expectedHash)
        {
            return true; 
        }
    }
}

