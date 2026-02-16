# OpenLibrary Wrapper API

A lightweight, cleanly structured **ASP.NET Core Web API** that acts as an intermediate layer between clients and 
the public **Open Library API** (https://openlibrary.org).

This project exposes two main endpoints:

- **List books** (flattened, paginated) (Example : 10, 0)
- **Search books** by title   (Example : Pride and Prejudice)

The goal: provide a safer, cleaner, consistent contract that hides external API complexity, mapping, and rules 
such as limiting `limit <= 10`.

---

## 📁 Project Structure

OpenLibrary.Api/
├── Controllers/
│    └── BooksController.cs
├── Services/
│    ├── IBookService.cs
│    └── BookService.cs
├── Clients/
│    └── OpenLibraryClient.cs
├── Models/
│    ├── DTOs/
│    │   ├── BookListDto.cs
│    │   ├── BookSearchDto.cs
│    └── OpenLibrarySearchResponse.cs
├── Program.cs
├── appsettings.json
├── README.md
