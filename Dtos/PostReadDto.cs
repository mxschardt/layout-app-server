namespace Api.Dto;

public class PostReadDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public int UserId { get; set; }
}