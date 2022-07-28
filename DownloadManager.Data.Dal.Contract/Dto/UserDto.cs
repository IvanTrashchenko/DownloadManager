namespace DownloadManager.Data.Dal.Contract.Dto
{
    public class UserDto
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
    }
}
