using System;
using System.Collections.Generic;
using System.Linq;

namespace NextBirthdayEF.Models.Repositories
{
    public class EFRepository : IRepository
    {
        private GeekBirthdayEntities _entities = new GeekBirthdayEntities();

        public IEnumerable<Birthday> GetBirthdays()
        {
            return _entities.Birthdays.ToList();
        }

        public void InsertBirthday(Birthday birthday)
        {
            _entities.Birthdays.Add(birthday);
        }

        public void Save()
        {
            _entities.SaveChanges();
        }

        #region IDisposable

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _entities.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}