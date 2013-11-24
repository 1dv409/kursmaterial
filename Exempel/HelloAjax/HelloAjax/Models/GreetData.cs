using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelloAjax.Models
{
    public class GreetData
    {
        [Required]
        public string Greeting { get; set; }
    }
}