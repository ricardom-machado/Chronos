using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Techjur.Models.DER;

namespace Techjur.Controllers
{
    public class SegurancaLogEnvioController : Controller
    {
        dbTechjur db;
        public SegurancaLogEnvioController()
        {
            db = new dbTechjur();
        }
        public ActionResult Index()
        {
            try
            {
                var model = db.SegurancaLogEnvio.OrderByDescending(a => a.ocorrencia);
                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult Index(int id)
        {
            try
            {
                SegurancaLogEnvio log = new SegurancaLogEnvio()
                {
                    idUsuario = Session["idUsuario"].ToString(),
                    ocorrencia = DateTime.Now,
                    idAcaoMovimentoDocumento = 1
                };

                var model = db.SegurancaLogEnvio.OrderByDescending(a => a.ocorrencia);
                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}