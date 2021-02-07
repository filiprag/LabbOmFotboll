using LabbOmFotboll.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace LabbOmFotboll.Controllers
{
    public class ArenasController : Controller
    {
        public async Task<IActionResult> Index()
        {
            try
            {

                List<Arena> ArenaList = new List<Arena>();
                using (var httpClient = new HttpClient())
                {
                    string result = await httpClient.GetStringAsync("http://localhost:50432/api/Arenas");
                    ArenaList = JsonConvert.DeserializeObject<List<Arena>>(result);

                }
                return View(ArenaList);

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return RedirectToAction("Index", "Home");
            }
        }


    }
}


