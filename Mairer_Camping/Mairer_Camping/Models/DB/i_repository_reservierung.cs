﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mairer_Camping.Models.DB
{
    public class i_repository_reservierung
    {
        interface i_repository_user
        {

            void Open();
            void Close();

            bool Insert(Reservierung reservierung);
        }
    }
}