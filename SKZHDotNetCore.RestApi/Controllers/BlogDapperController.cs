using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SKZHDotNetCore.RestApi.ViewModels;
using System.Data;

namespace SKZHDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogDapperController : ControllerBase
    {
        private readonly string _connectionString = "Data Source=DESKTOP-MVSU0HC;Initial Catalog=SKZHDotNet;User ID=sa;Password=sasa@123;TrustServerCertificate=True;";

        [HttpGet]
        public IActionResult GetBlogs()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = @"SELECT BlogId AS Id
                              ,BlogTitle AS Title
                              ,BlogAuthor AS Author
                              ,BlogContent AS Content
                              ,DeleteFlag
                         FROM tbl_blog
                         WHERE DeleteFlag = 0;";

                List<BlogViewModel> lst = db.Query<BlogViewModel>(query).ToList();
                return Ok(lst);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = @"SELECT BlogId AS Id
                              ,BlogTitle AS Title
                              ,BlogAuthor AS Author
                              ,BlogContent AS Content
                              ,DeleteFlag
                         FROM tbl_blog
                         WHERE DeleteFlag = 0 AND BlogId=@Id";

                var item = db.Query<BlogViewModel>(query, new
                {
                   Id = id
                }).FirstOrDefault();

                if (item is null)
                {
                    return NotFound();
                }
                return Ok(item);
            }
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogViewModel blog)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = $@"INSERT INTO [dbo].[Tbl_Blog]
                           ([BlogTitle]
                           ,[BlogAuthor]
                           ,[BlogContent]
                           ,[DeleteFlag])
                     VALUES
                           (@BlogTitle
                           ,@BlogAuthor
                           ,@BlogContent
                           ,0)";
                int result = db.Execute(query, new BlogViewModel 
                { 
                    Title = blog.Title,
                    Author = blog.Author,
                    Content = blog.Content,
                });
                return Ok(result == 1 ?"Create Successful.": "Create Failed.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogViewModel blog)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = $@"UPDATE [dbo].[Tbl_Blog]
                           SET [BlogTitle] = @BlogTitle
                              ,[BlogAuthor] = @BlogAuthor
                              ,[BlogContent] = @BlogContent
                              ,[DeleteFlag] = 0
                         WHERE BlogId = @BlogId";

                int result = db.Execute(query, new BlogViewModel
                {
                    Id = blog.Id,
                    Title = blog.Title,
                    Author = blog.Author,
                    Content = blog.Content,
                });

                return Ok(result == 1 ? "Updated Successful." : "Updated Failed.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog (int id, BlogViewModel blog)
        {
            using(IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = @"DELETE FROM [dbo].[Tbl_Blog]
                            WHERE BlogId = @BlogId";

                int result = db.Execute(query, new BlogViewModel 
                { 
                    Id =blog.Id,
                });

                return Ok(result == 1 ? "Deleted Successful." : "Deleted Failed.");
            }
        }
    }
}
