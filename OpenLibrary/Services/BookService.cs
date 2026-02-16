using OpenLibrary.Clients;
using OpenLibrary.Models;

namespace OpenLibrary.Services
{
    public interface IBookService
    {
        Task<List<BookListDto>> GetBooksAsync(int limit, int offset);
        Task<List<BookSearchDto>> SearchAsync(string title);
    }

    public class BookService : IBookService
    {
        private readonly OpenLibraryClient _client;

        public BookService(OpenLibraryClient client)
        {
            _client = client;
        }

        public async Task<List<BookListDto>> GetBooksAsync(int limit, int offset)
        {
            limit = Math.Clamp(limit, 1, 10); // enforce 1 <= limit <= 10
            offset = Math.Max(0, offset);

            // Fix: pass parameters in the order the client expects (limit, offset)
            var response = await _client.GetBooksAsync(limit, offset);

            if (response?.Docs == null) return new();

            return response.Docs.Select(d => new BookListDto
            {
                Title = d.Title ?? "",
                Publish_Year = d.Publish_Year?.FirstOrDefault() ?? 0,
                Authors = d.Author_Name != null ? string.Join(", ", d.Author_Name) : "",
                Subjects = d.Subject != null ? string.Join(", ", d.Subject) : "",
                Cover_Url = d.Cover_I != null
                    ? $"https://covers.openlibrary.org/b/id/{d.Cover_I}-M.jpg"
                    : ""
            }).ToList();
        }

        public async Task<List<BookSearchDto>> SearchAsync(string title)
        {
            var response = await _client.SearchAsync(title);

            if (response?.Docs == null) return new();

            return response.Docs.Take(1).Select(d => new BookSearchDto
            {
                Title = d.Title ?? "",
                Key = d.Key ?? "",
                Cover_Url = d.Cover_I != null
                    ? $"https://covers.openlibrary.org/b/id/{d.Cover_I}-L.jpg"
                    : ""
            }).ToList();
        }
    }
}