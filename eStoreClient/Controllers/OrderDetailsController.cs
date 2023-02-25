using BusinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Net.Http;
using System.Linq;

namespace eStoreClient.Controllers
{
    [SessionCheck]
    public class OrderDetailsController : Controller
    {
        HttpResponseMessage response;

        // GET: OrderDetailController
        public ActionResult Index(int? orderid)
        {
            int memberid = (int)HttpContext.Session.GetInt32("memberid");

            if (memberid != 0 && orderid == null)
                return RedirectToAction("Index", "Home");

            IEnumerable<OrderDetail> orderDetails = new List<OrderDetail>();

            try
            {
                response = GobalVariables.WebAPIClient.GetAsync("OrderDetails").Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseString = response.Content.ReadAsStringAsync().Result;
                    orderDetails = JsonConvert.DeserializeObject<IEnumerable<OrderDetail>>(responseString);
                }
                if (orderid != null)
                {
                    orderDetails = orderDetails.Where(x => x.OrderId == orderid);
                }

                if (memberid != 0)
                {
                    orderDetails = orderDetails.Where(x => x.Order.MemberId == memberid);
                }
                return View(orderDetails);
            }
            catch { }

            return RedirectToAction("Index", "Home");


        }

        // GET: OrderDetailController/Details/5
        public ActionResult Details(int propId, int orderId)
        {
            if (!HttpContext.Session.GetString("role").Contains("admin"))
                return RedirectToAction("Index", "Home");

            try
            {
                response = GobalVariables.WebAPIClient.GetAsync($"OrderDetails/{propId}/{orderId}").Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseString = response.Content.ReadAsStringAsync().Result;
                    OrderDetail orderDetail = new();
                    orderDetail = JsonConvert.DeserializeObject<OrderDetail>(responseString);
                    return View(orderDetail);
                }
            }
            catch { }

            return RedirectToAction(nameof(Index));
        }

        // GET: OrderDetailController/Create
        public ActionResult Create()
        {
            if (!HttpContext.Session.GetString("role").Contains("admin"))
                return RedirectToAction("Index", "Home");

            try
            {
                //task 1 
                List<Product> products = new();
                response = GobalVariables.WebAPIClient.GetAsync("Products").Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseString = response.Content.ReadAsStringAsync().Result;
                    products = JsonConvert.DeserializeObject<List<Product>>(responseString);
                }
                ViewData["ProductId"] = new SelectList(products, "ProductId", "ProductName");

                //task 2
                response = GobalVariables.WebAPIClient.GetAsync("Orders").Result;
                List<Order> orders = new();
                if (response.IsSuccessStatusCode)
                {
                    string responseString = response.Content.ReadAsStringAsync().Result;
                    orders = JsonConvert.DeserializeObject<List<Order>>(responseString);
                }
                ViewData["OrderId"] = new SelectList(orders, "OrderId", "OrderId");

                return View();
            }
            catch { }

            return RedirectToAction(nameof(Index));
        }

        // POST: OrderDetailController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderDetail orderDetail)
        {
            if (!HttpContext.Session.GetString("role").Contains("admin"))
                return RedirectToAction("Index", "Home");

            try
            {
                response = GobalVariables.WebAPIClient.PostAsJsonAsync("OrderDetails", orderDetail).Result;
                if (response.IsSuccessStatusCode)
                    return RedirectToAction(nameof(Index));
            }
            catch { }

            return RedirectToAction(nameof(Create));
        }

        // GET: OrderDetailController/Edit/5
        public ActionResult Edit(int propId, int orderId)
        {
            if (!HttpContext.Session.GetString("role").Contains("admin"))
                return RedirectToAction("Index", "Home");

            try
            {
                response = GobalVariables.WebAPIClient.GetAsync($"OrderDetails/{propId}/{orderId}").Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseString = response.Content.ReadAsStringAsync().Result;
                    OrderDetail orderDetail = new();
                    orderDetail = JsonConvert.DeserializeObject<OrderDetail>(responseString);

                    return View(orderDetail);
                }
            }
            catch { }

            return RedirectToAction(nameof(Index));
        }

        // POST: OrderDetailController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int propId, int orderId, OrderDetail orderDetail)
        {
            if (!HttpContext.Session.GetString("role").Contains("admin"))
                return RedirectToAction("Index", "Home");

            try
            {
                response = GobalVariables.WebAPIClient.PutAsJsonAsync($"OrderDetails/{orderDetail.ProductId}/{orderDetail.OrderId}", orderDetail).Result;
                if (response.IsSuccessStatusCode)
                    return RedirectToAction(nameof(Details), new { propId = orderDetail.ProductId, orderId = orderDetail.OrderId });
            }
            catch { }

            return RedirectToAction(nameof(Index));
        }

        // GET: OrderDetailController/Delete/5
        public ActionResult Delete(int propId, int orderId)
        {
            if (!HttpContext.Session.GetString("role").Contains("admin"))
                return RedirectToAction("Index", "Home");

            try
            {
                response = GobalVariables.WebAPIClient.GetAsync($"OrderDetails/{propId}/{orderId}").Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseString = response.Content.ReadAsStringAsync().Result;
                    OrderDetail orderDetail = new OrderDetail();
                    orderDetail = JsonConvert.DeserializeObject<OrderDetail>(responseString);
                    return View(orderDetail);
                }
            }
            catch { }

            return RedirectToAction(nameof(Index));
        }

        // POST: OrderDetailController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int propId, int orderId, IFormCollection collection)
        {
            if (!HttpContext.Session.GetString("role").Contains("admin"))
                return RedirectToAction("Index", "Home");

            try
            {
                response = GobalVariables.WebAPIClient.DeleteAsync($"OrderDetails/{propId}/{orderId}").Result;
                if (response.IsSuccessStatusCode)
                    return RedirectToAction(nameof(Index));
            }
            catch { }

            return RedirectToAction("Index", "Home");
        }
    }
}
