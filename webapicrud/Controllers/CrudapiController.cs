using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using System.Web.Http;
using webapicrud.Models;

namespace webapicrud.Controllers
{
    public class CrudapiController : ApiController
    {
        webapicruddbEntities db = new webapicruddbEntities();
        [System.Web.Http.HttpGet]
        public IHttpActionResult Getemployee()
        {
            List<Employee> list = db.Employees.ToList();
            return Ok(list);        }
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetemployeebyID(int id )
        {
            var emp = db.Employees.Where(model => model.id == id).FirstOrDefault();
            return Ok(emp);
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult empinsert(Employee e)
        {
            db.Employees.Add(e);
            db.SaveChanges();
            return Ok();
        }
         [System.Web.Http.HttpPut]
        public IHttpActionResult empupdate(Employee e)
        {
            db.Entry(e).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
                //var emp = db.Employees.Where(model => model.id == e.id).FirstOrDefault();

            //if (emp != null)
            //{

            //    emp.id = e.id;
            //    emp.name = e.name;
            //    emp.gender = e.gender;
            //    emp.age = e.age;
            //    emp.designation = e.designation;
            //    emp.salary = e.salary;
            //    db.SaveChanges();
            //}
            //else
            //{

            //    return NotFound();

            
          //  }

                return Ok();
        }
    }
}
