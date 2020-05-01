using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Mairer_Camping.Models.DB.db_script;

namespace Mairer_Camping.Models.DB
{
    public class RepositoryReservierungDB : DbBase, IRepositoryReservierung
    {
        public List<Reservierung> GetAllReservierungen()
        {
            List<Reservierung> reservierungen = new List<Reservierung>();

            DbCommand cmdSelect = this._connection.CreateCommand();
            cmdSelect.CommandText = "SELECT * FROM anfragen;";

            using (DbDataReader reader = cmdSelect.ExecuteReader())
            {
                while (reader.Read())
                {
                    reservierungen.Add(

                            new Reservierung
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Firstname = Convert.ToString(reader["firstname"]),
                                Lastname = Convert.ToString(reader["lastname"]),
                                ArrivalDate = Convert.ToDateTime(reader["arrivalDate"]),
                                DepartureDate = Convert.ToDateTime(reader["departureDate"]),
                            });
                }

            }

            return reservierungen;

        }


        public bool Delete(int id)
        {
            DbCommand cmdDel = this._connection.CreateCommand();
            cmdDel.CommandText = "DELETE FROM users WHERE id=@userid";

            DbParameter paramId = cmdDel.CreateParameter();
            paramId.ParameterName = "userid";
            paramId.Value = id;
            paramId.DbType = DbType.Int32;

            cmdDel.Parameters.Add(paramId);

            return cmdDel.ExecuteNonQuery() == 1;
        }

        public bool WurdeBearbeitet(int id)
        {
            DbCommand cmdWurdeBearbeitet = this._connection.CreateCommand();
            cmdWurdeBearbeitet.CommandText = "UPDATE users SET istBearbeitet=true WHERE id=@uid";

            return cmdWurdeBearbeitet.ExecuteNonQuery() == 1;
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