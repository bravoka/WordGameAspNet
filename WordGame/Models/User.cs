using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordGame.Models
{
	[Table("Users")]
	public class User
	{
		public int Id { get; set; }
		[Required]
		[StringLength(255)]
		public string Email { get; set; }
		[Required]
		[StringLength(255)]
		public string Username { get; set; }
		public ICollection<GameResult> GameResults { get; set; }

		public User()
		{
			GameResults = new Collection<GameResult>();
		}
}
}
