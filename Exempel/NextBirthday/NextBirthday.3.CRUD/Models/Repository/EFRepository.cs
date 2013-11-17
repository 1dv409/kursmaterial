using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NextBirthday.Models.DataModels;

namespace NextBirthday.Models.Repository
{
    public class EFRepository : IRepository
    {
        private GeekBirthdayEntities _entities = new GeekBirthdayEntities();

        #region IRepository Members

        public IEnumerable<Birthday> GetBirthdays()
        {
            return _entities.Birthdays.ToList();
        }

        public Birthday GetBirthdayById(int birthdayId)
        {
            return _entities.Birthdays.Find(birthdayId);
        }

        public void InsertBirthday(Birthday birthday)
        {
            _entities.Birthdays.Add(birthday);
        }

        public void DeleteBirthday(int birthdayId)
        {
            var entity = _entities.Birthdays.Find(birthdayId);
            _entities.Birthdays.Remove(entity);
        }

        public void UpdateBirthday(Birthday birthday)
        {
            _entities.Entry(birthday).State = EntityState.Modified;
        }

        public void Save()
        {
            _entities.SaveChanges();
        }

        #endregion

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