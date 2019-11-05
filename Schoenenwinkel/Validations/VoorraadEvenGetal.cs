using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Schoenenwinkel.Validations
{
    public class VoorraadEvenGetalAttribute : ValidationAttribute
    {
        public VoorraadEvenGetalAttribute()
        {
            ErrorMessage = "Voer een getal deelbaar door 2 in.";
        }
        public override bool IsValid(object value)
        {
            if (value is int)
            {
                return (int)value % 2 != 1;
            }
            return false;
        }
    }
}