using System;
using System.Collections.Generic;

namespace NextBirthdayCRUD.Models.Repositories
{
    public interface IRepository : IDisposable
    {
        IEnumerable<Birthday> GetBirthdays();
        Birthday GetBirthdayById(int id);
        void InsertBirthday(Birthday birthday);
        void UpdateBirthday(Birthday birthday);
        void DeleteBirthday(Birthday birthday);
        void Save();
    }
}
