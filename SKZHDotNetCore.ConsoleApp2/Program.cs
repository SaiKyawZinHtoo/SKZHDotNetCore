// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using SKZHDotNetCore.DataBase.Model;
using System.Runtime.CompilerServices;

Console.WriteLine("Hello, World!");

var blog = new BlogModel
{
    Id = 1,
    Title = "Testing Title",
    Author = "Testing Author",
    Content = "Testing Content",
};

string jsonStr = blog.ToJson(); // C# to JSON

Console.WriteLine(jsonStr);

string jsonStr2 = """{"id":1,"title":"Test Title","author": "Test Author","content": "Test Content"}""";
var blog2 = JsonConvert.DeserializeObject<BlogModel>(jsonStr2);

Console.WriteLine(jsonStr2);

Console.ReadLine();

public class BlogModel
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Author { get; set; }

    public string Content { get; set; }
}

public static class Extensions //DevCode
{
    public static string ToJson(this object obj)
    {
        string jsonStr = JsonConvert.SerializeObject(obj, Formatting.Indented);
        return jsonStr;
    }
}
