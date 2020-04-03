using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Mairer_Camping.Models.DB
{
    public class RepositoryReservierungDB : i_repository_reservierung
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

        public bool Insert(Reservierung reservierung)
        {
            if (reservierung == null)
            {
                return false;
            }

            DbCommand cmdInsert = this._connection.CreateCommand();

            cmdInsert.CommandText = "INSERT INTO users VALUES(null, @firstname, @lastname, @arrivalDatem @departureDate)";

            DbParameter paramFN = cmdInsert.CreateParameter();
            paramFN.ParameterName = "firstname";
            paramFN.Value = reservierung.Firstname;
            paramFN.DbType = DbType.String;

            DbParameter paramLN = cmdInsert.CreateParameter();
            paramLN.ParameterName = "lastname";
            paramLN.Value = reservierung.Lastname;
            paramLN.DbType = DbType.String;

            DbParameter paramArrivalDate = cmdInsert.CreateParameter();
            paramArrivalDate.ParameterName = "arrivalDate";
            paramArrivalDate.Value = reservierung.ArrivalDate;
            paramArrivalDate.DbType = DbType.Date;

            DbParameter paramDepartureDate = cmdInsert.CreateParameter();
            paramDepartureDate.ParameterName = "departureDate";
            paramDepartureDate.Value = reservierung.DepartureDate;
            paramDepartureDate.DbType = DbType.Date;


            //Parameter mit dem command verbinden
            cmdInsert.Parameters.Add(paramFN);
            cmdInsert.Parameters.Add(paramLN);
            cmdInsert.Parameters.Add(paramArrivalDate);
            cmdInsert.Parameters.Add(paramDepartureDate);

            return cmdInsert.ExecuteNonQuery() == 1;



        }

    }
}