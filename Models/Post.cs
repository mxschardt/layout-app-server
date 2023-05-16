namespace Api.Models;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; }
    public DateTime? EditDate { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = null!;
}