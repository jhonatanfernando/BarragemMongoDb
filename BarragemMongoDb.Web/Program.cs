using BarragemMongoDb.Web.ApiClient;
using BarragemMongoDb.Web.Components;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddSyncfusionBlazor();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddControllers();

builder.Services.AddHttpClient<BarragemApiClient>(client =>
{
    client.BaseAddress = new("https+http://barragemmongodb-api");
});

var app = builder.Build();

//Register Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NBaF5cXmZCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdnWXpdcHVTR2RdWU1+X0M=");

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.UseRouting()
    .UseAntiforgery()
    .UseEndpoints(r =>
    {
        r.MapDefaultControllerRoute();
    });

app.Run();
