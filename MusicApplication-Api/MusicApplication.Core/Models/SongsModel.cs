using System;

namespace MusicApplication.Core.Models
{
    public class SongsModel
    {
        public int Id { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string SongName { get; set; }
        public string ArtistName { get; set; }
        public string SongUrl { get; set; }
        public int Rating { get; set; }
        public bool IsFavourite { get; set; }
        public int CategoryId { get; set; }
    }
}
