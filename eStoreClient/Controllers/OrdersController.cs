using BusinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System;

namespace eStoreClient.Controllers
{
    [SessionCheck]
    public class OrdersController : Controller
    {
        HttpResponseMessage response;
        string responseString;

        // GET: OrderController
        public ActionResult Index()
        {

            IEnumerable<Order> orders = new List<Order>();
            try
            {
                response = GobalVariables.WebAPIClient.GetAsync("Orders").Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    orders = JsonConvert.DeserializeObject<IEnumerable<Order>>(responseString);
                }
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }

            int memberId = (int)HttpContext.Session.GetInt32("memberid");
            if (memberId != 0)
            {
                orders = orders.Where(x => x.MemberId == memberId).ToList();
            }

            return View(orders);
        }

        public ActionResult Report(DateTime? startDate, DateTime? endDate)
        {
            if (!HttpContext.Session.GetString("role").Contains("admin"))
                return RedirectToAction("Index", "Home");

            IEnumerable<Order> orders = new List<Order>();
            try
            {
                response = GobalVariables.WebAPIClient.GetAsync("Orders").Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    orders = JsonConvert.DeserializeObject<IEnumerable<Order>>(responseString);
                }
            }
            catch
            {
                return RedirectToAction("Index", nameof(HomeController));
            }

            //filter date
            if (startDate != null && endDate != null)
            {
                orders = orders.Where(x => x.OrderDate >= startDate && x.OrderDate <= endDate).ToList();
            }

            //set list total order and sum price
            var listTotal = orders.Select(o => new OrderTotal 
                { 
                    Order = o, 
                    Total = o.OrderDetails
                        .Sum(od => od.UnitPrice * od.Quantity - (od.UnitPrice * od.Quantity * od.Discount / 100)) 
                })
                .OrderByDescending(x => x.Total).ToList();
            
            ViewBag.startDate = startDate;
            ViewBag.endDate = endDate;

            return View(listTotal);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return RedirectToAction("Index", "OrderDetails", new { orderid = id });
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            if (!HttpContext.Session.GetString("role").Contains("admin"))
                return RedirectToAction("Index", "Home");

            try
            {
                response = GobalVariables.WebAPIClient.GetAsync("Members").Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    List<Member> members = new();
                    members = JsonConvert.DeserializeObject<List<Member>>(responseString);
                    ViewData["MemberId"] = new SelectList(members, "MemberId", "CompanyName");
                    return View();
                }
            }
            catch { }

            return RedirectToAction("Index", "Home");
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order)
        {
            if (!HttpContext.Session.GetString("role").Contains("admin"))
                return RedirectToAction("Index", "Home");
            try
            {
                response = GobalVariables.WebAPIClient.PostAsJsonAsync("Orders", order).Result;
                if (response.IsSuccessStatusCode)
                    return RedirectToAction(nameof(Index));
            }
            catch { }
            ViewData["mess"] = "Create order faill..";
            return View();
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!HttpContext.Session.GetString("role").Contains("admin"))
                return RedirectToAction("Index", "Home");

            try
            {
                response = GobalVariables.WebAPIClient.GetAsync($"Orders/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    Order order = new();
                    order = JsonConvert.DeserializeObject<Order>(responseString);

                    response = GobalVariables.WebAPIClient.GetAsync("Members").Result;
                    List<Member> members = new List<Member>();
                    if (response.IsSuccessStatusCode)
                    {
                        responseString = response.Content.ReadAsStringAsync().Result;
                        members = JsonConvert.DeserializeObject<List<Member>>(responseString);
                    }
                    ViewData["MemberId"] = new SelectList(members, "MemberId", "CompanyName");

                    return View(order);
                }
            }
            catch { }

            return RedirectToAction(nameof(Index));
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Order order)
        {
            if (!HttpContext.Session.GetString("role").Contains("admin"))
                return RedirectToAction("Index", "Home");

            try
            {
                response = GobalVariables.WebAPIClient.PutAsJsonAsync($"Orders/{id}", order).Result;
                if (response.IsSuccessStatusCode)
                    return RedirectToAction(nameof(Details), new { id });
            }
            catch { }

            return RedirectToAction("Index", "Home");
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            if (!HttpContext.Session.GetString("role").Contains("admin"))
                return RedirectToAction("Index", "Home");

            try
            {
                response = GobalVariables.WebAPIClient.GetAsync($"Orders/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    Order order = new();
                    order = JsonConvert.DeserializeObject<Order>(responseString);
                    return View(order);
                }
            }
            catch { }

            return RedirectToAction("Index", "Home");
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if (!HttpContext.Session.GetString("role").Contains("admin"))
                return RedirectToAction("Index", "Home");

            try
            {
                response = GobalVariables.WebAPIClient.DeleteAsync($"Orders/{id}").Result;
                if (response.IsSuccessStatusCode)
                    return RedirectToAction(nameof(Index));
            }
            catch { }

            return RedirectToAction("Index", "Home");
        }
    }
}
