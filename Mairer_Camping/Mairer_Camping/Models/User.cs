using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mairer_Camping.Models
{
    public enum Gender { notSpecified, male, female }
    public enum Typ { Gast, registrierterBenutzer, Admin }

    public class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Gender Gender { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Password2 { get; set; }
        public Typ Typ { get; set; }


        public User() : this(0, "", "", Gender.notSpecified, null, "", "", "", Typ.Gast) { }
        public User(int id, string firstname, string lastname, Gender gender, DateTime? birthdate, string username, string password, string password2, Typ typ)
        {
            this.Id = id;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Gender = gender;
            this.Birthdate = birthdate;
            this.Username = username;

            this.Password = password;
            this.Password2 = password2;
        }
    }
}