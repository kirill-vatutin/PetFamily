namespace PetFamily.Application.Volunteers.Shared;

public record FullNameDTO
(
    string FirstName, string SecondName, string? LastName = null
);
