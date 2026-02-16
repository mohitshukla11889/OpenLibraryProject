namespace OpenLibrary.Models
{
    public class OpenLibrarySearchResponse
    {
        public List<Doc>? Docs { get; set; }
    }

    public class Doc
    {
        public string? Title { get; set; }
        public List<int>? Publish_Year { get; set; }
        public List<string>? Author_Name { get; set; }
        public List<string>? Subject { get; set; }
        public int? Cover_I { get; set; }
        public string? Key { get; set; }
    }
}