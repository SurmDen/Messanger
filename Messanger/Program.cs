using Messanger.Interfaces;
using Messanger.Models;
using Microsoft.EntityFrameworkCore;
using AuthenticationManager.Infrastructure;
using UserManager.Models;
using Messanger.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddControllers();
builder.Services.AddAuthorization();
builder.Services.AddJwtBearerAuthentication();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:UserServiceConnection"]);
});
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IDialogRepository, DialogRepository>();
builder.Services.AddRazorPages();
builder.Services.AddSession();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddCors();
builder.Services.AddJwtTokenService();
builder.Services.AddSignalR();

var app = builder.Build();

var env = builder.Environment;

env.EnvironmentName = "Production";

if (env.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStatusCodePagesWithRedirects("/statuscode.html?code={0}");

app.UseRouting();

app.UseStaticFiles();

app.UseSession();

app.Use(async (context, next) =>
{

    try
    {
        string token = context.Request.Cookies["token"];

        context.Request.Headers.Add("Authorization", $"Bearer {token}");
        context.Response.Headers.Add("Authorization", $"Bearer {token}");
    }
    catch
    {
        context.Request.Headers.Add("Authorization", $"no token");
    }

    await next.Invoke();

});

app.UseCors(options =>
{
    options.AllowAnyOrigin();

    options.AllowAnyMethod();

    options.AllowAnyHeader();
});

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapRazorPages();

app.MapHub<ChatHub>("/chat");

app.Run();


