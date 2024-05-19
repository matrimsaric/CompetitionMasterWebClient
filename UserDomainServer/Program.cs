using ServerCommonModule.Database.Interfaces;
using ServerCommonModule.Database;
using UserDomainServer.Middleware;
using ServerCommonModule.Support;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);


var configurationSection = builder.Configuration.GetSection(ServerConstants.DATABASE_SECTION);

//Create singleton from instance
builder.Services.Configure<EnvironmentalParameters>(configurationSection);

switch (configurationSection[ServerConstants.DATABASE_TYPE])
{
    case ServerConstants.POSTGRESS_NAME:
        builder.Services.AddScoped<IDbUtilityFactory, PgUtilityFactory>();
        break;
    case ServerConstants.FILE_SYSTEM_NAME:
        builder.Services.AddScoped<IDbUtilityFactory, FileServerUtilityFactory>();
        break;
    case ServerConstants.SQL_NAME:
    default:
        // TODO need to generate these
        //builder.Services.AddScoped<IDbUtilityFactory, SqlUtilityFactory>();
        break;
}
builder.Services.AddScoped<IDbUtilityParameter, DbUtilityParameter>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string originsLocal = "http://localhost:4200";
const string policyName = "CorsPolicy4200";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName, builder =>
    {
        builder.WithOrigins(originsLocal)
            .AllowAnyHeader()
            .AllowCredentials()
            .AllowAnyMethod();
    });
    //options.AddPolicy(name: policyName, builder =>
    //{
    //    builder.AllowAnyOrigin()
    //        .AllowAnyHeader()
    //        .AllowAnyMethod();
    //});
});



var app = builder.Build();

app.UseCors(build => build.WithOrigins(originsLocal)
                       .AllowCredentials()
                       .WithMethods("GET", "HEAD", "OPTIONS", "POST", "PUT", "DELETE")
                       .WithHeaders("Origin", "accept", "X-Requested-With", "Access-Control-Allow-Methods", "Content-Type", "Access-Control-Allow-Credentials", "Access-Control-Request-Method"
                           , "Access-Control-Request-Headers", "Authorization", "X-evo-session-id", "X-Xsrf-Token")
                       .SetIsOriginAllowed(origin => true));


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomExceptionMiddleware();



app.UseHttpsRedirection();

app.UseAuthorization();




app.MapControllers();

app.Run();



