// See https://aka.ms/new-console-template for more information
using SKZHDotNetCore.ConsoleApp;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");
//Console.ReadKey();

// md => markdown

// C# <=> Database

// ADO.NET
// Dapper (ORM) Object Relation Mapper
// EFCore / Entity FramWork (ORM) Object Relation Mapper

//nuget package download ya mal

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Create();
//adoDotNetExample.Edit();
//adoDotNetExample.Update();
adoDotNetExample.Delete();

Console.ReadKey();