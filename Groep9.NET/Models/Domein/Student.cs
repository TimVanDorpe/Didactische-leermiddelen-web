using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;
using System.Security.Claims;
using Groep9.NET.Models.Domein;

namespace Groep9.NET {
    public class Student : Gebruiker {
        public Student(): base()
        {
        }

        public override void VoegReservatieToe(Reservatie r)
        {

            ReservatieLijst.Add(r);

        }

        public override void VerwijderReservatie(Reservatie r)
        {
            ReservatieLijst.Remove(r);
        }

    }
}