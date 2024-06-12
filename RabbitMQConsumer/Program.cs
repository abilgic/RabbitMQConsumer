using RabbitMQConsumer.Services;

var builder = WebApplication.CreateBuilder(args);

// Register RabbitMQ consumer service
builder.Services.AddSingleton<RabbitMqConsumerService>();
builder.Services.AddHostedService(provider => provider.GetRequiredService<RabbitMqConsumerService>());


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
