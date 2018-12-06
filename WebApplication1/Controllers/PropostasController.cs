﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PropostasController : Controller
    {
        private Context db = new Context();

        // GET: Propostas
        public ActionResult ListarPropostas()
        {
            return View(db.Propostas.ToList());
        }

        // GET: Propostas/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PropostaId,Descricao,LocalEstagio,TipoProposta,Ramo,DataInicio,DataFim,Objetivos,AlunoId")] Proposta proposta)
        {
            if (ModelState.IsValid)
            {
                db.Propostas.Add(proposta);
                db.SaveChanges();
                return RedirectToAction("ListarPropostas");
            }

            return View(proposta);
        }

        // GET: Propostas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proposta proposta = db.Propostas.Find(id);
            if (proposta == null)
            {
                return HttpNotFound();
            }
            return View(proposta);
        }

        // POST: Propostas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proposta proposta = db.Propostas.Find(id);
            db.Propostas.Remove(proposta);
            db.SaveChanges();
            return RedirectToAction("ListarPropostas");
        }

        public ActionResult AceitarProposta(int? id)
        {
            var proposta = db.Propostas.Where(x => x.PropostaId == id).FirstOrDefault();

            if(proposta != null)
            {
                proposta.estado = true;
                db.SaveChanges();
            }

            return RedirectToAction("ListarPropostas");
        }

        public ActionResult RegeitarProposta(int? id)
        {
            var proposta = db.Propostas.Where(x => x.PropostaId == id).FirstOrDefault();

            if (proposta != null)
            {
                proposta.estado = false;
                db.SaveChanges();
            }

            return RedirectToAction("ListarPropostas");
        }

        public ActionResult Candidatura(int? id)
        {
            string email = Session.Get<string>("ContaCorrente");
            var conta = db.Alunos.Where(x => x.Nome == email).FirstOrDefault();
            var proposta = db.Propostas.Where(x => x.PropostaId == id).FirstOrDefault();

            if (email != null && conta != null)
            {
                conta.Preferencias.Add(proposta);

                return RedirectToAction("ListarPropostas");
            }

            //Session.Set("ContaCorrente", );

            return RedirectToAction("ListarPropostas");
        }



        protected override void Dispose(bool disposing)
        { 
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
