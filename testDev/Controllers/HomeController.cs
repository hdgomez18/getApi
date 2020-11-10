using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using testDev.Models;
using testDev.Models.viewModels;

namespace testDev.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult add(procIngresos model)
        {
            var lista = JsonConvert.DeserializeObject<List<Dictionary<string, dynamic>>>(model.Valores);
            using (var db = new pruebaEntities())
            {
                var contar = (from a in db.ingresos
                              select a).Count();

                if (contar == 1232)
                {
                //Limpio la tabla 
                var cleanTable = db.Database.ExecuteSqlCommand("truncate table ingresos");

                }

                foreach (var item in lista)
                {
                    ingreso oIngreso = new ingreso();
                    oIngreso.anio = item["a_o"];
                    oIngreso.trimestre = item["trimestre"];
                    oIngreso.proveedor = item["proveedor"];
                    oIngreso.ingresos = item["ingresos"];
                 

                    db.ingresos.Add(oIngreso);
                    db.SaveChanges();
                }
            }
            return null;
        }

        [HttpPost]
        public ActionResult add1(procIngresos model)
        {
            var lista = JsonConvert.DeserializeObject<List<Dictionary<string, dynamic>>>(model.Valores);
            using (var db = new pruebaEntities())
            {
                var contar = (from a in db.ingresos
                              select a).Count();

                if (contar == 1232)
                {
                    //Limpio la tabla 
                    var cleanTable = db.Database.ExecuteSqlCommand("truncate table ingresos");

                }

                foreach (var item in lista)
                {
                    ingreso oIngreso = new ingreso();
                    oIngreso.anio = item["a_o"];
                    oIngreso.trimestre = item["trimestre"];
                    oIngreso.proveedor = item["proveedor"];
                    oIngreso.ingresos = item["ingresos"];
                    oIngreso.segmento = item["segmento"];
                    oIngreso.terminal = item["terminal"];
                    

                    db.ingresos.Add(oIngreso);
                    db.SaveChanges();

                  
                }
                //Arreglo la columna terminal
                var colTerminal = db.Database.ExecuteSqlCommand("update ingresos set terminal = 'TELEFONO MOVIL' WHERE terminal = 'TEL?FONO M?VIL'");
            }
            return null;
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}