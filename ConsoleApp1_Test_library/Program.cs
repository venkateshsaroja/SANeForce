using System;
using System.Collections.Generic;
using ValidationLibrary;
using Newtonsoft.Json;

namespace ValidationConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var validator = new Validator();

            validator.AddRule("firstName", new RequiredRule("First name is required"));
            validator.AddRule("firstName", new MinLengthRule(2, "First name must be at least 2 characters"));
            validator.AddRule("firstName", new MaxLengthRule(50, "First name should not exceed 50 characters"));

            validator.AddRule("lastName", new RequiredRule("Last name is required"));
            validator.AddRule("lastName", new MinLengthRule(2, "Last name must be at least 2 characters"));
            validator.AddRule("lastName", new MaxLengthRule(100, "Last name should not exceed 100 characters"));

            Console.WriteLine("Please enter your first name:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Please enter your last name:");
            string lastName = Console.ReadLine();

            var data = new Dictionary<string, string>
            {
                { "firstName", firstName },
                { "lastName", lastName }
            };

            var validationResult = validator.Validate(data);

            var output = new
            {
                isValid = validationResult.IsValid,
                errors = validationResult.Errors
            };

            string jsonResult = JsonConvert.SerializeObject(output, Formatting.Indented);
            Console.WriteLine("\nValidation Result:");
            Console.WriteLine(jsonResult);

            Console.ReadLine();
        }
    }
}
