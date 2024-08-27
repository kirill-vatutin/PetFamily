namespace PetFamily.Application.Volunteers.CreateVolunteer
{
    public record CreateVolunteerRequest(
        FullNameDTO FullName,
        string Description,
        int YearsOfExperience,
        string PhoneNumber,
        ICollection<RequisiteDTO> RequisitesDTO ,
        ICollection<SocialNetworkDTO> SocialNetworksDTO );

    public record SocialNetworkDTO(string Name, string Link);


    public record FullNameDTO(
        string FirstName, string SecondName, string? LastName = null);

    public record RequisiteDTO(
        string Name, string Description)
    {
    }
}
