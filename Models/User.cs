using System.Collections.ObjectModel;

namespace Api.Models;

public class User {
    public int Id {get; set;}
    public string Name { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public ICollection<Post> Posts { get; set; } = new Collection<Post>();
}