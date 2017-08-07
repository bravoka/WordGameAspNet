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
using System.Data.SqlClient;

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
            // TODO: Shuffle first
            return Json(JsonConvert.DeserializeObject(System.IO.File.ReadAllText("src/assets/words.json")));
        }

		[HttpGet]
		[Route("results")]
		public async Task<IActionResult> GetGameResultsAsync([FromHeader] string gameId)
		{
			GameResult result = await context.GameResults.Where(gr => gr.GameId == gameId).FirstAsync();

			GameResultResource gameResultResource = mapper.Map<GameResult, GameResultResource>(result);

			return Ok(gameResultResource);
		}

        [HttpPost]
        [Route("results")]
        public async Task<IActionResult> PostGameResultsAsync([FromBody] GameResultResource result, [FromHeader] string userName) 
        {            
            if (!result.Score.HasValue || result.Score < 0 || !result.IncorrectAnswers.HasValue || result.IncorrectAnswers < 0 || String.IsNullOrEmpty(userName))
            {
                return BadRequest();
            }

            GameResult gameResult = mapper.Map<GameResultResource, GameResult>(result);

            try
            {
                gameResult.UserId = await context.Users.Where(x => x.Username == userName).Select(y => y.Id).FirstOrDefaultAsync();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
                return Ok(ex.ToString());
            }                

			gameResult.GameId = Guid.NewGuid().ToString();

			gameResult.DateTime = DateTime.UtcNow;

            context.GameResults.Add(gameResult);

            await context.SaveChangesAsync();

            var savedGame = mapper.Map<GameResult, GameResultResource>(gameResult);

            return Ok(savedGame);
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