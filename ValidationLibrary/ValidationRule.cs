using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationLibrary
{
    public abstract class ValidationRule
    {
        public string ErrorMessage { get; set; }

        public ValidationRule(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public abstract bool Validate(string value);
    }
    public class RequiredRule : ValidationRule
    {
        public RequiredRule(string errorMessage) : 
            base(errorMessage) { }

        public override bool Validate(string value)
        {
            return !string.IsNullOrEmpty(value);
        }
    }
    public class MinLengthRule : ValidationRule
    {
        public int MinLength { get; set; }

        public MinLengthRule(int minLength, string errorMessage) : base(errorMessage)
        {
            MinLength = minLength;
        }

        public override bool Validate(string value)
        {
            return value != null && value.Length >= MinLength;
        }
    }
    public class MaxLengthRule : ValidationRule
    {
        public int MaxLength { get; set; }

        public MaxLengthRule(int maxLength, string errorMessage) : base(errorMessage)
        {
            MaxLength = maxLength;
        }

        public override bool Validate(string value)
        {
            return value != null && value.Length <= MaxLength;
        }
    }

}
