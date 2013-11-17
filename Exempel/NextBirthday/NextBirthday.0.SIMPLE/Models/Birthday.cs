using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NextBirthday.Models
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

        [ScaffoldColumn(false)]
        public int Age
        {
            get
            {
                return this.NextBirthdayDate.Year - this.Birthdate.Year;
            }
        }

        [ScaffoldColumn(false)]
        public int DaysUntilNextBirthday
        {
            get
            {
                return (this.NextBirthdayDate - DateTime.Today).Days;
            }
        }

        [ScaffoldColumn(false)]
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