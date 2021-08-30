using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Techjur.Models.DER;

namespace Techjur.Controllers
{
    public class AcaoController : CustomController
    {

        dbTechjur db;
        public AcaoController()
        {
            db = new dbTechjur();
        }
        public ActionResult Index()
        {
            try
            {
                var model = db.Acao.OrderBy(a => a.descricao);
                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult New()
        {
            try
            {
                ViewBag.classeList = db.Classe.OrderBy(a => a.descricao);
                ViewBag.assuntoList = db.Assunto.OrderBy(a => a.descricao);
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult New(Acao entidade)
        {
            try
            {
                entidade.valorCausa = Convert.ToDecimal(Request.Form["valorCausa"]);
                entidade.idRito = 1;
                AcaoMovimento movimento = new AcaoMovimento()
                {
                    idAcao = entidade.id,
                    idClasse = entidade.idClasse,
                    idAssunto = entidade.idAssunto,
                    idRito = 1,
                    valorCausa = entidade.valorCausa,
                    numeroProcesso = entidade.numeroProcesso,
                    ocorrencia = DateTime.Now
                };

                db.Acao.Add(entidade);
                db.AcaoMovimento.Add(movimento);
                db.SaveChanges();
                return RedirectToAction("Edit", "Acao", new { id = entidade.id });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                var model = db.Acao.FirstOrDefault(a => a.id == id);
                ViewBag.classeList = db.Classe.OrderBy(a => a.descricao);
                ViewBag.assuntoList = db.Assunto.OrderBy(a => a.descricao);
                ViewBag.movimentoList = db.AcaoMovimento.OrderByDescending(a => a.ocorrencia);
                ViewBag.acaoParteList = db.AcaoParte.OrderBy(a => a.Pessoa.nome);
                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Peticionar(int id)
        {
            try
            {
                var model = db.Acao.FirstOrDefault(a => a.id == id);
                ViewBag.classeList = db.Classe.OrderBy(a => a.descricao);
                ViewBag.assuntoList = db.Assunto.OrderBy(a => a.descricao);
                ViewBag.movimentoList = db.AcaoMovimento.OrderByDescending(a => a.ocorrencia);
                ViewBag.acaoParteList = db.AcaoParte.OrderBy(a => a.Pessoa.nome);
                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult Peticionar(int id, HttpPostedFileBase arquivo)
        {
            try
            {
                Acao acao = db.Acao.FirstOrDefault(a => a.id == id);
                AcaoMovimento movimento = new AcaoMovimento()
                {
                    idAcao = acao.id,
                    idAssunto = acao.idAssunto,
                    idClasse = acao.idClasse,
                    idMovimento = 1,
                    idRito = acao.idRito,
                    numeroProcesso = acao.numeroProcesso,
                    valorCausa = acao.valorCausa,
                    ocorrencia = DateTime.Now
                };
                db.AcaoMovimento.Add(movimento);

                AcaoMovimentoDocumento entidade = new AcaoMovimentoDocumento();
                using (var binaryReader = new BinaryReader(Request.Files[0].InputStream))
                {
                    byte[] arquivoBinary = binaryReader.ReadBytes(Request.Files[0].ContentLength);
                    entidade.documento = arquivoBinary;
                    entidade.documentoMime = arquivo.ContentType.ToString();

                    using (var md5 = System.Security.Cryptography.MD5.Create())
                    {
                        entidade.hash = md5.ComputeHash(arquivoBinary);

                        SegurancaLogEnvio log = new SegurancaLogEnvio()
                        {
                            idUsuario = Session["idUsuario"].ToString(),
                            idAcaoMovimentoDocumento = entidade.id,
                            ocorrencia = DateTime.Now
                        };
                        db.SegurancaLogEnvio.Add(log);
                    }
                }
                entidade.idAcaoMovimento = movimento.id;
                db.AcaoMovimentoDocumento.Add(entidade);
                db.SaveChanges();

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