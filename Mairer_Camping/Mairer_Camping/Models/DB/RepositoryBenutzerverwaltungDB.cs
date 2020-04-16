using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;

namespace Mairer_Camping.Models.DB
{
    public class RepositoryBenutzerverwaltungDB : i_repository_benutzerVerwaltung
    {
        private string _connectionString = "Server=localhost;Database=db_webproject;Uid=root;Pwd=Platin12;";

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

        public bool Insert(User user)
        {
            if (user == null)
            {
                return false;
            }

            DbCommand cmdInsert = this._connection.CreateCommand();

            cmdInsert.CommandText = "INSERT INTO users VALUES(null, @firstname, @lastname, @gender, @birthdate, @username, sha2(@password, 512), @typ)";

            DbParameter paramFN = cmdInsert.CreateParameter();
            paramFN.ParameterName = "firstname";
            paramFN.Value = user.Firstname;
            paramFN.DbType = DbType.String;

            DbParameter paramLN = cmdInsert.CreateParameter();
            paramLN.ParameterName = "lastname";
            paramLN.Value = user.Lastname;
            paramLN.DbType = DbType.String;

            DbParameter paramGender = cmdInsert.CreateParameter();
            paramGender.ParameterName = "gender";
            paramGender.Value = user.Gender;
            paramGender.DbType = DbType.Int32;

            DbParameter paramBirthdate = cmdInsert.CreateParameter();
            paramBirthdate.ParameterName = "birthdate";
            paramBirthdate.Value = user.Birthdate;
            paramBirthdate.DbType = DbType.Date;

            DbParameter paramUsername = cmdInsert.CreateParameter();
            paramUsername.ParameterName = "username";
            paramUsername.Value = user.Username;
            paramUsername.DbType = DbType.String;

            DbParameter paramPassword = cmdInsert.CreateParameter();
            paramPassword.ParameterName = "password";
            paramPassword.Value = user.Password;
            paramPassword.DbType = DbType.String;

            DbParameter paramTyp = cmdInsert.CreateParameter();
            paramTyp.ParameterName = "typ";
            paramTyp.Value = user.Typ;
            paramTyp.DbType = DbType.Int32;

            cmdInsert.Parameters.Add(paramFN);
            cmdInsert.Parameters.Add(paramLN);
            cmdInsert.Parameters.Add(paramGender);
            cmdInsert.Parameters.Add(paramBirthdate);
            cmdInsert.Parameters.Add(paramUsername);
            cmdInsert.Parameters.Add(paramPassword);
            cmdInsert.Parameters.Add(paramTyp);

            return cmdInsert.ExecuteNonQuery() == 1;

        }

        public User Login(UserLogin user)
        {
            DbCommand cmdLogin = this._connection.CreateCommand();
            cmdLogin.CommandText = "SELECT * FROM users WHERE username=@username AND password=sha2(@password, 512)";

            DbParameter paramUsername = cmdLogin.CreateParameter();
            paramUsername.ParameterName = "username";
            paramUsername.Value = user.Username;
            paramUsername.DbType = DbType.String;

            DbParameter paramPWD = cmdLogin.CreateParameter();
            paramPWD.ParameterName = "password";
            paramPWD.Value = user.Password;
            paramPWD.DbType = DbType.String;

            cmdLogin.Parameters.Add(paramUsername);
            cmdLogin.Parameters.Add(paramPWD);

            using (DbDataReader reader = cmdLogin.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    return null;
                }
                reader.Read();

                return new User
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Firstname = Convert.ToString(reader["firstname"]),
                    Lastname = Convert.ToString(reader["lastname"]),
                    Gender = (Gender)Convert.ToInt32(reader["gender"]),
                    Birthdate = Convert.ToDateTime(reader["birthdate"]),
                    Username = Convert.ToString(reader["username"]),
                    Password = "",
                    Typ = (Typ)Convert.ToInt32(reader["typ"])
                };
            }
        }

    }
}