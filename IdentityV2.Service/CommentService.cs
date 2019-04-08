using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityV2.Data.Infrastructure;
using IdentityV2.Domain.Entities;
using IdentityV2.ServicePattern;


namespace IdentityV2.Service
{
   public  class CommentService : Service<Comment>, ICommentService
    {
        private static IDataBaseFactory dbFac = new DataBaseFactory();
        private static IUnitOfWork wow = new UnitOfWork(dbFac);
        public CommentService() : base(wow)
        {
        }

        public IEnumerable<Comment> GetCommentByTask(int idTask)
        {

            IEnumerable<Comment> listr = new List<Comment>();
            IEnumerable<TaskPM> listPro = new List<TaskPM>();

            Service<TaskPM> serPro = new Service<TaskPM>(wow);

            listPro = serPro.GetMany().ToList();
            listr = GetMany().ToList();
            //  DateTime date = DateTime.Now;
            IEnumerable<Comment> resultjoin3 = (from d in listPro
                               join r in listr
                              on d.TaskId equals r.TaskId
                               //  where (d.DateBegin <= date && d.DateEnd >= date)
                               select (r));

            return resultjoin3; 

        }
    }
}
