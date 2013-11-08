using System;

namespace Hello.Models
{
    public class Salutation
    {
        public string Greeting
        {
            get
            {
                return DateTime.Now.Hour < 12 ?
                    "Good morning" : "Good afternoon";
            }
        }
    }
}