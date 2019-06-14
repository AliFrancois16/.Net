using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.DataAccess
{
    public class EFRepository<T> : IRepository<T> where T:class
    {
        EDMAzure context = new EDMAzure();

        public T Ajouter(T nouveau)
        {
            try
            {
                T result = context.Set<T>().Add(nouveau);
                context.SaveChanges();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual ICollection<T> Lister()
        {
            try
            {
                return context.Set<T>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T Modifier(T objetAModifie)
        {
            try
            {
                context.Entry<T>(objetAModifie).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return objetAModifie;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Supprimer(int id)
        {
            try
            {
                context.Set<T>().Remove(context.Set<T>().Find(id));
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Supprimer(int id, string name)
        {
            try
            {
                var result = context.Set<T>().Find(id);
                context.Entry<T>(result).Property(name).CurrentValue = false;
                context.Entry<T>(result).Property(name).IsModified = true;
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public T Trouver(int id)
        {
            try
            {
                return context.Set<T>().Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
