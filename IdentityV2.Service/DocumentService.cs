using IdentityV2.Data.Infrastructure;
using IdentityV2.Domain.Entities;
using IdentityV2.ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityV2.Service
{
    public class DocumentService : Service<Documents>, IDocumentService
    {
        static IDataBaseFactory Factory = new DataBaseFactory();//l'usine de fabrication du context
        static IUnitOfWork utk = new UnitOfWork(Factory);//unité de travail a besoin du factory pour communiquer avec la base
        public DocumentService() : base(utk)
        {


        }


        public IEnumerable<Documents> SearchDocumentByName(string searchString)
        {
            IEnumerable<Documents> DocumentDomain = GetMany();
            if (!String.IsNullOrEmpty(searchString))
            {
                DocumentDomain = GetMany(x => x.ProjectId.ToString().Contains(searchString));
            }


            return DocumentDomain;
        }
        public List<Documents> getTasksbyIdProject(int ProjectId)
        {
            List<Documents> ListDocuments = new List<Documents>();
            ListDocuments = GetMany(b => b.ProjectId == ProjectId).ToList();
            return ListDocuments;
        }


    }
}
