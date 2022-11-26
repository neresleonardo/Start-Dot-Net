using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World 2!");

app.MapPost("/", () => new {Name = "Leonardo", Age = 24});
app.MapGet("/AddName", (HttpResponse response) => response.Headers.Add("Teste","Leonardo"));

app.MapPost("/saveProdut", (Produt produt) => {
    return produt.Code + " - " + produt.Name;
} );

app.MapGet("/user", ([FromQuery]string dataStart, [FromQuery]string dateEnd) => {
    return dataStart + " - " + dateEnd;
});

app.MapGet("/user/{code}", ([FromRoute] string code) => {
    return code;
});

app.Run();

public class Produt {
    public int Code { get; set; }
    public string Name { get; set; }
}


