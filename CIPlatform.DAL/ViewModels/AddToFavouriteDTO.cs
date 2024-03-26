using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIPlatform.DAL.ViewModels
{
    public class AddToFavouriteDTO
    {
        public long MissionId { get; set; }
        public int UserId { get; set; }
    }
}