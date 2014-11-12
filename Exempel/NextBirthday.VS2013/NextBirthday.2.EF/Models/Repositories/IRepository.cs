using System;
using System.Collections.Generic;

namespace NextBirthdayEF.Models.Repositories
{
    public interface IRepository : IDisposable
    {
        IEnumerable<Birthday> GetBirthdays();
        void InsertBirthday(Birthday birthday);
        void Save();
    }
}
