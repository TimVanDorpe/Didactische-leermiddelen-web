﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Groep9.NET.Models.Domein;
using Groep9.NET.ViewModels;
using Groep9.NET.Models.DAL;

namespace Groep9.NET.Controllers
{
    // gebruikers kunnen enkel nog op de catalogus na inloggen als user@user.com / password
    public class CatalogusController : Controller
    {
        // GET: Catalogus

        private IProductRepository productRepository;

        public CatalogusController(IProductRepository pr)
        {
            productRepository = pr;
            
        }
    
        public ActionResult Index( string trefwoord = "", string doelgroep = "", string leergebied = "")
        {
            
            if (ModelState.IsValid)
                {
                    try
                    {

                        if (doelgroep.Equals("-- Selecteer doelgroep --"))
                        {
                            doelgroep = "";
                        }
                    if (leergebied.Equals("-- Selecteer doelgroep --"))
                    {
                        leergebied = "";
                    }
                    

                    IEnumerable<Product>  producten = productRepository.VindAlleProducten().OrderBy(p => p.Naam).ToList();

                    if (!trefwoord.Equals(""))
                    {

                        producten =
                            producten.Where(p => p.Naam.Contains(trefwoord) || p.Omschrijving.Contains(trefwoord));
                    }
                        if (!doelgroep.Equals(""))
                        {
                        producten = producten.Where(p=> p.Doelgroep.Equals(doelgroep));
                        }
                        if (!leergebied.Equals(""))
                        {
                        producten = producten.Where(p => p.Leergebied.Equals(leergebied));
                    }
                  
                       


                    FillDropDownList();
                    ViewBag.Trefwoord = trefwoord;
                    if (Request.IsAjaxRequest())
                        return PartialView("Producten", producten);
                    
                    

                    return View(producten);
                }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", ex.Message);
                    }
                }
                      
            return RedirectToAction("Index", "Home");
        }
      

        private SelectList GetDoelgroepSelectList()
        {
            return new SelectList(productRepository.VindAlleProducten().Distinct(),
                "Doelgroep", "Doelgroep");
        }
        private SelectList GetLeergebiedSelectList()
        {
            return new SelectList(productRepository.VindAlleProducten().Distinct(),
                "Leergebied", "Leergebied");
        }
        public ActionResult Details(int id)
        {
            Product product = productRepository.FindByProductNummer(id);
            return View(product);
        }

        public void FillDropDownList()
        {
         
            ViewBag.leergebied = GetLeergebiedSelectList();
            ViewBag.doelgroep = GetDoelgroepSelectList();

        }

    }
}