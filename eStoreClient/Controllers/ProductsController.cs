using BusinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Net.Http;
using System.Linq;
using System;

namespace eStoreClient.Controllers
{
    [SessionCheck]
    public class ProductsController : Controller
    {
        HttpResponseMessage response;
        string responseString;

        // GET: ProductController
        public ActionResult Index(string content)
        {
            IEnumerable<Product> products = new List<Product>();

            try
            {
                response = GobalVariables.WebAPIClient.GetAsync("Products").Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    products = JsonConvert.DeserializeObject<IEnumerable<Product>>(responseString);
                }
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }

            //search
            if (!string.IsNullOrEmpty(content))
            {
                int price = 0;
                try
                {
                    price = int.Parse(content);
                }
                catch { }

                products = products.Where(x => x.ProductName.ToLower().Contains(content.ToLower()) 
                    || x.UnitPrice == price);
            }

            ViewBag.content = content;

            return View(products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                response = GobalVariables.WebAPIClient.GetAsync($"Products/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    Product product = new();
                    product = JsonConvert.DeserializeObject<Product>(responseString);
                    return View(product);
                }
            }
            catch { }

            return RedirectToAction(nameof(Index));
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            if (!HttpContext.Session.GetString("role").Contains("admin"))
                return RedirectToAction("Index", "Home");

            try
            {
                response = GobalVariables.WebAPIClient.GetAsync("Categorys").Result;
                List<Category> categorys = new List<Category>();
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    categorys = JsonConvert.DeserializeObject<List<Category>>(responseString);
                }

                ViewData["CategoryId"] = new SelectList(categorys, "CategoryId", "CategoryName");
                return View();
            }
            catch { }

            return RedirectToAction(nameof(Index));
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (!HttpContext.Session.GetString("role").Contains("admin"))
                return RedirectToAction("Index", "Home");

            try
            {
                response = GobalVariables.WebAPIClient.PostAsJsonAsync("Products", product).Result;
                if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
            }
            catch { }

            return RedirectToAction(nameof(Create));
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!HttpContext.Session.GetString("role").Contains("admin"))
                return RedirectToAction("Index", "Home");

            try
            {
                response = GobalVariables.WebAPIClient.GetAsync($"Products/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    Product product = new();
                    product = JsonConvert.DeserializeObject<Product>(responseString);

                    response = GobalVariables.WebAPIClient.GetAsync("Categorys").Result;
                    List<Category> categorys = new List<Category>();
                    if (response.IsSuccessStatusCode)
                    {
                        responseString = response.Content.ReadAsStringAsync().Result;
                        categorys = JsonConvert.DeserializeObject<List<Category>>(responseString);
                    }
                    ViewData["CategoryId"] = new SelectList(categorys, "CategoryId", "CategoryName");
                    return View(product);
                }
            }
            catch { }

            return RedirectToAction(nameof(Index));
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product)
        {
            if (!HttpContext.Session.GetString("role").Contains("admin"))
                return RedirectToAction("Index", "Home");

            try
            {
                response = GobalVariables.WebAPIClient.PutAsJsonAsync($"Products/{id}", product).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Details), new { id });
                }
            }
            catch { }

            return RedirectToAction(nameof(Index));
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            if (!HttpContext.Session.GetString("role").Contains("admin"))
                return RedirectToAction("Index", "Home");

            try
            {
                response = GobalVariables.WebAPIClient.GetAsync($"Products/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    Product product = new();
                    product = JsonConvert.DeserializeObject<Product>(responseString);
                    return View(product);
                }
            }
            catch { }

            return RedirectToAction(nameof(Index));
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if (!HttpContext.Session.GetString("role").Contains("admin"))
                return RedirectToAction("Index", "Home");

            try
            {
                response = GobalVariables.WebAPIClient.DeleteAsync($"Products/{id}").Result;
                if (response.IsSuccessStatusCode)
                    return RedirectToAction(nameof(Index));
            }
            catch { }

            return RedirectToAction(nameof(Index));
        }
    }
}
