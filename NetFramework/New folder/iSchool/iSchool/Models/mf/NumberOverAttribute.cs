using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace iSchool.Models.mf
{
    internal class NumberOverAttribute : ValidationAttribute
    {
        public int MinNum { get; set; }
        public NumberOverAttribute(int minimum)
        {
            MinNum = minimum;
        }

        public override bool IsValid(Object value)
        {
            var testedNumber = (int)value;
            if (testedNumber > MinNum)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}