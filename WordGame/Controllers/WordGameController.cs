using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WordGame.Models;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection.PortableExecutable;
using AutoMapper;
using WordGame.Persistence;
using WordGame.Controllers.Resources;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WordGame 
{
    [Route("/api/[controller]")]
    public class WordGameController : Controller
    {
        private readonly IMapper mapper;
        private readonly GameDbContext context;

        public WordGameController(GameDbContext context, IMapper mapper) 
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet]
        public JsonResult GetNewGame()
        {
            // Shuffle first
            return Json(JsonConvert.DeserializeObject(System.IO.File.ReadAllText("src/assets/words.json")));
        }

        //[HttpPost]
        //public string AddGameResults([Bind("UserId, Score, IncorrectAnswers")] GameResultResource result)
        //{
        //    //var logFile = System.IO.File.Create($"/Users/keyan/players/{result.PlayerId}.txt",2048,new FileOptions({FileMode.Append}));
        //    var logFile = ($"/Users/keyan/players/{result.UserId}.txt");
        //    var fileStream = new FileStream(logFile, FileMode.Append);
        //    var gameId = Guid.NewGuid();
        //    result.GameId = gameId.ToString();
        //    var dateTime = DateTime.UtcNow;
        //    using (var fileWriter = new StreamWriter(fileStream))
        //    {
        //        fileWriter.Write($"{gameId},{dateTime},{result.Score},{result.IncorrectAnswers}" + "\n");
        //    }

        //    return $"Result Logged: #gameId";
        //}

        [HttpPost]
        [Route("results")]
        public IActionResult PostGameResults([FromBody] GameResultResource result) 
        {
            return Ok(result);
        }

        [HttpGet]
        [Route("results")]
        //public JsonResult GetGameResults([FromHeader] string gameId, [FromHeader] string playerId)
        public async Task<IActionResult> GetGameResultsAsync([FromHeader] string gameId)
        {
            GameResult result = await context.GameResults.Where(gr => gr.GameId == gameId).FirstAsync();

            GameResultResource gameResultResource = mapper.Map<GameResult, GameResultResource>(result);

            return Ok(gameResultResource);
        }

        [HttpGet]
        [Route("user")]
        public async Task<IActionResult> GetUserHistoryAsync([FromHeader] string userName)
        {
            User result = await context.Users.Where(ur => ur.Username == userName).Include(x => x.GameResults).FirstOrDefaultAsync();

            UserResource userResource = mapper.Map<User, UserResource>(result); 

            return Ok(userResource);
        }
    }


}