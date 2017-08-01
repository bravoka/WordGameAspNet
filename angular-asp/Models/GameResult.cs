using System;


namespace angular_asp.Models {
	public class GameResult
	{
        public string PlayerId { get; set; }
        public int Score { get;set;}
        public int IncorrectAnswers { get; set;}
        public DateTime DateTime { get; set; }

    public GameResult()
	    {
            
	    }
	}
}
