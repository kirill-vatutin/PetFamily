﻿namespace PetFamily.Domain.Modules.ValueObjects
{
    public class SocialNetworkList
    {
        private List<SocialNetwork> _socialNetworks = [];

        public IReadOnlyList<SocialNetwork> SocialNetworks => _socialNetworks.AsReadOnly();

        public void AddSocialNetwork(SocialNetwork socialNetwork)
        {
            _socialNetworks.Add(socialNetwork);
        }
    }
}