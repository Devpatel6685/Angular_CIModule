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

         bool AddToFavourite(AddToFavouriteDTO addToFavouriteDTO);
    }
}