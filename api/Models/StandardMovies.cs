namespace api.Models {
    public class StandardMovies : IStandardMovies {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Picture { get; set; }
        public string Genre { get; set; }
        public double Rating { get; set; }
    }
}