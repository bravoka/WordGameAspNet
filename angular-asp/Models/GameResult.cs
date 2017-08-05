using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;


namespace angular_asp.Models {
	public class GameResult
	{
        [BindNever]
        public string GameId { get; set; }
        public string PlayerId { get; set; }
        public int Score { get;set;}
        public int IncorrectAnswers { get; set;}
        public DateTime DateTime { get; set; }

    public GameResult()
	    {
            
	    }
	}
}
