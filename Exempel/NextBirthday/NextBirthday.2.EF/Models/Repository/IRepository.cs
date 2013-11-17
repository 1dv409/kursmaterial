using System;
using System.Collections.Generic;

namespace NextBirthday.Models.Repository
{
    public interface IRepository : IDisposable
    {
        IEnumerable<Birthday> GetBirthdays();
        void InsertBirthday(Birthday birthday);
        void Save();
    }
}
