namespace Domain;

public class Guest:BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public bool Confirm{ get; set; }
}