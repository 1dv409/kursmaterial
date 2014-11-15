using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace NextBirthdayCRUD.Models.Repositories
{
    public class EFRepository : IRepository
    {
        private readonly GeekBirthdayEntities _entities = new GeekBirthdayEntities();

        public IEnumerable<Birthday> GetBirthdays()
        {
            return _entities.Birthdays.ToList();
        }

        public Birthday GetBirthdayById(int id)
        {
            return _entities.Birthdays.Find(id);
        }

        public void InsertBirthday(Birthday birthday)
        {
            _entities.Birthdays.Add(birthday);
        }

        public void UpdateBirthday(Birthday birthday)
        {
            if (_entities.Entry(birthday).State == EntityState.Detached)
            {
                _entities.Birthdays.Attach(birthday);
            }

            _entities.Entry(birthday).State = EntityState.Modified;
        }

        public void DeleteBirthday(Birthday birthday)
        {
            if (_entities.Entry(birthday).State == EntityState.Detached)
            {
                _entities.Birthdays.Attach(birthday);
            }

            _entities.Birthdays.Remove(birthday);
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