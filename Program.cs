using EventPlus.Web.API.Repositories;
using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Controllers;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Repositories;
using EventPlusWebAPI.Interfaces;
using EventPlusWebAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//Configuração do EFCore para o contexto do banco de dados
builder.Services.AddDbContext<EventContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        //Corta o ciclo Usuario -> TipoUsuario -> Usuario -> ---------
        //colocando um null no ponto onde a referencia se repete
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

// Injeção de dependência 
// Add scoped: cria uma nova instância do repositório a cada requisição http
// Isso garante que cada requisição tenha sua própria instância do repositório
builder.Services.AddScoped<ITipoUsuario, TipoUsuarioRepository>();
builder.Services.AddScoped<ITipoEvento, TipoEventoRepository>();
builder.Services.AddScoped<IUsuario, UsuarioRepository>();
// registra os serviços de controllers (Mapeia automaticamente aos controllers da pasta /controller)
builder.Services.AddControllers();

var app = builder.Build();

// mapeia as rotas definidas dos controllers com os atributos [Route]: api/[controller]
app.MapControllers();

app.Run();