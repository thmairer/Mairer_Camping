using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mairer_Camping.Models.DB.db_script
{
    interface IRepositoryReservierung : IDbBase
    {
        bool Insert(Reservierung reservierung);
        bool Delete(int id);
        bool WurdeBearbeitet(int id);
    }
}
