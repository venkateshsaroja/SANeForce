using System;
using System.Collections.Generic;

namespace ValidationLibrary
{
    public class Validator
    {
        private Dictionary<string, List<ValidationRule>> _validationRules = new Dictionary<string, List<ValidationRule>>();

        public void AddRule(string fieldName, ValidationRule rule)
        {
            if (!_validationRules.ContainsKey(fieldName))
            {
                _validationRules[fieldName] = new List<ValidationRule>();
            }
            _validationRules[fieldName].Add(rule);
        }

        public ValidationResult Validate(Dictionary<string, string> data)
        {
            var validationResult = new ValidationResult();

            foreach (var field in _validationRules)
            {
                var fieldName = field.Key;
                var rules = field.Value;
                var value = data.ContainsKey(fieldName) ? data[fieldName] : null;

                foreach (var rule in rules)
                {
                    if (!rule.Validate(value))
                    {
                        validationResult.IsValid = false;
                        validationResult.Errors[fieldName] = rule.ErrorMessage;
                    }
                }
            }

            return validationResult;
        }
    }
}
