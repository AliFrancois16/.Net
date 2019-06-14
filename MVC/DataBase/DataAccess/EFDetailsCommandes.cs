using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.DataAccess
{
    public class EFDetailsCommandes : EFRepository<DetailsCommande>
    {
        EDMAzure context = new EDMAzure();

        public override ICollection<DetailsCommande> Lister()
        {
            try
            {
                return context.DetailsCommandes.Include(d => d.Commande).Include(d => d.Produit).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
