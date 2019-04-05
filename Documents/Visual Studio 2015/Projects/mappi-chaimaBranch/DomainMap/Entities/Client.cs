using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainMap.Entities
{
  public  enum TypeClient {NewClient,ActualClient,ContractEnded }
    public enum CategorieClient { Private,Public}
 public   class Client:User
    {
       // public int ClientId { get; set; }
        public String Logo { get; set; }
        public int NbrRessource { get; set; }
        public int NbrProjectActif { get; set; }
        public TypeClient typeClient { get; set; }
        public CategorieClient categorieClient { get; set; }
        public virtual ICollection<Project> listProjectClient { get; set; }
        public virtual ICollection<Request> request { get; set; }
        public virtual ICollection<Request> listRequest { get; set; }





    }
}
