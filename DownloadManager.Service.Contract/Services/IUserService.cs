using DownloadManager.Service.Contract.Models.Input;

namespace DownloadManager.Service.Contract
{
    public interface IUserService
    {
        void RegisterUser(IUserCredentialsModel model);
        bool CheckCredentials(IUserCredentialsModel model);
        int GetUserIdByUsername(string username);
    }
}
