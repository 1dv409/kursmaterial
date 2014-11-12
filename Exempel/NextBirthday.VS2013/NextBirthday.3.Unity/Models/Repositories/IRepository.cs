using System;
using System.Collections.Generic;

namespace NextBirthdayUnity.Models.Repositories
{
    public interface IRepository : IDisposable
    {
        IEnumerable<Birthday> GetBirthdays();
        void InsertBirthday(Birthday birthday);
        void Save();
    }
}
