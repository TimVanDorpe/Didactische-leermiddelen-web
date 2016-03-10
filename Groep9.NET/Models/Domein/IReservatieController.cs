﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Groep9.NET.Models.Domein
{
    public interface IReservatieRepository
    {

        IQueryable<Reservatie> VindAlleReservaties();
        void AddReservatie(Reservatie reservatie);
        void SaveChanges();

        void RemoveReservatie(Reservatie reservatie);
    }
}