using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CIPlatform.BAL.Interfaces;
using CIPlatform.DAL.ViewModels;
using CIPLATFORM.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Angular_CIModule.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MissionController : ControllerBase
    {
        private readonly IMissionService _missionService;

        public MissionController(IMissionService missionService)
        {
            _missionService = missionService;
        }

        [HttpPost("GetMissionsByFilter")]
        [Authorize]
        public ActionResult GetMissionsByFilter([FromBody] MissionSearchDTO missionSearchDTO)
        {
            List<MissionListDTO> missionList = _missionService.GetMissionsByFilter(missionSearchDTO);
            return missionList != null
                ? this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }, missionList))
                : (ActionResult)this.Ok(new ApiResponse(HttpStatusCode.NoContent, new List<string> { Constants.NO_DATA }));
        }

        [HttpPost("AddToFavourite")]
        [Authorize]
        public ActionResult AddToFavourite(AddToFavouriteDTO addToFavouriteDTO)
        {
            bool result = _missionService.AddToFavourite(addToFavouriteDTO);
            return result
                ? this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }, result))
                : (ActionResult)this.Ok(new ApiResponse(HttpStatusCode.InternalServerError, new List<string> { Constants.ERROR }));
        }

        [HttpGet("GetVolunteeringMission/{missionId}/{userId}")]
        public ActionResult GetVolunteeringMission(long missionId, long userId)
        {
            VolunteeringMissionDTO mission = _missionService.GetVolunteeringMission(missionId, userId);

            return mission != null
                ? this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }, mission))
                : (ActionResult)this.Ok(new ApiResponse(HttpStatusCode.NoContent, new List<string> { Constants.NO_DATA }));
        }

        [HttpPost("SaveMissionApplication")]
        public ActionResult SaveMissionApplication([FromBody] MissionUserDTO application)
        {
            _missionService.SaveMissionApplication(application.MissionId, application.UserId);

            return this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }, true));
        }

        [HttpPost("SaveComment")]
        public ActionResult SaveComment([FromBody] CommentDTO application)
        {
            _missionService.SaveComment(application);

            return this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }, true));
        }

        [HttpPost("SaveRatings")]
        public ActionResult SaveRatings([FromBody] MissionRatingDTO ratings)
        {
            _missionService.SaveRatings(ratings);

            return this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }, true));
        }

        [HttpGet("checkMissionApplied/{missionId}/{userId}")]
        public ActionResult CheckMissionApplied(long missionId, int userId)
        {
            bool result = _missionService.CheckMissionApplied(missionId, userId);

            return result
                ? this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }, result))
                : (ActionResult)this.Ok(new ApiResponse(HttpStatusCode.InternalServerError, new List<string> { Constants.ERROR }));
        }

        [HttpPost("RecommandMissionToWorkers")]
        public ActionResult RecommandMissionToWorkers(int missionId, int userId, [FromBody] List<RecommandUserDTO> body)
        {
            bool result = _missionService.AddRecommandToWorker(missionId, userId, body);
            return result
                ? this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }, result))
                : (ActionResult)this.Ok(new ApiResponse(HttpStatusCode.InternalServerError, new List<string> { Constants.ERROR }));
        }

    }
}