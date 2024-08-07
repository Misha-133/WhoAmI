var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseRouting();

app.MapGet("/", (ctx) =>
{
    var ip = ctx.Connection.RemoteIpAddress;
    var ua = ctx.Request.Headers.UserAgent;
    logger.LogInformation($"Request from {ip} with user agent {ua}");
    return ctx.Response.WriteAsync($"Your Ip: {ip}\nYour user agent: {ua}");
});

await app.RunAsync();
