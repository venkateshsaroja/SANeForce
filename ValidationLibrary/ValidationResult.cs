using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationLibrary
{
    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public Dictionary<string, string> Errors { get; set; }

        public ValidationResult()
        {
            Errors = new Dictionary<string, string>();
            IsValid = true;
        }
    }
}
