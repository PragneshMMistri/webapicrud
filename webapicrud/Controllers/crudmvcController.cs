using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using webapicrud.Models;
namespace webapicrud.Controllers
{
    public class crudmvcController : Controller
    {
        HttpClient client = new HttpClient();
        // GET: crudmvc
        public ActionResult Index()
        {
            List<Employee> emp_list = new List<Employee>();
            client.BaseAddress = new Uri("https://localhost:44375/api/Crudapi");
            var responce = client.GetAsync("Crudapi");
            responce.Wait();
            var test = responce.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Employee>>();
                display.Wait();
                emp_list = display.Result;
            }
            return View(emp_list);
        }
        public ActionResult create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult create(Employee emp )
        {
            client.BaseAddress = new Uri("https://localhost:44375/api/Crudapi");
            var responce = client.PostAsJsonAsync<Employee>("Crudapi",emp);
            responce.Wait();
            var test = responce.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("create");
        }

        public ActionResult details(int id )
        {
            Employee e = null;
            client.BaseAddress = new Uri("https://localhost:44375/api/Crudapi");
            var responce = client.GetAsync("Crudapi?id=" + id.ToString());
            responce.Wait();
            var test = responce.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Employee>();
                display.Wait();
                e = display.Result;

            }
              return View(e);
        }

        public ActionResult edit(int id)
        {
            Employee e = null;
            client.BaseAddress = new Uri("https://localhost:44375/api/Crudapi");
            var responce = client.GetAsync("Crudapi?id=" + id.ToString());
            responce.Wait();
            var test = responce.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Employee>();
                display.Wait();
                e = display.Result;
            }
            return View(e);
        }
        [HttpPost]
        public ActionResult edit(Employee e)
        {
            client.BaseAddress = new Uri("https://localhost:44375/api/Crudapi");
            var responce = client.PutAsJsonAsync<Employee>("Crudapi", e);
            responce.Wait();
            var test = responce.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("edit");
        }

       
        public ActionResult delete(int id)
        {
            Employee e = null;
            client.BaseAddress = new Uri("https://localhost:44375/api/Crudapi");
            var responce = client.GetAsync("Crudapi?id=" + id.ToString());
            responce.Wait();
            var test = responce.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Employee>();
                display.Wait();
                e = display.Result;
            }
            return View(e);
        }
        [HttpPost, ActionName("Delete") ]
        public ActionResult deleteconfirm(int id)
        {

            client.BaseAddress = new Uri("https://localhost:44375/api/Crudapi");
            var responce = client.DeleteAsync("Crudapi/" + id.ToString() );
            responce.Wait();
            var test = responce.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Delete");


        }
        }
}