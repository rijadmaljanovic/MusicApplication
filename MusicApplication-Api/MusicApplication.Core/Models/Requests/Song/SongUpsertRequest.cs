using System;

namespace MusicApplication.Requests.Song
{
    public class SongUpsertRequest
    {
        public string SongName { get; set; }
        public string ArtistName { get; set; }
        public string SongUrl { get; set; }
        public int Rating { get; set; }
        public bool IsFavourite { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int CategoryId { get; set; }
    }
}
