using OpenLibrary.Models;

namespace OpenLibrary.Clients
{
    public class OpenLibraryClient
    {
        private readonly HttpClient _http;

        public OpenLibraryClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<OpenLibrarySearchResponse?> SearchAsync(string query)
        {
            var url = $"/search.json?q={Uri.EscapeDataString(query)}";
            return await _http.GetFromJsonAsync<OpenLibrarySearchResponse>(url);
        }

        public async Task<OpenLibrarySearchResponse?> GetBooksAsync(int limit, int offset)
        {
            var url = $"/search.json?q=limit={limit}&offset={offset}";
            return await _http.GetFromJsonAsync<OpenLibrarySearchResponse>(url);
        }
    }
}