using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mairer_Camping.Models.DB.db_script
{
    interface i_repository_reservierung
    {
        void Open();
        void Close();

        bool Insert(Reservierung reservierung);

    }
}
