using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Configuração do EFCore para o contexto do banco de dados
builder.Services.AddDbContext<EventContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString
("DefaultConnection")));


// Injeção de dependência 
// Add scoped: cria uma nova instância do repositório a cada requisição http
// Isso garante que cada requisição tenha sua própria instância do repositório
builder.Services.AddScoped<ITipoUsuario, TipoUsuarioRepository>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();