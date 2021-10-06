using crudMVC.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace crudMVC.Controllers
{
    public class StudentController : Controller
    {
        CrudMVCEntities dbObj = new CrudMVCEntities();

        // GET: Student
        public ActionResult Student()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Student(MVCstudent obj) {
            if (obj != null)
            {
                return View(obj);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult AddStudent(MVCstudent model) {
            MVCstudent obj = new MVCstudent();
            
            obj.Name = model.Name;
            obj.ID = model.ID;
            obj.Mobile = model.Mobile;
            obj.Fname = model.Fname;
            obj.Email = model.Email;
            obj.Description = model.Description;
            if (model.ID == 0)
            {
                dbObj.MVCstudent.Add(obj);
                dbObj.SaveChanges();
            }
            else {
                dbObj.Entry(obj).State = System.Data.EntityState.Modified;
                dbObj.SaveChanges();
            }
            ModelState.Clear();
            return View("Student");
        }
        public ActionResult StudentList() {
            var res = dbObj.MVCstudent.ToList();
            return View(res);
        }
        public ActionResult Delete(int id) {
            var res = dbObj.MVCstudent.Where(x => x.ID == id).First();
            dbObj.MVCstudent.Remove(res);
            dbObj.SaveChanges();
            var list = dbObj.MVCstudent.ToList();

            return View("StudentList");
        }
    }
}