namespace PetFamily.Domain.Modules.ValueObjects
{
    public class SocialNetworkList
    {

        public IReadOnlyList<SocialNetwork> SocialNetworks;

        public SocialNetworkList(IEnumerable<SocialNetwork> socialNetworks)
        {
            SocialNetworks = socialNetworks.ToList();
        }
        private SocialNetworkList() { }
       
    }
}
