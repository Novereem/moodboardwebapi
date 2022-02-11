using System.Collections.Generic;
using System.Linq;
using mb.Common;
using mb.Common.Models;
using mb.Common.Models.ApiModels;

namespace mb.Data
{
    public class MoodboardData : IMoodboardData
    {
        private readonly IMbContext _mbContext;

        public MoodboardData(IMbContext mbContext)
        {
            _mbContext = mbContext;
        }

        public void AddMoodboard(ApiMoodboard apiMoodboard)
        {
            Moodboard moodboard = new Moodboard(apiMoodboard.Name, apiMoodboard.Account);
            _mbContext.Moodboards.Add(moodboard);
        }

        public List<Post> AddPost(Post post)
        {
            _mbContext.Posts.Add(post);
            _mbContext.SaveChanges();
            return _mbContext.Posts.Where(x => x.Id != null).ToList();
        }
    }
}