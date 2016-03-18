﻿using System;
using System.Collections.Generic;
using System.Linq;
using Groep9.NET;

namespace Groep9.NET {
    public interface IProductRepository
    {

        

     IQueryable<Product> VindAlleProducten();

     
        Product FindByProductNummer(int productnummer);

        Product FindByNaam(string naam);


    }
}
