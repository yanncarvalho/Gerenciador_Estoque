using Microsoft.EntityFrameworkCore;
using ApiProvaCSharp.Models;
using ApiProvaCSharp.Services;
using ApiProvaCSharp.Services.ServicesImpl;

var builder = WebApplication.CreateBuilder(args);
ConfigureServices(builder.Services, builder.Configuration);
var app = builder.Build();

Configure(app, builder.Environment);
app.Run();

void ConfigureServices(IServiceCollection services, IConfiguration Configuration)
{
    services.AddScoped<IProdutoService, ProdutoService>();
    services.AddCors();
    services.AddControllers();
    services.AddEndpointsApiExplorer();
  
    var connection = Configuration["MySql:Connection"];
    services.AddDbContext<ApiContext>(options =>
        options.UseMySQL(connection)
    );
 

}

void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }

    app.UseHttpsRedirection();

    app.UseRouting();

    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    app.UseAuthentication();
    app.UseAuthorization();

    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
}