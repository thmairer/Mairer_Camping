using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mairer_Camping.Models.DB
{
    interface i_repository_benutzerVerwaltung
    {
        void Open();
        void Close();

        bool Insert(User user);
        User Login(UserLogin user);
    }
}
