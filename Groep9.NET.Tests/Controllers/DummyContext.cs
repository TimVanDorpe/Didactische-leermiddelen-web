using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Groep9.NET.Models.Domein;

namespace Groep9.NET.Tests.Models {
    /// <summary>
    /// Summary description for DummyContext
    /// </summary>
    [TestClass]
    public class DummyContext {

        public IList<Product> producten;
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

        Product p1;
        Product p2;
        Product p3;


        public Gebruiker g = new Personeelslid{Email = "a@b.c", VerlangLijst = new List<Product>(), ReservatieLijst = new List<Reservatie>(), GebruikerId = 1};


        public DummyContext() {
            producten = new List<Product>();
            leergebieden.Add(tellen);
            leergebieden.Add(spelen);
            doelgroepen.Add(kleuters);
            doelgroepen.Add(peuters);

            p1 = new Product("", "A", "TestProd", 2.1, 1, true, "hier", "B", doelgroepen, leergebieden);
            producten.Add(p1);

            leergebieden.Add(zeveren);
            p2 = new Product("", "B", "TestProd2", 5.8, 1, true, "hier", "B", doelgroepen, leergebieden);
            producten.Add(p2);

            doelgroepen.Add(neuters);
            p3 = new Product("", "C", "TestProd3", 2.1, 1, true, "hier", "B", doelgroepen, leergebieden);
            producten.Add(p3);

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
        

        public IQueryable Producten { get { return producten.AsQueryable(); } }

        public Product P1
        {
            get { return p1; }
        }

        public Product P2
        {
            get { return p2; }
        }
        public Product P3
        {
            get { return p3; }
        }

        public Gebruiker Gebruiker { get { return g; } }

        public Product GetProduct(int id) {
            return producten.FirstOrDefault(p => p.ProductId == id);
        }



    }
}
