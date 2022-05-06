using Microsoft.EntityFrameworkCore;
using ApiProvaCSharp.Models;
using ApiProvaCSharp.Services;
using ApiProvaCSharp.Services.ServicesImpl;
using ApiProvaCSharp.Filters;
using ApiProvaSharp.Filters;
using Newtonsoft.Json.Converters;

var builder = WebApplication.CreateBuilder(args);
ConfigureServices(builder.Services, builder.Configuration);
var app = builder.Build();
Configure(app, builder.Environment);
app.Run();

void ConfigureServices(IServiceCollection services, IConfiguration Configuration)
{
    services.AddScoped<IProdutoService, ProdutoService>();
    services.AddScoped<ICompraService, CompraService>();
    services.AddSwaggerGenNewtonsoftSupport();
     services.AddCors();
    services.AddControllers()
            .AddNewtonsoftJson(options => 
                 options.SerializerSettings.Converters.Add(new StringEnumConverter()));
    services.AddSwaggerGen();
    services.AddMvc(options => {
       
        options.Filters.Add(new InvalidRequestFilter());
        options.Filters.Add(new ExceptionResponseFilter());
    });

    services.AddEndpointsApiExplorer();

    var connection = Configuration["SqlServer:Connection"];
    services.AddDbContext<ApiContext>(
        options => options.UseSqlServer(connection)
    );
}

void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{

    if (env.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseRouting();

    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    app.UseHttpsRedirection();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
}