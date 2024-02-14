namespace EventBookingSystem.Domain.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int RoleId { get; set; } = 3;
    public virtual Role Role { get; set; }
    public virtual ICollection<Participant> Participants { get; set; }
}
