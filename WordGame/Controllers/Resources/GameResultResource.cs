using System;
using System.ComponentModel.DataAnnotations;
using WordGame.Models;


namespace WordGame.Controllers.Resources
{

    public class GameResultResource
    {
        //public int Id { get; set; }

        public int UserId { get; set; }

        public string GameId { get; set; }

        public int? Score { get; set;}

        public int? IncorrectAnswers { get; set;}

        public DateTime DateTime { get; set; }
    }
}
