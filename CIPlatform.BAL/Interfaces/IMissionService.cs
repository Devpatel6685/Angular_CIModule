using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIPlatform.DAL.ViewModels;

namespace CIPlatform.BAL.Interfaces
{
    public interface IMissionService
    {
        List<MissionListDTO> GetMissionsByFilter(MissionSearchDTO missionSearchDTO);

        VolunteeringMissionDTO GetVolunteeringMission(long missionId, long userId);

        bool AddToFavourite(AddToFavouriteDTO addToFavouriteDTO);

        void SaveMissionApplication(long missionId, int userId);

        void SaveComment(CommentDTO comment);

        void SaveRatings(MissionRatingDTO ratings);
        bool CheckMissionApplied(long missionId, int userId);

        bool AddRecommandToWorker(int missionId, int userId, List<RecommandUserDTO> body);
        List<MissionListDTO> GetRelatedMission(RelatedMissionDTO RelatedMissionDTO);
    }
}