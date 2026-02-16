using System.Text.Json.Serialization;

namespace OpenLibrary.Models
{
    public class BookSearchDto
    {
        [JsonPropertyName("title")]
        public string Title { get; set; } = "";

        [JsonPropertyName("cover_url")]
        public string Cover_Url { get; set; } = "";

        [JsonPropertyName("key")]
        public string Key { get; set; } = "";
    }
}
