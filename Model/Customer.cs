using FluentValidation;
using System;
using System.Linq;

namespace Fluent.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
    }
    public class CustomerValidatior : AbstractValidator<Customer>
    {
        public CustomerValidatior() 
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Please enter First Name")
           .Must(BeValidName).WithMessage("Please ensure that to set a valid value for {PropertyName}");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Please enter valid email address");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Please enter phone number")
            .Must(BeValidNumber).WithMessage("please enter valid number ,number must be in 10 digits");
            //.Length(10).WithMessage("phone number must be in 10 digit");
            RuleFor(x => x.Age).InclusiveBetween(10, 30).WithMessage("Age must be between 10 to 30");
        }

        private bool BeValidNumber(string arg)
        {
            return arg.All(char.IsDigit) && arg.Length==10;
        }

        private bool BeValidName(string arg)
        {
            return arg.All(char.IsLetter);
        }
    }
}
