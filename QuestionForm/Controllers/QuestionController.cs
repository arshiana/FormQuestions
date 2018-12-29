using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuestionForm.Models;
using Newtonsoft.Json;
using System.IO;

namespace QuestionForm.Controllers
{
    public class QuestionController : Controller
    {
        private QuestionDBContext dBContext = new QuestionDBContext();
        // GET: Question
        public ActionResult Index()
        {
            var questions = dBContext.Questions.ToList();
            return View(questions);
        }

        // GET: Question/Details/5
        public ActionResult Details(int id)
        {
            
            return View();
        }

        // GET: Question/Create
        public ActionResult Create()
        {
            
            return View();
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Question_ID, Question1, Option_1, Option_2, Option_3, Option_4, Question_Type")] Question ques)
        {
            if (ModelState.IsValid)
            {
                dBContext.Questions.Add(ques);
                dBContext.SaveChanges();
               
            }
            return RedirectToAction("Index");
        }
        // POST: Question/Create

        // GET: Question/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question ques = dBContext.Questions.Find(id);
            if (ques == null)
            {
                return HttpNotFound();
            }
            return View(ques);
        }

        // POST: Question/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Question_ID, Question1, Option_1, Option_2, Option_3, Option_4, Question_Type")] Question ques)
        {
            if (ModelState.IsValid)
            {
                dBContext.Entry(ques).State = EntityState.Modified;
                dBContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ques);
        }
        
        
        // GET: Question/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question ques = dBContext.Questions.Find(id);
            if (ques == null)
            {
                return HttpNotFound();
            }
            return View(ques);
        }

        // POST: Question/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Question que = dBContext.Questions.Find(id);
            dBContext.Questions.Remove(que);
            dBContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
