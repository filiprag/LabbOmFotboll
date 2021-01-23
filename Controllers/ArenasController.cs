using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using LabbOmFotboll.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
 
namespace LabbOmFotboll.Controllers
{
    public class ArenasController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Arena> ArenaList = new List<Arena>();
            using (var httpClient = new HttpClient())
            {
               string result= await httpClient.GetStringAsync("http://localhost:50432/api/Arenas");
               ArenaList = JsonConvert.DeserializeObject<List<Arena>>(result);

            }
            return View(ArenaList);
        }
    }
}


//using (var response = await httpClient.GetAsync("http://localhost:50432/api/Arenas"))
//{
//    string apiResponse = await response.Content.ReadAsStringAsync();
//    ArenaList = JsonConvert.DeserializeObject<List<Arena>>(apiResponse);
//}
