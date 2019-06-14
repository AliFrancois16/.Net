using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.DataAccess
{
    public class EFHome : EFRepository<Avi>
    {
        EDMAzure context = new EDMAzure();
        //    public Produit DetailsAvis(int id)
        //    {
        //        try
        //        {
        //            return context.Produits.Where(p => p.IdProduit == id).Include(a => a.Avis.Where(av =>av.IsPublie==true)).First();
        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }
        //    }
        //}
        public IEnumerable<object> ListActiveAvis(int id)
        {
            return context.Avis.Where(av => (bool)av.IsPublie && av.IdProduit == id).Include(av=>av.Client).ToList();
            //return context.Avis.Where(av => (bool)av.IsPublie).Include(av => av.Client).Select(a => new { a.NoteAvis, a.TexteAvis, a.DateAvis, cl = a.Client.NomClient }).ToList();
        }
    }
}
