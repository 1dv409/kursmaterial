using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NextBirthday._0.Models.Version_4
{
    public class Birthday
    {
        [Required(ErrorMessage = "Födelsedatum måste anges.")]
        [DataType(DataType.Date)]
        [DisplayName("Födelsedatum")]
        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = "Namn måste anges.")]
        [DisplayName("Namn")]
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