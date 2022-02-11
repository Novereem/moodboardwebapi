using System.Collections.Generic;
using System.Net.Cache;
using mb.Common.Models;
using mb.Common.Models.ApiModels;
using mb.Data;
using mb.Logic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace moodboardwebapi.Controllers
{
    [EnableCors("AllowCors")]
    [ApiController]
    [Route("[controller]")]
    public class MoodboardController
    {
        private readonly MoodboardService _moodboardService;

        public MoodboardController(MbContext mbContext)
        {
            _moodboardService = new MoodboardService(new MoodboardData(mbContext));
        }
        
        /*
        [HttpPost("/moodboard/newpost/{token}")]
        public void AddRecipe(IFormCollection collection)
        {
            var image = Request.Form.Files[0];
            
            ApiRecipeUpload model = new()
            {
                Name = collection["name"],
                Carbs = collection["carbs"],
                Description = collection["description"],
                Ingredients = collection["ingredients"],
                Preparation = collection["preparation"]
            };
            _recipeLogic.AddNewRecipe(model, image, _environment.WebRootPath);
        }
        */
        
        
        [HttpPost("/moodboard/new")]
        public void AddMoodboard(ApiMoodboard apiMoodboard)
        {
            _moodboardService.AddMoodboard(apiMoodboard);
        }

        [HttpPost("/moodboard/newpost")]
        public List<Post> AddPost(ApiPost apiPost)
        {
            List<Post> posts = _moodboardService.AddPost(apiPost);
            return posts;
        }
    }
}