namespace AppFakeStore.Models;

public class Usuario
{
    public int id { get; set; }
    public string email { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    public Name name { get; set; }
    public Address address { get; set; }
    public string DisplayName => $"{name.firstname} {name.lastname}";
    public string Phone { get; set; }
}
