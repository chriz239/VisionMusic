using System;
using System.Collections.Generic;
using System.Text;
using VisionWebService;
using Xunit;

namespace VisionTests.WebService.BackgroundWorker
{
    public class RepoScannerTests
    {
        [Fact]
        public void ScanReposTest()
        {
            RepoScanner repoScanner = new RepoScanner();
            repoScanner.DoWork(null);
        }

    }
}
