using System.ComponentModel.DataAnnotations;

namespace Api.Dto;

public class UserCreateDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string UserName { get; set; } = string.Empty;
    [Required]
    public string Email { get; set; } = string.Empty;
}