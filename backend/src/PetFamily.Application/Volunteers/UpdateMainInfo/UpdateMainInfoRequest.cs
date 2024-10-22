using PetFamily.Application.Volunteers.Shared;

namespace PetFamily.Application.Volunteers.UpdateMainInfo;

public record UpdateMainInfoRequest
(
    Guid VolunteerId,
    UpdateMainInfoDto Dto
);

public record UpdateMainInfoDto
(
    FullNameDTO FullName,
    string Description,
    int YearsOfExperience,
    string PhoneNumber
);
