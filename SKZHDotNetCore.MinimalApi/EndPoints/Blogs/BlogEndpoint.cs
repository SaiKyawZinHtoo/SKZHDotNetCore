

namespace SKZHDotNetCore.MinimalApi.EndPoints.Blogs
{
    public static class BlogEndpoint
    {
        public static void UseBlogEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapGet("/Blogs", () =>
            {
                AppDbContext db = new AppDbContext();
                var model = db.TblBlogs.AsNoTracking().ToList();
                return Results.Ok(model);
            })
.WithName("GetBlogs")
.WithOpenApi();

            app.MapGet("/Blogs/{id}", (int id) =>
            {
                AppDbContext db = new AppDbContext();
                var model = db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
                return Results.Ok(model);
            })
            .WithName("GetBlogsById")
            .WithOpenApi();

            app.MapPost("/Blogs", (TblBlog blog) =>
            {
                AppDbContext db = new AppDbContext();
                db.TblBlogs.Add(blog);
                db.SaveChanges();
                return Results.Ok(blog);
            })
            .WithName("CreateBlogs")
            .WithOpenApi();

            app.MapPut("/Blogs/{id}", (int id, TblBlog blog) =>
            {
                AppDbContext db = new AppDbContext();
                var item = db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
                if (item is null)
                {
                    return Results.BadRequest("Data Is Not Founded.");
                }
                item.BlogTitle = blog.BlogTitle;
                item.BlogAuthor = blog.BlogAuthor;
                item.BlogAuthor = blog.BlogAuthor;

                db.Entry(item).State = EntityState.Modified;

                db.SaveChanges();
                return Results.Ok(blog);
            })
            .WithName("UpdatedBlogs")
            .WithOpenApi();

            app.MapPatch("/Blogs/{id}", (int id, TblBlog blog) =>
            {
                AppDbContext db = new AppDbContext();
                var item = db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
                if (item is null)
                {
                    return Results.BadRequest("Data Is Not Founded.");
                }
                if (!String.IsNullOrEmpty(blog.BlogTitle))
                {
                    item.BlogTitle = blog.BlogTitle;
                }
                if (!String.IsNullOrEmpty(blog.BlogAuthor))
                {
                    item.BlogAuthor = blog.BlogAuthor;
                }
                if (String.IsNullOrEmpty(blog.BlogContent))
                {
                    item.BlogAuthor = blog.BlogAuthor;
                }

                db.Entry(item).State = EntityState.Modified;

                db.SaveChanges();
                return Results.Ok(blog);
            })
            .WithName("UpdatedBlogsByIdWithPatch")
            .WithOpenApi();

            app.MapDelete("/Blogs/{id}", (int id) =>
            {
                AppDbContext db = new AppDbContext();
                var item = db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
                if (item is null)
                {
                    return Results.BadRequest("Data Not Founded..");
                }

                db.Entry(item).State = EntityState.Deleted;

                db.SaveChanges();
                return Results.Ok();
            })
            .WithName("DeletedBlogs")
            .WithOpenApi();
        }
    }
}
