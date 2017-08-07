using System;
using Microsoft.EntityFrameworkCore;
using WordGame.Models;

namespace WordGame.Persistence
{
	public class GameDbContext : DbContext
	{
	    public GameDbContext(DbContextOptions options)
            :base(options)
	    {
	        
	    }

        public DbSet<User> Users { get; set; }
        public DbSet<GameResult> GameResults { get; set; }
    }
}
