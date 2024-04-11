using CIPLATFORM.Common;
using CIPlatform.DAL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using CIPlatform.BAL.Interfaces;
using CIPlatform.DAL.Models;

namespace CIPLATFORM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoryController : Controller
    {
        private readonly IStoryService _storyService;

        public StoryController(IStoryService storyService)
        {
            _storyService = storyService;
        }

        [HttpGet("GetStory")]
        public ActionResult GetStory()
        {
            List<StoryDTO> storyList = _storyService.GetStoryByFilter();
            return storyList != null
                ? this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }, storyList))
                : (ActionResult)this.Ok(new ApiResponse(HttpStatusCode.NoContent, new List<string> { Constants.NO_DATA }));
        }

        [HttpGet("GetStoryById/{storyId}")]
        public ActionResult GetStoryById(long storyId)
        {
            var story = _storyService.GetStoryById(storyId);

            return story != null
                ? this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }, story))
                : (ActionResult)this.Ok(new ApiResponse(HttpStatusCode.NoContent, new List<string> { Constants.NO_DATA }));
        }
    }
}
