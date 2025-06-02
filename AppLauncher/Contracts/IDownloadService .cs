using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLauncher.Contracts
{
    public interface IDownloadService
    {
        Task DownloadFileAsync(string url, string destinationPath, IProgress<double> progress);
        bool VerifyFile(string filePath, string expectedHash);
    }
}
