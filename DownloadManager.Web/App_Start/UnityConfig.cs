using DownloadManager.Data.Dal.Contract.Repositories;
using DownloadManager.Data.Dal.Repositories;
using DownloadManager.Service.Contract;
using DownloadManager.Service.Services;
using DownloadManager.Service;
using System.Web.Http;
using Unity;
using Unity.WebApi;
using DownloadManager.Web.FilterProvider;
using System.Linq;
using System.Web.Http.Filters;
using DownloadManager.Web.Logging;

namespace DownloadManager.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IFileRepository, FileRepository>(TypeLifetime.Scoped);
            container.RegisterType<IUserRepository, UserRepository>(TypeLifetime.Scoped);
            container.RegisterType<IFileService, FileService>(TypeLifetime.Scoped);
            container.RegisterType<IUserService, UserService>(TypeLifetime.Scoped);
            container.RegisterType<ILogger, InMemoryLogger>(TypeLifetime.Scoped);

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

            // Register my Custom Filter Provider in order to use dependecy injection in auth filter
            var providers = GlobalConfiguration.Configuration.Services.GetFilterProviders().ToList();
            GlobalConfiguration.Configuration.Services.Add(typeof(System.Web.Http.Filters.IFilterProvider), new UnityFilterAttributeFilterProvider(container));
            var defaultprovider = providers.First(i => i is ActionDescriptorFilterProvider);
            GlobalConfiguration.Configuration.Services.Remove(typeof(System.Web.Http.Filters.IFilterProvider), defaultprovider);
        }
    }
}