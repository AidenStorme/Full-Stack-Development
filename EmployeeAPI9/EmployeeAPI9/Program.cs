using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EmployeeAPI9.Data;
using EmployeeAPI9.Domain.EntitiesDB;
using EmployeeAPI9.Repositories;
using EmployeeAPI9.Repositories.Interfaces;
using EmployeeAPI9.Services;
using EmployeeAPI9.Services.Interfaces;
using Microsoft.OpenApi.Models;
using EmployeeAPI9.Domain.DataDB;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
// Configure ApplicationDbContext (Identity) and EmployeeDbContext (domain) using the same connection string.
// The appsettings DefaultConnection uses SQL Server; configure providers accordingly.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<EmployeeDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

// SwaggerGen produces JSON schema documents that power Swagger UI.By default, these are served up under / swagger /{ documentName}/ swagger.json, where { documentName} is usually the API version.
//provides the functionality to generate JSON Swagger documents that describe the objects, methods, return types, etc.
//eerste paramter, is de naam van het swagger document
//
// Register the Swagger generator, defining 1 or more Swagger documents
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API Employee",
        Version = "version 1",
        Description = "An API to perform Employee operations",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "CDW",
            Email = "christophe.dewaele@vives.be",
            Url = new Uri("https://vives.be"),
        },
        License = new OpenApiLicense
        {
            Name = "Employee API LICX",
            Url = new Uri("https://example.com/license"),
        }
    });
});

// Add Automapper
builder.Services.AddAutoMapper(typeof(Program));

//DI
builder.Services.AddScoped<IService<Employee>, EmployeeService>();
builder.Services.AddScoped<IDao<Employee>, EmployeeDao>();

    //Gebruik JWT Bearer authentication als standaard authenticatiemethode.
    //ASP.NET verwacht een header zoals: Authorization: Bearer<token>
    builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //Gebruik JWT Bearer authentication als standaard authenticatiemethode.
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    //Configureer JWT Bearer authentication
    .AddJwtBearer(cfg =>
    {
        cfg.RequireHttpsMetadata = false;
        cfg.SaveToken = true;
        //Configureer de parameters voor het valideren van het token
        cfg.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = builder.Configuration["JwtConfig:JwtIssuer"], // uitgever van het token
            ValidAudience = builder.Configuration["JwtConfig:JwtIssuer"],
            //de sleutel waarmee de token signature wordt gecontroleerd
            IssuerSigningKey = new
                SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtConfig:JwtKey"])),
            ClockSkew = TimeSpan.Zero // remove delay of token when expire
        };
    });

    // CORS
    var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
    builder.Services.AddCors(options =>
    {
        options.AddPolicy(MyAllowSpecificOrigins,
            policy =>
            {
                policy.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                //  policy.WithOrigins("http://localhost:63342",
                //  "https://www.vives.be")
                //.WithMethods("POST", "DELETE", "GET")
                // .AllowAnyHeader();
            });
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var swaggerOptions = new EmployeeAPI9.Options.OptionsSwagger();
builder.Configuration.GetSection(nameof(EmployeeAPI9.Options.OptionsSwagger)).Bind(swaggerOptions);

// Enable middleware to serve generated Swagger as a JSON endpoint.
// RouteTemplate sets where the JSON file is generated.
app.UseSwagger(option => { option.RouteTemplate = swaggerOptions.JsonRoute; });

// By default, your Swagger UI loads up under /swagger/. If you want to change this, it's straightforward.
// Simply set the RoutePrefix option in your call to app.UseSwaggerUI in Program.cs:
app.UseSwaggerUI(option =>
{
    option.SwaggerEndpoint(swaggerOptions.UiEndpoint, swaggerOptions.Description);
});
// Note: Swagger JSON and UI are already configured above.

// CORS
app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages()
    .WithStaticAssets();

app.Run();