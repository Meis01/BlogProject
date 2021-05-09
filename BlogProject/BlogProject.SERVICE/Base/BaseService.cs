using BlogProject.CORE.Concrete;
using BlogProject.CORE.Entity.Enum;
using BlogProject.CORE.Entity.Service;
using BlogProject.MODEL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Transactions;

namespace BlogProject.SERVICE.Base
{
    public class BaseService<T> : ICoreService<T> where T : CoreEntity
    {
        private readonly BlogContext _context;
        public BaseService(BlogContext context)
        {
            _context = context;
        }
        public bool Activate(Guid id)
        {
            T activated = GetByID(id);
            activated.Status = Status.Active;
            return Update(activated);
        }

        public void DetachEntity(T item)//Araştırın*******

        {
            _context.Entry<T>(item).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
        }
        public bool Add(T item)
        {
            try
            {
                //db.Products.Products(prod);
                //_context.Users.Add(user)
                _context.Set<T>().Add(item);
                return Save() > 0;
            }
            catch (Exception)
            {

              return false;
            }
        }

        public bool Add(List<T> item)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    _context.Set<T>().AddRange(item);
                    ts.Complete();
                    return Save() > 0;
                }
              
            }
            catch (Exception)
            {

                return false;
            }
        }

        //public bool Any(Expression<Func<T, bool>> exp)
        //{
        //   return _context.Set<T>().Any(exp);
        //}
        public bool Any(Expression<Func<T, bool>> exp) =>  _context.Set<T>().Any(exp);

       // public List<T> GetActive() => _context.Set<T>().Where(x => x.Status == Status.Active).ToList();
        public List<T> GetActive() => _context.Set<T>().Where(x => x.Status != Status.Deleted).ToList();

        public List<T> GetAll()
        {
           return _context.Set<T>().ToList();
        }

        public T GetByDefault(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().FirstOrDefault(exp);
        }

        public T GetByID(Guid id)
        {
            return _context.Set<T>().Find(id); 
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Where(exp).ToList();
        }

        public bool Remove(T item)
        {
            item.Status = Status.Deleted;
            return Update(item);
        }

        public bool Remove(Guid id)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    T item = GetByID(id);
                    item.Status = Status.Deleted;
 
                    ts.Complete();
                    return Update(item);
                }
            }
            catch (Exception)
            {

                return false;
            }
           
        }

        public bool RemoveAll(Expression<Func<T, bool>> exp)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var collection = GetDefault(exp);
                    int count = 0;

                    foreach (var item in collection)
                    { item.Status = Status.Deleted;
                        bool opResult = Update(item);
                        if (opResult) count++;
                    }
                    if (collection.Count == count) ts.Complete();
                    else return false;
                   
                    //T item = GetByID(id);
                    //item.Status = Status.Deleted;

                    //ts.Complete();
                    //return Update(item);
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public bool Update(T item)
        {
            try
            {
                _context.Set<T>().Update(item);
                return Save() > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
