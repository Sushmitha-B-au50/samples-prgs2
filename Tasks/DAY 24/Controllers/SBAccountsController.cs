using BankClient.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BankClient.Controllers
{
    public class SBAccountsController : Controller
    {
        public async Task<IActionResult> Index()
        {
            string Baseurl = "http://localhost:13173/";
            var SBAccountInfo = new List<SBAccount>();
            //HttpClient cl = new HttpClient();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/SBAccounts");
                //Checking the response is successful or not which is sent using HttpClient  

                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   

                    var SBAccountResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    SBAccountInfo = JsonConvert.DeserializeObject<List<SBAccount>>(SBAccountResponse);

                }
                //returning the employee list to view  
                return View(SBAccountInfo);
            }
        }
        [HttpGet]

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(SBAccount p)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("http://localhost:13173/api/SBAccounts", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<SBAccount>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Details(int id)
        {
            SBAccount b = new SBAccount();
            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.GetAsync("http://localhost:13173/api/SBAccounts/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    b = JsonConvert.DeserializeObject<SBAccount>(apiResponse);
                }
            }
            return View(b);
        }
        public async Task<ActionResult> Delete(int id)
        {
            TempData["ID"] = id;
              SBAccount b = new SBAccount();
            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.GetAsync("http://localhost:13173/api/SBAccounts/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    b = JsonConvert.DeserializeObject<SBAccount>(apiResponse);
                }
            }
            return View(b);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(SBAccount p)
        {
            int vid = Convert.ToInt32(TempData["ID"]);
            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.DeleteAsync("http://localhost:13173/api/SBAccounts/" + vid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                }
            }
            return RedirectToAction("Index");
        }


        public async Task<ActionResult> Edit(int id)
        {
            TempData["ID"] = id;
            SBAccount b = new SBAccount();
            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.GetAsync("http://localhost:13173/api/SBAccounts/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    b = JsonConvert.DeserializeObject<SBAccount>(apiResponse);
                }
            }
            return View(b);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(SBAccount p)
        {
            int vid = Convert.ToInt32(TempData["ID"]);
            p.Id = vid;
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync("http://localhost:13173/api/SBAccounts/" + vid, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<SBAccount>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }

    }

}

