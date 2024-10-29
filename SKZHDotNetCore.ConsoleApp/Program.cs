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

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
////adoDotNetExample.Read();
////adoDotNetExample.Create();
////adoDotNetExample.Edit();
////adoDotNetExample.Update();
//adoDotNetExample.Delete();

DapperExample dapperExample = new DapperExample();
//dapperExample.Read();
//dapperExample.Create("addf", "asdf","asdf");
//dapperExample.Update(5,"test for update1", "test for update 2", "test for update 3");
//dapperExample.Delete(14);
dapperExample.Edit(1);
dapperExample.Edit(2);

Console.ReadKey();