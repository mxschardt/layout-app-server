using System.ComponentModel.DataAnnotations;

namespace Api.Dto;

public class UserUpdateDto
{
    [Required]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}