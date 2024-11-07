using Newtonsoft.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapGet("/Products", () =>
{
    string folderPath = "Data/Products.json";
    var jsonstr = File.ReadAllText(folderPath);
    var result = JsonConvert.DeserializeObject<List<ProductModel>>(jsonstr)!;
    if(result is null)
    {
        return Results.BadRequest("Failed to Load Products.");
    }
    return Results.Ok(result);
})
.WithName("GetProducts")
.WithOpenApi();

app.MapGet("/Products/{id}", (int id) =>
{
    string folderPath = "Data/Products.json";
    var jsonstr = File.ReadAllText(folderPath);
    var result = JsonConvert.DeserializeObject<List<ProductModel>>(jsonstr)!;
    
    var item = result.FirstOrDefault(x => x.id == id);
    if (item is null)
    {
        return Results.BadRequest("Products with id is not founded.");
    }

    return Results.Ok(item);
})
.WithName("GetProductsById")
.WithOpenApi();

//app.MapPost("/Products", (ProductModel product) =>
//{
//    string folderPath = "Data/Products.json";

//    // Read the existing products from the file
//    var jsonStr = File.ReadAllText(folderPath);
//    var products = JsonConvert.DeserializeObject<List<ProductModel>>(jsonStr) ?? new List<ProductModel>();

//    // Add the new product (you can assign a new ID based on the highest existing ID)
//    var newId = products.Any() ? products.Max(p => p.id) + 1 : 1;
//    product.id = newId;

//    // Add the new product to the list
//    products.Add(product);

//    // Serialize the updated list of products and save it back to the file
//    var updatedJsonStr = JsonConvert.SerializeObject(products, Formatting.Indented);
//    File.WriteAllText(folderPath, updatedJsonStr);

//    return Results.Created($"/Products/{product.id}", product);
//})
//.WithName("AddProduct")
//.WithOpenApi();

//app.MapPut("/Products/{id}", (int id, ProductModel updatedProduct) =>
//{
//    string folderPath = "Data/Products.json";

//    // Read the existing products from the file
//    var jsonStr = File.ReadAllText(folderPath);
//    var products = JsonConvert.DeserializeObject<List<ProductModel>>(jsonStr) ?? new List<ProductModel>();

//    // Find the product to update by id
//    var productToUpdate = products.FirstOrDefault(p => p.id == id);

//    if (productToUpdate == null)
//    {
//        return Results.NotFound($"Product with ID {id} not found.");
//    }

//    // Update the product's properties
//    productToUpdate.title = updatedProduct.title ?? productToUpdate.title;
//    productToUpdate.price = updatedProduct.price != 0 ? updatedProduct.price : productToUpdate.price;
//    productToUpdate.description = updatedProduct.description ?? productToUpdate.description;
//    productToUpdate.category = updatedProduct.category ?? productToUpdate.category;
//    productToUpdate.image = updatedProduct.image ?? productToUpdate.image;
//    productToUpdate.rating = updatedProduct.rating ?? productToUpdate.rating;

//    // Serialize the updated list of products and save it back to the file
//    var updatedJsonStr = JsonConvert.SerializeObject(products, Formatting.Indented);
//    File.WriteAllText(folderPath, updatedJsonStr);

//    return Results.Ok(productToUpdate);
//})
//.WithName("UpdateProduct")
//.WithOpenApi();

//app.MapDelete("/Products/{id}", (int id) =>
//{
//    string folderPath = "Data/Products.json";

//    // Read the existing products from the file
//    var jsonStr = File.ReadAllText(folderPath);
//    var products = JsonConvert.DeserializeObject<List<ProductModel>>(jsonStr) ?? new List<ProductModel>();

//    // Find the product to delete by id
//    var productToDelete = products.FirstOrDefault(p => p.id == id);

//    if (productToDelete == null)
//    {
//        return Results.NotFound($"Product with ID {id} not found.");
//    }

//    // Remove the product from the list
//    products.Remove(productToDelete);

//    // Serialize the updated list of products and save it back to the file
//    var updatedJsonStr = JsonConvert.SerializeObject(products, Formatting.Indented);
//    File.WriteAllText(folderPath, updatedJsonStr);

//    return Results.Ok($"Product with ID {id} deleted successfully.");
//})
//.WithName("DeleteProduct")
//.WithOpenApi();




app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}


public class ProductsResponseModel
{
    public ProductModel[] Products { get; set; }
}

public class ProductModel
{
    public int id { get; set; }
    public string title { get; set; }
    public float price { get; set; }
    public string description { get; set; }
    public string category { get; set; }
    public string image { get; set; }
    public Rating rating { get; set; }
}

public class Rating
{
    public float rate { get; set; }
    public int count { get; set; }
}

