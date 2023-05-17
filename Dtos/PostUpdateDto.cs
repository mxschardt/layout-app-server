using System.ComponentModel.DataAnnotations;

namespace Api.Dto;

public class PostUpdateDto
{
    [Required]
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public int UserId { get; set; }
}