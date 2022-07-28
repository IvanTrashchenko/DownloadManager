using DownloadManager.Service.Contract.Models.Input;

namespace DownloadManager.Service.Models.Input
{
    public class UserCredentialsModel : IUserCredentialsModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
