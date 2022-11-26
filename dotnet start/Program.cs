using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World 2!");

app.MapPost("/", () => new {Name = "Leonardo", Age = 24});
app.MapGet("/AddName", (HttpResponse response) => response.Headers.Add("Teste","Leonardo"));

app.MapPost("/saveProdut", (Produt produt) => {
    ProductRepository.Add(produt);
} );

app.MapGet("/user", ([FromQuery]string dataStart, [FromQuery]string dateEnd) => {
    return dataStart + " - " + dateEnd;
});

app.MapGet("/user/{code}", ([FromRoute] string code) => {
    var product = ProductRepository.GetBy(code);
    return product;
});

app.MapPut("/editProduct", (Produt product) => {
    var productSave = ProductRepository.GetBy(product.Code);
    productSave.Name = product.Name;
    });

app.Run();

public static class ProductRepository {
    public static List<Produt> Products { get;set; }  

    public static void Add(Produt product) {
        if(Products == null) 
            Products = new List<Produt>();
        
        Products.Add(product);
    }

    public static Produt GetBy(string code) {
       return Products.FirstOrDefault(p => p.Code == code);
    }
}

public class Produt {
    public string Code { get; set; }
    public string Name { get; set; }
}


