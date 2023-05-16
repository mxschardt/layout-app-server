using System.ComponentModel.DataAnnotations;

namespace Api.Dto;

public class PostCreateDto
{
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Body { get; set; } = string.Empty;
    [Required]
    public int UserId { get; set; }
}