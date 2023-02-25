using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Net.Http;
using BusinessObject;

namespace eStoreClient.Controllers
{
    [SessionCheck]
    public class MembersController : Controller
    {
        HttpResponseMessage response;
        string responseString;

        // GET: MemberController
        public ActionResult Index()
        {
            //check in session user is admin
            if (!HttpContext.Session.GetString("role").Contains("admin")) return RedirectToAction("Index", "Home");

            try
            {
                response = GobalVariables.WebAPIClient.GetAsync("Members").Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    IEnumerable<Member> members = new List<Member>();
                    members = JsonConvert.DeserializeObject<IEnumerable<Member>>(responseString);
                    return View(members);
                }
            }
            catch { }

            ViewData["mess"] = "Fail get index member";

            return RedirectToAction("Index", "Home");
        }

        // GET: MemberController/Details/5
        public ActionResult Details(int? id)
        {
            int memberid = (int)HttpContext.Session.GetInt32("memberid");

            //check not admin => not view other profile
            if (id != null && id != memberid && memberid != 0) return RedirectToAction("Index", "Home");

            //set id = memberid is id null
            id ??= memberid;

            try
            {
                response = GobalVariables.WebAPIClient.GetAsync($"Members/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    Member member = new();
                    member = JsonConvert.DeserializeObject<Member>(responseString);
                    return View(member);
                }

            }
            catch { return RedirectToAction(nameof(Index)); }

            ViewData["mess"] = "Fail detail member";

            return RedirectToAction(nameof(Index));
        }

        // GET: MemberController/Create
        public ActionResult Create()
        {
            if (!HttpContext.Session.GetString("role").Contains("admin")) return RedirectToAction("Index", "Home");
            return View();
        }

        // POST: MemberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Member member)
        {
            if (!HttpContext.Session.GetString("role").Contains("admin")) return RedirectToAction("Index", "Home");

            try
            {
                response = GobalVariables.WebAPIClient.PostAsJsonAsync("Members", member).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch { }

            ViewData["mess"] = "Fail create member";

            return RedirectToAction(nameof(Index));
        }

        // GET: MemberController/Edit/5
        public ActionResult Edit(int? id)
        {
            int memberid = (int)HttpContext.Session.GetInt32("memberid");

            //check not admin => not edit other profile
            if (id != null && id != memberid && memberid != 0) return RedirectToAction("Index", "Home");

            //set id = memberid is id null
            id ??= memberid;

            try
            {
                response = GobalVariables.WebAPIClient.GetAsync($"Members/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    Member member = new();
                    member = JsonConvert.DeserializeObject<Member>(responseString);
                    return View(member);
                }
            }
            catch { }

            ViewData["mess"] = "Fail edit member";

            return RedirectToAction(nameof(Index));
        }

        // POST: MemberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, Member member)
        {
            int memberid = (int)HttpContext.Session.GetInt32("memberid");

            //check not admin => not edit other profile
            if (id != null && id != memberid && memberid != 0) return RedirectToAction("Index", "Home");

            //set id = memberid is id null
            id ??= memberid;

            try
            {
                response = GobalVariables.WebAPIClient.PutAsJsonAsync($"Members/{id}", member).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Details), new { id });
                }
            }
            catch { }

            ViewData["mess"] = "Fail edit member";

            return RedirectToAction(nameof(Index));
        }

        // GET: MemberController/Delete/5
        public ActionResult Delete(int id)
        {
            if (!HttpContext.Session.GetString("role").Contains("admin")) return RedirectToAction("Index", "Home");

            try
            {
                response = GobalVariables.WebAPIClient.GetAsync($"Members/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    Member member = new();
                    member = JsonConvert.DeserializeObject<Member>(responseString);
                    return View(member);
                }
            } catch { }

            ViewData["mess"] = "Fail delete member";

            return RedirectToAction(nameof(Index));
        }

        // POST: MemberController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if (!HttpContext.Session.GetString("role").Contains("admin")) return RedirectToAction("Index", "Home");

            try
            {
                response = GobalVariables.WebAPIClient.DeleteAsync($"Members/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch { }

            ViewData["mess"] = "Fail delete member";

            return RedirectToAction("Index", "Home");
        }
    }
}
