

using System.Collections.Generic;
using System.Collections.ObjectModel;
using WordGame.Models;

namespace WordGame.Controllers.Resources
{

    public class UserResource
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public ICollection<GameResultResource> GameResults { get; set; }

        public UserResource()
        {
            GameResults = new Collection<GameResultResource>();
        }
}
}
