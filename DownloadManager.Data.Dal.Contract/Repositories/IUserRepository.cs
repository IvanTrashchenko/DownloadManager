using System.Collections.Generic;
using DownloadManager.Data.Dal.Contract.Dto;
using DownloadManager.Domain.Entities;

namespace DownloadManager.Data.Dal.Contract.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> Get();
        User GetById(int id);
        User GetByUsername(string username);
        void Add(UserDto userDto);
        void Update(User user);
        void Delete(int id);
    }
}
