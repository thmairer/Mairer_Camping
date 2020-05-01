using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mairer_Camping.Models.DB
{
    interface IDbBase
    {
        void Open();
        void Close();
    }
}
