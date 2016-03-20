using System;
using System.Collections.Generic;
using System.Linq;
using Groep9.NET.Models.Domein;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Groep9.NET.Tests.Controllers {
    /// <summary>
    /// Summary description for DummyContext
    /// </summary>
    [TestClass]
    public class DummyContext {

        public List<Product> Producten;
        List<Doelgroep> doelgroepen = new List<Doelgroep>();
        List<Leergebied> leergebieden = new List<Leergebied>();


        /*
        public Product VoorbeeldProduct { get; private set; }
        public Product VoorbeeldProduct2 { get;  private set; }
        public Product VoorbeeldProduct3 { get; private set; }
        */

        Leergebied tellen = new Leergebied("Tellen");
        Leergebied spelen = new Leergebied("Spelen");
        Leergebied zeveren = new Leergebied("Zeveren");
        Doelgroep kleuters = new Doelgroep("Kleuters");
        Doelgroep peuters = new Doelgroep("Peuters");
        Doelgroep neuters = new Doelgroep("Neuters");


        Firma testFirma = new Firma("testFirma", "testFirma.be", "test@TestFirma.be");


        Product p1ZonderReservatiesOfBlokkeringen;
        Product p2ZonderReservatiesOfBlokkeringen;
        Product p3ZonderReservatiesOfBlokkeringen;


        
        DateTime datum = new DateTime(2016,03,16,0,0,0);




        public Gebruiker g = new Personeelslid{Email = "a@b.c", VerlangLijst = new List<Product>(), /*ReservatieLijst = new List<Reservatie>(), */GebruikerId = 1};


        public DummyContext() {
            Producten = new List<Product>();
            leergebieden.Add(tellen);
            leergebieden.Add(spelen);
            doelgroepen.Add(kleuters);
            doelgroepen.Add(peuters);

            p1ZonderReservatiesOfBlokkeringen = new Product("", "A", "TestProd", 2.1, 1, true, "hier", testFirma, doelgroepen, leergebieden);
            Producten.Add(p1ZonderReservatiesOfBlokkeringen);

            leergebieden.Add(zeveren);
            p2ZonderReservatiesOfBlokkeringen = new Product("", "B", "TestProd2", 5.8, 1, true, "hier", testFirma, doelgroepen, leergebieden);
            Producten.Add(p2ZonderReservatiesOfBlokkeringen);

            doelgroepen.Add(neuters);
            p3ZonderReservatiesOfBlokkeringen = new Product("", "C", "TestProd3", 2.1, 1, true, "hier", testFirma, doelgroepen, leergebieden);
            Producten.Add(p3ZonderReservatiesOfBlokkeringen);

        }

        public IQueryable<Leergebied> Leergebieden
        {
            get
            {
                return new List<Leergebied>
                       {
                           tellen,
                           spelen,
                           zeveren
                       }.AsQueryable();
            }
        }

        public IQueryable<Doelgroep> Doelgroepen
        {
            get
            {
                return new List<Doelgroep> { kleuters, peuters, neuters }.AsQueryable();
            }
        }
        

       // public IQueryable Producten { get { return Producten; } }

        public Product P1ZonderReservatiesOfBlokkeringen
        {
            get { return p1ZonderReservatiesOfBlokkeringen; }
        }

        public Product P2ZonderReservatiesOfBlokkeringen
        {
            get { return p2ZonderReservatiesOfBlokkeringen; }
        }
        public Product P3ZonderReservatiesOfBlokkeringen
        {
            get { return p3ZonderReservatiesOfBlokkeringen; }
        }

        public Gebruiker Gebruiker { get { return g; } }

        public Product GetProduct(int id) {
            return Producten.FirstOrDefault(p => p.ProductId == id);
        }


        public DateTime Datum
        {
            get { return datum; }
        }


    }
}
