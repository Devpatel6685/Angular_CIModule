using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIPlatform.DAL.ViewModels
{
    public class RecommandUserDTO
    {
        public int id { get; set; }
        public string? firstname { get; set; }

        public string? lastname { get; set; }

        public string? email { get; set; }
        public bool? completed { get; set; } = false;
    }
}