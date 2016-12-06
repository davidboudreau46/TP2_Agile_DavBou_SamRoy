using System;
using System.IO;
using System.Net.Http;
using app.web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.PlatformAbstractions;

namespace app.web.acceptanceTests
{
    public class AcceptanceTestsBase : IDisposable
    {
        private const string WEB_APP_PATH = "app.web/";
        private readonly TestServer _testServer;
        protected HttpClient HttpClient { get; }
        public AcceptanceTestsBase()
        {
            var accpetanceTestsBasePath = PlatformServices.Default.Application.ApplicationBasePath;

            var webAppContentPath = GetAbsoluteWebAppPath(accpetanceTestsBasePath, WEB_APP_PATH);
            var builder = new WebHostBuilder()
                .UseContentRoot(webAppContentPath)
                .UseStartup<Startup>();

            _testServer = new TestServer(builder);

            HttpClient = _testServer.CreateClient();
            HttpClient.BaseAddress = new Uri("http://localhost");
        }
        public void Dispose()
        {
            HttpClient.Dispose();
            _testServer.Dispose();
        }
        private string GetAbsoluteWebAppPath(string accpetanceTestsBasePath, string relativeWebAppPath)
        {
            var directoryInfo = new DirectoryInfo(accpetanceTestsBasePath);
            do
            {
                var solutionFileInfo = new DirectoryInfo(Path.Combine(directoryInfo.FullName, relativeWebAppPath));
                if (solutionFileInfo.Exists)
                    return Path.GetFullPath(Path.Combine(directoryInfo.FullName, relativeWebAppPath));
                directoryInfo = directoryInfo.Parent;
            } while (directoryInfo.Parent != null);

            throw new Exception($"Impossible de trouver le dossier de l'application web ({relativeWebAppPath})");
        }
    }
}
