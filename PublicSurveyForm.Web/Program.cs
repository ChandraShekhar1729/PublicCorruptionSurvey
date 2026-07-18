using MudBlazor.Services;
using PublicSurveyForm.Repository.DBContext;
using PublicSurveyForm.Repository.Implementaion;
using PublicSurveyForm.Repository.Interface;
using PublicSurveyForm.Services.ImplementationService;
using PublicSurveyForm.Services.InterfaceService;
using PublicSurveyForm.Web.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddMudServices();
builder.Services.AddSingleton<DatabaseDapperContext>();
builder.Services.AddScoped<ISurveyRepository,SurveyRepository>();
builder.Services.AddScoped<ISurveyService,SurveyService>();
builder.Services.AddScoped<IClientInfoService, ClientInfoService>();
builder.Services.AddHttpContextAccessor();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
