using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.DataAccess
{
    public class EFClients: EFRepository<Client>
    {
        EDMAzure context= new EDMAzure();
        public int FindId(string email)
        {
            var client = context.Clients.Where(c => c.EmailClient == email).FirstOrDefault();
            return client.IdClient;
        }
    }
}
