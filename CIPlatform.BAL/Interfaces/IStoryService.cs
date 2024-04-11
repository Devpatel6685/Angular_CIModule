using CIPlatform.DAL.Models;
using CIPlatform.DAL.ViewModels;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPlatform.BAL.Interfaces
{
    public interface IStoryService
    {
        Story GetStoryById(long id);
        List<StoryDTO> GetStoryByFilter();
    }
}
