using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;

// Load environment variables from .env (if present)
Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<TestConsole.Services.SupabaseService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true,

    };
});



builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader()
        .AllowAnyOrigin()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("AllowAll");

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run("http://localhost:5000");
// using TestConsole.day8;

// new NestedTryCatch();

// BookModel book = new BookModel();
// book.id = 1;
// book.isbn = "978-3-16-148410-0";
// book.name = "C# Programming";
// book.author = new AuthorModal(1, "John Doe");

// Console.WriteLine(book.id);
// Console.WriteLine(book.isbn);
// Console.WriteLine(book.name);
// Console.WriteLine(book.author?.id);
// Console.WriteLine(book.author?.name);

//TestConsole.day2.Object1.Run();
//TestConsole.day2.Object2.Run();
//TestConsole.day2.Object3.Run();
//TestConsole.day3.if1.Run();
//TestConsole.day3.if6.Run();
//TestConsole.day3.AppGrade.Run();
//TestConsole.day4.SummaryNumber.Run();
//TestConsole.day4.NesTedLoop.Run();
//TestConsole.day4.Multiplication.Run();
//TestConsole.day4.Table8x8.Run();
//TestConsole.day5.ListSortAndReverse.Run();
//TestConsole.day5.MyGeneric.Run();
//TestConsole.day6.ReadAndWriteBinaryFile.Run();
//TestConsole.day7.ObjectDog.Run();
//new TestConsole.day7.MyStaticMethod();
// TestConsole.day7.MyStaticMethod.myMethod();
// int x = TestConsole.day7.MyStaticMethod.getValue();
//  Cat c = new Cat();
//             c.leg = 4;
//             c.color = "White";
//             c.eye = 2;
//             c.echo();

//             Console.WriteLine("leg = {0}, color = {1}, eye = {2}", c.leg, c.color, c.eye);
// Console.WriteLine("Value = {0}", x);
//dotnet run