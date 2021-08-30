using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Techjur.Models.DER;

namespace Techjur.Controllers
{
    public class AcaoMovimentoController : CustomController
    {
        dbTechjur db;
        public AcaoMovimentoController()
        {
            db = new dbTechjur();
        }
        public ActionResult Details(int id)
        {
            try
            {
                var model = db.Acao.FirstOrDefault(a => a.id == id);
                ViewBag.movimentoList = db.AcaoMovimento.Where(a => a.idAcao == id).OrderByDescending(a => a.ocorrencia);
                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }
        
    }
}