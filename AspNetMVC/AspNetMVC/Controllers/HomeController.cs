﻿using AspNetMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMVC.Controllers
{
    public class HomeController : Controller
    {
        private static List<Livro> Livros;


        public HomeController()
        {
            if (Livros == null)
            {
                Livros = new Livro().GetLivros();
            }
        }

        public ActionResult Index()
        {
            return View(Livros);
        }


        public ActionResult NovoLivro()
        {
            return View();
        }

        public ActionResult EditarLivro(int id)
        {
            return View(Livros.FirstOrDefault(x => x.ID == id));
        }

        [HttpPost]
        public ActionResult InserirLivro(Livro livro)
        {
            if (ModelState.IsValid)
            {
                if (!Livros.Any(x => x.ID == livro.ID))
                {
                    Livros.Add(livro);
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View("NovoLivro", livro);
            }
        }


        [HttpPost]
        public ActionResult AtualizarLivro(Livro livro)
        {
            if (ModelState.IsValid)
            {
                var index = Livros.FindIndex(x => x.ID == livro.ID);
                Livros[index] = livro;
                return RedirectToAction("Index");
            }
            else
            {
                return View("EditarLivro", livro);
            }
        }

        // [HttpGet]
        public ActionResult ExcluirLivro(int id)
        {
            Livros.Remove(Livros.FirstOrDefault(x => x.ID == id));
            return RedirectToAction("Index");
        }




    }

}