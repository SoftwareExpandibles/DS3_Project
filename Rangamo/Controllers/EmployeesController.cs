using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data.Models;
using Models;
using Data;
using Services;

namespace Rangamo.Controllers
{
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private IRangamoRepository _rangamoRepository;

        public EmployeesController()
        {
            this._rangamoRepository=new RangamoRepository(new ApplicationDbContext());
        }

        // GET: Employees
        public ActionResult Index()
        {
            var employees = _rangamoRepository.GetAllEmployees();
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {

            ViewBag.FileId = new SelectList(db.Sms, "FileId", "FileName");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "employeeID,Title,FirstName,LastName,IdNo,DateOfBirth,hireDate,Role,empno,Salary,Email,Phone,Address,Province,City,postalCode,FileId")] Employee employee, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    var avatar = new File
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = FileType.Avatar,
                        ContentType = upload.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        avatar.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    employee.Files = new List<File> { avatar };
                }
                _rangamoRepository.CreateEmployee(employee);
                _rangamoRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.FileId = new SelectList(_rangamoRepository.GetAllEmployees(), "FileId", "FileName", employee.FileId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.FileId = new SelectList(db.Sms, "FileId", "FileName", employee.FileId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "employeeID,Title,FirstName,LastName,IdNo,DateOfBirth,hireDate,Role,empno,Salary,Email,Phone,Address,Province,City,postalCode,FileId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
               _rangamoRepository.UpdateEmployee(employee);
                _rangamoRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.FileId = new SelectList(_rangamoRepository.GetAllEmployees(), "FileId", "FileName", employee.FileId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            _rangamoRepository.DeleteEmployee(id);
            _rangamoRepository.Save();
            return RedirectToAction("Index");
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
