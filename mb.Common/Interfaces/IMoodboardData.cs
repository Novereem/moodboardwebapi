using System.Collections.Generic;
using mb.Common.Models;
using mb.Common.Models.ApiModels;

namespace mb.Common
{
    public interface IMoodboardData
    {
        public void AddMoodboard(ApiMoodboard apiMoodboard);
        public List<Post> AddPost(Post post);
    }
}