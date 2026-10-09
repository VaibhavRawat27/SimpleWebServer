
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// Homepage
app.MapGet("/", () =>
{
    return Results.Content("""
        <!DOCTYPE html>
        <html>
        <head>
            <title>My C# Server</title>
            <style>
                body {
                    font-family: Arial, sans-serif;
                    text-align: center;
                    margin-top: 100px;
                    background: #f4f7fb;
                }
                h1 { color: #2563eb; }
                p { color: #444; }
            </style>
        </head>
        <body>
            <h1>Hello from C#!</h1>
            <p>My first ASP.NET Core web server is running.</p>
            <p>Hosted with Ubuntu and .NET.</p>
        </body>
        </html>
        """, "text/html");
});

// JSON API
app.MapGet("/api/hello", () =>
{
    return Results.Ok(new
    {
        message = "Hello from the C# backend!",
        framework = ".NET",
        status = "running"
    });
});

// Health check
app.MapGet("/health", () =>
{
    return Results.Ok(new { status = "healthy" });
});

// Listen on port 8080
app.Run("http://0.0.0.0:8080");
