using BlazorAppServer;
using BlazorAppServer.UnitOfWork;
using System.Globalization;

WebApplicationBuilder? webApplicationBuilder = WebApplication.CreateBuilder(args);


webApplicationBuilder.Services.AddLocalization();

webApplicationBuilder.Services
                     .AddRazorComponents()
                     .AddInteractiveServerComponents();

string connectingString = "Server=DESKTOP-JEJ3UDM\\SQLEXPRESS;Database=StudentAffairsDb;User Id=menna;Password=1234selim@;Encrypt=True;TrustServerCertificate=True;Connection Timeout=60;";

webApplicationBuilder.Services.AddDbContext<StudentsAffairsDbContext>(options => options
                     .UseSqlServer(connectingString)
                     .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                     .EnableServiceProviderCaching()
                     .EnableDetailedErrors()
                     .EnableSensitiveDataLogging()
                     .EnableThreadSafetyChecks());

webApplicationBuilder.Services.AddScoped<IStudentsUnitOfWork, StudentsUnitOfWork>();
webApplicationBuilder.Services.AddScoped<IApplicantsUnitOfWork, ApplicantsUnitOfWork>();
webApplicationBuilder.Services.AddScoped<IEmployeesUnitOfWork, EmployeesUnitOfWork>();
webApplicationBuilder.Services.AddScoped<IFacultyStaffUnitOfWork, FacultyStaffUnitOfWork>();

webApplicationBuilder.Services.AddScoped<IStudentsRepository, StudentsRepository>();
webApplicationBuilder.Services.AddScoped<IApplicantsRepository, ApplicantsRepository>();
webApplicationBuilder.Services.AddScoped<IEmployeesRepository, EmployeesRepository>();
webApplicationBuilder.Services.AddScoped<IFacultyStaffRepository, FacultyStaffRepository>();



string[] supportedCultures = ["en-US", "de-CH" , "ar-EG"];
RequestLocalizationOptions localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);


WebApplication? webApplication = webApplicationBuilder.Build();

if (!webApplication.Environment.IsDevelopment())
{
    webApplication.UseExceptionHandler("/Error", createScopeForErrors: true);
    webApplication.UseHsts();
}

webApplication.UseHttpsRedirection();
webApplication.UseStaticFiles();
webApplication.UseAntiforgery();

webApplication.UseRequestLocalization(localizationOptions);


webApplication.MapRazorComponents<App>()
              .AddInteractiveServerRenderMode();

webApplication.Run();
