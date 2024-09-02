namespace PetFamily.Domain.Modules.ValueObjects
{

    public record RequisiteList
    {

        public IReadOnlyList<Requisite> Requisites;

        public RequisiteList(IEnumerable<Requisite> requisites)
        {
            Requisites = requisites.ToList();
        }
        private RequisiteList() { }
       
    }
}
