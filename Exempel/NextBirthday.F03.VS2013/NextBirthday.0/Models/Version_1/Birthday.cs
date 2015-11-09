using System;

namespace NextBirthday._0.Models.Version_1
{
    public class Birthday
    {
        public DateTime Birthdate { get; set; }
        public string Name { get; set; }

        public int Age
        {
            get
            {
                return this.NextBirthdayDate.Year - this.Birthdate.Year;
            }
        }

        public int DaysUntilNextBirthday
        {
            get
            {
                return (this.NextBirthdayDate - DateTime.Today).Days;
            }
        }

        public DateTime NextBirthdayDate
        {
            get
            {
                var nextBirthday = new DateTime(DateTime.Today.Year,
                    this.Birthdate.Month, this.Birthdate.Day);
                if (nextBirthday < DateTime.Today)
                {
                    nextBirthday = nextBirthday.AddYears(1);
                }

                return nextBirthday;
            }
        }
    }
}