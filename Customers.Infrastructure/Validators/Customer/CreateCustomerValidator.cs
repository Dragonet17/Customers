using Customers.Infrastructure.Commands;
using FluentValidation;

namespace Customers.Infrastructure.Validators.Customer {
    public class CreateCustomerValidator : AbstractValidator<CreateCustomer> {
        public CreateCustomerValidator () {
            RuleFor (reg => reg.Name)
                .NotNull ()
                .MinimumLength (3)
                .Matches (@"^[a-zA-ZàáąâäãåąčććęęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšśžÀÁÂÄÃÅĄČĆĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð'-]+(\s{1}[a-zA-ZàáąâäãåąčććęęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšśžÀÁÂÄÃÅĄČĆĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð'-]+)*$")
                .WithMessage ("Name should contain only letters with one space between words");
            RuleFor (reg => reg.Surname)
                .NotNull ()
                .MinimumLength (3)
                .Matches (@"^[a-zA-ZàáąâäãåąčććęęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšśžÀÁÂÄÃÅĄČĆĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð'-]+(\s{1}[a-zA-ZàáąâäãåąčććęęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšśžÀÁÂÄÃÅĄČĆĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð'-]+)*$")
                .WithMessage ("Surname should contain only letters with one space between words");
            RuleFor (reg => reg.TelephoneNumber)
                .Matches (@"^\+(?:[0-9]●?){10,10}[0-9]$")
                .WithMessage ("Phone number is invalid.");
            RuleFor (reg => reg.FlatNumber)
                .NotNull ()
                .Matches (@"^[0-9]*$")
                .WithMessage ("Flat number, must contain only numbers");
            RuleFor (reg => reg.BuildingNumber)
                .NotNull ()
                .Matches (@"^[0-9]+([a-zA-Z]?)$")
                .WithMessage ("Street number, must contain only numbers with one optional letter at the end ");
            RuleFor (reg => reg.Street)
                .NotNull ()
                .MinimumLength (3)
                .MaximumLength (50)
                .Must (p => !string.IsNullOrEmpty (p) && !p.StartsWith (" "))
                .WithMessage ("Street can not start by space")
                .Must (p => !string.IsNullOrEmpty (p) && !p.EndsWith (" "))
                .WithMessage ("Street can not end by space")
                .Must (p => !string.IsNullOrEmpty (p) && !p.Contains ("  "))
                .WithMessage ("Street must contain only one space between words")
                .Matches (@"(([a-zA-ZàáąâäãåąčććęęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšśžÀÁÂÄÃÅĄČĆĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð'-.]+(\s{1}[a-zA-ZàáąâäãåąčććęęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšśžÀÁÂÄÃÅĄČĆĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð'-.]+)*)|(([A-Za-zàáąâäãåąčććęęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšśžÀÁÂÄÃÅĄČĆĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð'-.]+\s{1})+[0-9]*)|(([A-Za-zàáąâäãåąčććęęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšśžÀÁÂÄÃÅĄČĆĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð'-.]+\s{1})+[0-9]*(\s{1}[a-zA-ZàáąâäãåąčććęęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšśžÀÁÂÄÃÅĄČĆĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð'-.]+)+)|([0-9]*(\s{1}[A-Za-zàáąâäãåąčććęęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšśžÀÁÂÄÃÅĄČĆĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð'-.]+)+)|([0-9]*(\s{1}[A-Za-zàáąâäãåąčććęęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšśžÀÁÂÄÃÅĄČĆĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð'-.]+)+\s{1}[0-9]*))$")
                .WithMessage ("Name of street should contain letters and numbers - separatly and unique characters such as ' -'. ' ");
            RuleFor (reg => reg.City)
                .NotNull ()
                .MinimumLength (3)
                .Matches (@"^[a-zA-ZàáąâäãåąčććęęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšśžÀÁÂÄÃÅĄČĆĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð'-.]+(\s{1}[a-zA-ZàáąâäãåąčććęęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšśžÀÁÂÄÃÅĄČĆĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð'-]+)*$")
                .WithMessage ("City should contain only letters with one space between words");
            RuleFor (reg => reg.ZipCode)
                .NotNull ()
                .Matches (@"^[0-9]{2}\-[0-9]{3}$")
                .WithMessage ("Zip code must contain properly format 'NN-NNN'");
        }
    }
}