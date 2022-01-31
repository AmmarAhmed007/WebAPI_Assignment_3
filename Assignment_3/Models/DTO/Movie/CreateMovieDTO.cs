namespace Assignment_3.Models.DTO.Movie
{
    public class CreateMovieDTO
    {
        public string MovieTitle { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string Director { get; set; }
        public string PhotoUrl { get; set; }
        public string YoutubeLink { get; set; }
    }
}
