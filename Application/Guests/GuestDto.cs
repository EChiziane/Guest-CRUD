namespace Application.Guests;

public class GuestDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public bool Confirm { get; set; }
    public DateTime CreatedAt { get; set; }
    public string  CreatedBy { get; set; }
    public string  LastUpdatedBy { get; set; }
}