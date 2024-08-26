﻿namespace PetFamily.Domain.Modules.ValueObjects
{

    public record RequisiteList
    {

        private List<Requisite> _requisites = [];

        public IReadOnlyList<Requisite> Requisites => _requisites.AsReadOnly();

        public void AddRequisite(Requisite requisite)
        {
            _requisites.Add(requisite);
        }

        public RequisiteList(IEnumerable<Requisite> requisites)
        {
            _requisites = requisites.ToList();
        }
        private RequisiteList()
        {
                
        }
    }
}
