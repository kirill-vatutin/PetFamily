using PetFamily.Application.Volunteers.Shared;

namespace PetFamily.Application.Volunteers.CreateVolunteer
{
    public record CreateVolunteerRequest(
        FullNameDTO FullName,
        string Description,
        int YearsOfExperience,
        string PhoneNumber,
        ICollection<RequisiteDTO> RequisitesDTO,
        ICollection<SocialNetworkDTO> SocialNetworksDTO);
    
}
