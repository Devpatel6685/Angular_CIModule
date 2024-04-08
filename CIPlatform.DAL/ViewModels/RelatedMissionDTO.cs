using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPlatform.DAL.ViewModels
{
    public class RelatedMissionDTO
    {
        public int MissionId { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public int ThemeId { get; set; }
        public int UserId { get; set; }
    }

}
