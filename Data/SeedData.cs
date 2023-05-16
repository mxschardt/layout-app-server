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
            if (context.Users.Any()) return;

            FillDatabase(context);
        }
    }

    public static void FillDatabase(ApplicationContext context)
    {

        var users = GenerateUsers();
        context.Users.AddRange(users);

        foreach (var user in users)
        {
            var posts = GeneratePosts(user, 20);
            context.Posts.AddRange(posts);
        }

        context.SaveChanges();
    }

    public static IEnumerable<User> GenerateUsers()
    {
        return new User[]
        {
            new User { Name = "John Smith", UserName = "johnsmith", Email = "johndoe@example.com" },
            new User { Name = "Anna Smith", UserName = "annasmith", Email = "janesmith@example.com" },
            new User { Name = "Bob Johnson", UserName = "bobdylon", Email = "bobjohnson@example.com" },
            new User { Name = "Alice Smith", UserName = "alicesmith", Email = "alicesmith@example.com" },
            new User { Name = "John Doe", UserName = "johndoe", Email = "johndoe@example.com" },
        };
    }

    public static IEnumerable<Post> GeneratePosts(User user, int amount)
    {
        var posts = new Post[amount];
        for (var i = 0; i < amount; i++)
        {
            var title = LoremIpsum.Generate(3, 7);
            var body = LoremIpsum.Generate(10, 20);
            var post = new Post { Title = title, Body = body, UserId = user.Id };
            posts[i] = post;
        }
        return posts;
    }
}
