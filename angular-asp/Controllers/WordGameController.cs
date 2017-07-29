using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Routing;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace angular_asp 
{
    [Route("/api/[controller]")]
    public class WordGameController : Controller
    {
        [HttpGet]
        public JsonResult Get()
        {
            var json = JsonConvert.DeserializeObject(System.IO.File.ReadAllText("src/assets/words.json"));
            return Json(json);
        }
    }
}