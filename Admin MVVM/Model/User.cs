using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Controls;

[Table("User")]
public class User
{
    [Column("id")]
    public Guid Id { get; set; }
    [Column("name")]
    public string Name { get; set; }
    [Column("email")]
    public string Email { get; set; }
    [Column("password")]
    public string Password { get; set; }

    public User(Guid id, string name, string email, string password)
    {
        Id = id;
        Name = name;
        Email = email;
        Password = password;
    }
}

