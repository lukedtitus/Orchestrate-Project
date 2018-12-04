﻿using Orchestrate.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchestrate.Models
{
    public class ArtistDetail
    {
        public int ArtistId { get; set; }

        [Display (Name = "Artist")]
        public string ArtistName { get; set; }

        [Display (Name = "Number of members")]
        public int NumberOfMembers { get; set; }
        public GenreEnum Genre { get; set; }
        
        [Display (Name = "Projects Released")]
        public int ProjectsReleased { get; set; }
        public override string ToString() => $"[{ArtistId}] {ArtistName}";
    }
}
