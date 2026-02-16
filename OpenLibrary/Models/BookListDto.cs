using System.Text.Json.Serialization;

namespace OpenLibrary.Models
{
    public class BookListDto
    {
        [JsonPropertyName("title")]
        public string Title { get; set; } = "";

        [JsonPropertyName("publish_year")]
        public int Publish_Year { get; set; }

        [JsonPropertyName("authors")]
        public string Authors { get; set; } = "";

        [JsonPropertyName("subjects")]
        public string Subjects { get; set; } = "";

        [JsonPropertyName("cover_url")]
        public string Cover_Url { get; set; } = "";
    }
}
