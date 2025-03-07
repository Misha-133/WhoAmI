var builder = WebApplication.CreateSlimBuilder(args);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.MapGet("/", (ctx) =>
{
    var ip = ctx.Connection.RemoteIpAddress;
    var ua = ctx.Request.Headers.UserAgent;
    return ctx.Response.WriteAsync($"Your Ip: {ip}\nYour user agent: {ua}");
});

await app.RunAsync();
