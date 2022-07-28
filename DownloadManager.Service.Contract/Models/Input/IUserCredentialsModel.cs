namespace DownloadManager.Service.Contract.Models.Input
{
    public interface IUserCredentialsModel
    {
        string Username { get; set; }
        string Password { get; set; }
    }
}
