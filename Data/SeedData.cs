using Microsoft.EntityFrameworkCore;

using Api.Models;
using Api.Utilities;

namespace Api.Data;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ApplicationContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<ApplicationContext>>()))
        {
            if (context.Users.Any())
            {
                return;
            }

            var users = new User[]
            {
                new User { Name = "John Smith", UserName = "johnsmith", Email = "johndoe@example.com" },
                new User { Name = "Anna Smith", UserName = "annasmith", Email = "janesmith@example.com" },
                new User { Name = "Bob Johnson", UserName = "bobdylon", Email = "bobjohnson@example.com" }
            };

            context.Users.AddRange(users);
            context.SaveChanges();

            foreach (var user in users)
            {
                var posts = new Post[5];
                for(var i = 0; i < 5; i++) 
                {
                    var title = LoremIpsum.Generate(3, 7);
                    var body = LoremIpsum.Generate(10, 20);
                    var post = new Post { Title = title, Body = body, UserId = user.Id };
                    posts[i] = post;
                }

                context.Posts.AddRange(posts);
            }

            context.SaveChanges();
        }
    }
}
