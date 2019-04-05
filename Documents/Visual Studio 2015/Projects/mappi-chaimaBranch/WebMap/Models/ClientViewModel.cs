using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMap.Models
{
    public enum TypeClient { NewClient, ActualClient, ContractEnded }
    public enum CategorieClient { Private, Public }
    public class ClientViewModel: UserViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public String Logo { get; set; }
        public int NbrRessource { get; set; }
        public int NbrProjectActif { get; set; }
        public TypeClient typeClient { get; set; }
        public CategorieClient categorieClient { get; set; }
        public virtual ICollection<ProjectViewModel> listProjectClient { get; set; }
        public ICollection<RequestViewModel> listRequest { get; set; }
    }
}