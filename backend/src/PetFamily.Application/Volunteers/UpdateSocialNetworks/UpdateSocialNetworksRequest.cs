using PetFamily.Application.Volunteers.Shared;

namespace PetFamily.Application.Volunteers.UpdateSocialNetworks;

public record UpdateSocialNetworksRequest(
    Guid VolunteerId,
    ICollection<SocialNetworkDTO> SocialNetworksDTO
);
