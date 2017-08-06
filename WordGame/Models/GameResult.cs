using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WordGame.Models 
{
    [Table("GameResults")]
	public class GameResult
	{
        public int Id { get; set; }
		//[BindNever]
		[Required]
		[StringLength(255)]
        public string GameId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public int Score { get;set;}
        public int IncorrectAnswers { get; set;}
        public DateTime DateTime { get; set; }

    public GameResult()
	    {
            
	    }
	}
}
