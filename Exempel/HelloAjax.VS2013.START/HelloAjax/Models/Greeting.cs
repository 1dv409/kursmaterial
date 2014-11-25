using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelloAjax.Models
{
    public class Greeting
    {
        [Required(ErrorMessage="Du måste skriva en hälsning.")]
        [MustBeEvenNumberOfCharacters(ErrorMessage="Hälsningen måste innehålla ett jämt antal tecken.")]
        [Display(Name="Hälsning", Prompt="Skriv en hälsning här")]
        public string Message { get; set; }
    }
}