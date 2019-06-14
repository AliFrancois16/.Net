using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.DataAccess
{
    public interface IRepository<T>
    {
        T Ajouter(T nouveau);
        T Modifier(T objetAModifie);
        void Supprimer(int id);
        void Supprimer(int id, string name);
        ICollection<T> Lister();
        T Trouver(int id);
    }
}
