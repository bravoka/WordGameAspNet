using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using angular_asp.Models;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection.PortableExecutable;

namespace angular_asp 
{
    [Route("/api/[controller]")]
    public class WordGameController : Controller
    {
        [HttpGet]
        public JsonResult GetNewGame()
        {
            var json = JsonConvert.DeserializeObject(System.IO.File.ReadAllText("src/assets/words.json"));
            return Json(json);
        }

        [HttpPost]
        public string PostGameResults([Bind("PlayerId, Score, IncorrectAnswers, DateTime")] GameResult result)
        {
            //var logFile = System.IO.File.Create($"/Users/keyan/players/{result.PlayerId}.txt",2048,new FileOptions({FileMode.Append}));
            var logFile = ($"/Users/keyan/players/{result.PlayerId}.txt");
            var fileStream = new FileStream(logFile, FileMode.Append);
            var gameId = Guid.NewGuid();
            result.GameId = gameId.ToString();
            using (var fileWriter = new StreamWriter(fileStream))
            {
                fileWriter.Write($"{gameId},{result.DateTime},{result.Score},{result.IncorrectAnswers}" + "\n");
            }
            return $"Result Logged: {gameId}";
        }

        [HttpGet]
        [Route("results")]
        public JsonResult GetGameResults([FromHeader] string gameId, [FromHeader] string playerId) 
        {
            // Hmm... This is where I need relational databases
            var logFile = ($"/Users/keyan/players/{playerId}.txt");
            var resultCsv = System.IO.File.ReadAllText(logFile).Split(',');
            var resultObject = new GameResult
            {
                GameId = gameId,
                PlayerId = playerId,
                DateTime = DateTime.Parse(resultCsv[1]),
                Score = int.Parse(resultCsv[2]),
                IncorrectAnswers = int.Parse(resultCsv[3])
            };
            return Json(resultObject); 
        }
    }


}