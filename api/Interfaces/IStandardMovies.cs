namespace api {
    interface IStandardMovies {
        int Id { get; set; }
        string Title { get; set; }
        string Summary { get; set; }
        string Picture { get; set; }
        string Genre { get; set; }
        double Rating { get; set; }
    }
}