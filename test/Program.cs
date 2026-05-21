using test.Endpoints;
using test.Repositories;
using test.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Registrazione dei servizi nei Container DI (Inversione del Controllo - IoC / DIP)
builder.Services.AddSingleton<IProductRepository, ProductRepository>(); // Usa AddScoped con i database reali
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddSingleton<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<ITodoService, TodoService>();

var app = builder.Build();

// 2. Configurazione della Pipeline HTTP e degli Endpoints
app.UseHttpsRedirection();

// Mappatura pulita degli endpoint del modulo Product
app.MapProductEndpoints();
app.MapTodoEndpoints();




app.Run();
