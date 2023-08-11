using System;
using System.ComponentModel.DataAnnotations;

namespace MvcModel.Models
{
    [AttributeUsage(AttributeTargets.All)]
    public class NumberOverAttribute : ValidationAttribute
    {
        public NumberOverAttribute(int minimum)
        {
            MinNum = minimum;
        }

        public int MinNum { get; set; }

        public override bool IsValid(object value)
        {
            int testedNumber = (int)value;
            return testedNumber > MinNum;
        }
    }
}