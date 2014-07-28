using System;
using System.Linq;
using System.Web.Mvc;
using FluentNhibernateMVC.Models;
using NHibernate;
using NHibernate.Linq;

namespace FluentNhibernateMVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var employees = session.Query<Employee>().ToList();
                return View(employees);
            }
            return View();
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var employee = session.Get<Employee>(id);
                return View(employee);
            }
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(employee);
                        transaction.Commit();
                    }
                }

                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var employee = session.Get<Employee>(id);
                return View(employee);
            }
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var employeetoUpdate = session.Get<Employee>(id);

                    employeetoUpdate.Designation = employee.Designation;
                    employeetoUpdate.FirstName = employee.FirstName;
                    employeetoUpdate.LastName = employee.LastName;

                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(employeetoUpdate);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var employee = session.Get<Employee>(id);
                return View(employee);
            }
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Employee employee)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(employee);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                return View();
            }
        }
    }
}
