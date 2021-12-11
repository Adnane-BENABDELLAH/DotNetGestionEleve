using EnsatGestion.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Data;
using System.Xml.Linq;

namespace EnsatGestion.Controllers
{
    public class EleveController : Controller
    {

        ServiceEleve.Service1Client eleve = new ServiceEleve.Service1Client();
        public IActionResult Index()
        {
            return View("CreateEleve");
        }
        [HttpPost]
        public IActionResult Create(Eleve E)
        {
            eleve.Insert(E.cne,E.nom,E.prenom,E.email,E.filiere,E.tel);
            return RedirectToAction("Index");
        }
        public IActionResult List()
        {
            var Eleve = eleve.GetAll();
            ViewBag.Eleves = eleve.GetAll();
            return View("ListEleve");
        }

        public IActionResult getOne()
        {
            //var Eleve = eleve.GetAll();
            ViewBag.Eleve = eleve.GetAll().Nodes[1].ToString();

            return View("DetailsEleve");
        }
    }
}
