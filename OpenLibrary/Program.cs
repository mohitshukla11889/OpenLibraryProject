using OpenLibrary.Clients;
using OpenLibrary.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// 🔹 Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 🔹 HttpClient + DI
builder.Services.AddHttpClient<OpenLibraryClient>(c =>
{
    c.BaseAddress = new Uri("https://openlibrary.org/");
});
builder.Services.AddScoped<IBookService, BookService>();

var app = builder.Build();

// 🔹 Optional: centralized exception handler (you can keep it)
// Note: ensure you have a matching /error endpoint or middleware.
app.UseExceptionHandler("/error");

// 🔹 Swagger middleware (enable always for local/dev)
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();