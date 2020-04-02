﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mairer_Camping.Models.DB
{
    public class RepositoryReservierungDB
    {
        private string _connectionString = "Server=localhost;Database=reservierungDB;Uid=root;Pwd=Platin12;";

        private MySqlConnection _connection = null;

        public void Open()
        {
            if (this._connection == null)
            {
                this._connection = new MySqlConnection(this._connectionString);
            }

            if (this._connection.State != ConnectionState.Open)
            {
                this._connection.Open();
            }
        }

        public void Close()
        {
            if ((this._connection != null) && (this._connection.State != ConnectionState.Closed))
            {
                this._connection.Close();
            }
        }
    }
}