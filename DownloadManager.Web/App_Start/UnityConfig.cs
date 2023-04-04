using DownloadManager.Data.Dal.Contract.Repositories;
using DownloadManager.Data.Dal.Repositories;
using DownloadManager.Service.Contract;
using DownloadManager.Service.Services;
using DownloadManager.Service;
using System.Web.Http;
using Unity;
using Unity.WebApi;

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

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}