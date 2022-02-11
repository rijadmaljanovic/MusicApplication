using MusicApplication.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicApp.Core.Entities
{
    public class Song
    {
        [Key]
        public int Id { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string SongName { get; set; }
        public string ArtistName { get; set; }
        public string SongUrl { get; set; }
        public int Rating { get; set; }
        public bool IsFavourite { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
