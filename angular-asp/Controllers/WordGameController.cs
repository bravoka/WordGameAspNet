using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using angular_asp.Models;
using System.IO;

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

        [HttpPost]
        public string Post([Bind("PlayerId, Score, IncorrectAnswers, DateTime")] GameResult result)
        {
            //var logFile = System.IO.File.Create($"/Users/keyan/players/{result.PlayerId}.txt",2048,new FileOptions({FileMode.Append}));
			var logFile = ($"/Users/keyan/players/{result.PlayerId}.txt");
            var fileStream = new FileStream(logFile, FileMode.Append);

			using (var fileWriter = new StreamWriter(fileStream)) {
                fileWriter.Write($"{result.DateTime},{result.Score},{result.IncorrectAnswers}"+"\n");
            }

            return "Result Logged";
        }
    }


}