using System.Globalization;
using API.Extensions;
using API.Middlewares;
using Application.Account;
using Application.Helpers.MappingProfiles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Seed;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddIdentityServices(builder.Configuration);


//Add Localization
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddControllers(opt =>
{
    var policy = new AuthorizationPolicyBuilder("Bearer").RequireAuthenticatedUser().Build();
    opt.Filters.Add(new AuthorizeFilter(policy));
});

/*(config =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});*/
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add Application Extensions
builder.Services.AddApplicationServices();
builder.Services.AddSwaggerDocumentation();

// Add Cors
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", policy => { policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin(); });
});

//Add Auto Mapper
builder.Services.AddAutoMapper(typeof(MappingProfiles));

//Add MediatR
builder.Services.AddMediatR(typeof(Login.LoginCommandHandler).Assembly);


var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

//Seed Database
//SeedDatabase();

// Localization
var requestLocalizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(GetDefaultLanguage()),

    // Formatting numbers, dates, etc.
    SupportedCultures = GetSupportedCultures(),

    // UI strings that we have localized.
    SupportedUICultures = GetSupportedCultures()
};

// Error Handling
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseRequestLocalization(requestLocalizationOptions);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseRouting();

app.UseCors("CorsPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

void SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();

        dbInitializer.Initilize();
    }
}

CultureInfo[] GetSupportedCultures()
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<DataContext>();

        var languages = context.SystemLanguages.ToListAsync().GetAwaiter().GetResult();

        var cultures = new List<CultureInfo>();

        foreach (var language in languages) cultures.Add(new CultureInfo(language.Code));

        return cultures.ToArray();
    }
}

string GetDefaultLanguage()
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<DataContext>();

        var language = context.SystemLanguages.FirstOrDefaultAsync(s => s.IsDefault).GetAwaiter().GetResult();

        if (language != null)
            return language.Code;

        return "en-US";
    }
}