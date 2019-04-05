using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using IdentityV2.Data.Infrastructure;

namespace IdentityV2.ServicePattern
{
    public class Service<T> : IService<T>
        where T : class
    {
        #region Private Fields
        IUnitOfWork utwk;
        #endregion Private Fields

        #region Constructor
        public Service(IUnitOfWork utwk)
        {
            this.utwk = utwk;
        }
        #endregion Constructor


        public void Dispose()
        {
            utwk.Dispose();
        }
        public virtual void Add(T entity)
        {
            ////_repository.Add(entity);
            utwk.GetRepositoryBase<T>().Add(entity);
        }


        public virtual void Update(T entity)
        {
            //_repository.Update(entity);
            utwk.GetRepositoryBase<T>().Update(entity);
        }

        public virtual void Delete(T entity)
        {
            //   _repository.Delete(entity);
            utwk.GetRepositoryBase<T>().Delete(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            // _repository.Delete(where);
            utwk.GetRepositoryBase<T>().Delete(where);
        }

        public virtual T GetById(int id)
        {
            //  return _repository.GetById(id);
            return utwk.GetRepositoryBase<T>().GetById(id);
        }

        public virtual T GetById(string id)
        {
            //return _repository.GetById(id);
            return utwk.GetRepositoryBase<T>().GetById(id);
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> filter = null, Expression<Func<T, bool>> orderBy = null)
        {
            //  return _repository.GetAll();
            return utwk.GetRepositoryBase<T>().GetMany(filter, orderBy);
        }

        public virtual T Get(Expression<Func<T, bool>> where)
        {
            //return _repository.Get(where);
            return utwk.GetRepositoryBase<T>().Get(where);
        }







        public void Commit()
        {
            try
            {
                utwk.commit();
            }
            catch (Exception ex)
            {

                throw;
            }
        }



    }

}
