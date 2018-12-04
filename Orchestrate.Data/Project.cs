﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchestrate.Data
{
    public enum GenreEnum
    {
        Alternative = 1,
        Blues,
        Comedy,
        [Display(Name = "Children's Music")]
        ChildrensMusic,
        Classical,
        Country,
        Electronic,
        Holiday,
        Opera,
        [Display(Name = "Singer/Songwriter")]
        SingerSongwriter,
        Jazz,
        Latino,
        [Display(Name = "New Age")]
        NewAge,
        Pop,
        [Display(Name = "R&B/Soul")]
        RnbSoul,
        Soundtrack,
        Dance,
        [Display(Name = "Hip-Hop/Rap")]
        HipHopRap,
        World,
        Rock,
        [Display(Name = "Christian & Gospel")]
        ChristianGospel,
        Vocal,
        Reggae,
        [Display(Name = "Easy Listening")]
        EasyListening,
        [Display(Name = "J-Pop")]
        JPop,
        Enka,
        Kayokyoku,
        [Display(Name = "Fitness & Workout")]
        FitnessWorkout,
        [Display(Name = "K-Pop")]
        Kpop,
        Karaoke,
        Instrumental,
        Brazilian,
        [Display(Name = "Spoken Word")]
        SpokenWord,
    }

    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Artist { get; set; }

        [Required]
        public GenreEnum Genre { get; set; }

        [Required]
        public int ReleaseYear { get; set; }

        [Required]
        public double Cost { get; set; }

        [Required]
        public double Sales { get; set; }
    }
}
