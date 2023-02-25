using BusinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;

namespace eStoreClient.Controllers
{
    public class LoginController : Controller
    {
        //to call and get api
        HttpResponseMessage response;
        string responseString;

        // GET: LoginController/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: LoginController/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Member member)
        {
            try
            {
                //check login
                response = GobalVariables.WebAPIClient.PostAsJsonAsync("Logins", member).Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    Member m = JsonConvert.DeserializeObject<Member>(responseString);

                    //check role
                    response = GobalVariables.WebAPIClient.PostAsJsonAsync("Logins/checkrole", member).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        responseString = response.Content.ReadAsStringAsync().Result;
                        string role = JsonConvert.DeserializeObject<string>(responseString);
                        HttpContext.Session.SetString("role", role);
                    }
                    //set variable in session when login success
                    HttpContext.Session.Set("IsLoggedIn", BitConverter.GetBytes(true));
                    HttpContext.Session.SetInt32("memberid", m.MemberId);
                    HttpContext.Session.SetString("email", m.Email);
                    
                    return RedirectToAction("Index", "Home");
                }
            }
            catch { }
            ViewData["mess"] = "Login faill...";
            return View();
        }

        // GET: LoginController/Register
        public ActionResult Logout()
        {
            //clear session and return login
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Login));
        }

        // GET: LoginController/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: LoginController/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(MemberRegister memberRegiser)
        {
            Member member = memberRegiser;
            try
            {
                response = GobalVariables.WebAPIClient.PostAsJsonAsync("Members", member).Result;
                if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Login));
            }
            catch { }
            ViewData["mess"] = "Register faill...";
            return View();
        }
    }
}
