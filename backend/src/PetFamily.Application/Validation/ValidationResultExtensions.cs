using FluentValidation.Results;
using PetFamily.Domain.Shared;
using System.Runtime.CompilerServices;

namespace PetFamily.Application.Validation
{
    public static  class ValidationResultExtensions
    {
        public static Error ToError(this ValidationResult validationResult)
        {
            var validationError = validationResult.Errors.First();

            var error = Error.Deserialize(validationError.ErrorMessage);

            return error;
        }
    }
}
