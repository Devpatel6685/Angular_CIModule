using AutoMapper;
using CIPlatform.BAL.Interfaces;
using CIPlatform.DAL.Models;
using CIPlatform.DAL.ViewModels;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPlatform.BAL.Services
{
    public class StoryService : IStoryService
    {
       
        private readonly dbcontext _context;
        public StoryService(dbcontext context)
        {
            _context = context;
        }


        public List<StoryDTO> GetStoryByFilter()
        {
            return (from m in _context.Stories
                    where (m.DeletedAt == null)
                    select new StoryDTO
                    {
                        MissionId = m.MissionId,
                        StoryImage = m.StoryMedia.Count > 0 ? m.StoryMedia.FirstOrDefault().Path : string.Empty,
                        Title = m.Title,
                        StoryId = m.StoryId,
                        User = m.User,
                        Description = m.Description,
                        Status = m.Status,
                        PublishedAt = m.PublishedAt,
                        Theme = m.Mission.Theme.Title
                    }).OrderBy(x => x.MissionId).ToList();

        }

        public Story GetStoryById(long id)
        {
            return _context.Stories.Include(x => x.StoryMedia).Include(m => m.User).FirstOrDefault(x => x.StoryId == id) ?? new Story();
        }

    }
}
