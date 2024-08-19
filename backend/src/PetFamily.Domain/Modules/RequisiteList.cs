using PetFamily.Domain.Models;

namespace PetFamily.Domain.Modules
{

    public record RequisiteList
    {

        private List<Requisite> _requisites = [];

        public IReadOnlyList<Requisite> Requisites => _requisites.AsReadOnly();

        public void AddSocialNetwork(Requisite requisite)
        {
            _requisites.Add(requisite);
        }
    }
}
