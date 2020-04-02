using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mairer_Camping.Models
{
    public class Reservierung
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public DateTime? ArrivalDate { get; set; }
        public DateTime? DepartureDate { get; set; }

        public Reservierung() : this(0, "", "",  null,null) { }
        public Reservierung(int id, string firstname, string lastname, DateTime? arrivalDate,DateTime? departureDate)
        {
            this.Id = id;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.ArrivalDate = arrivalDate;
            this.DepartureDate = departureDate;
        }

    }
}