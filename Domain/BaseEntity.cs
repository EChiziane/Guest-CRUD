using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime LastUpdatedAt { get; set; } = DateTime.Now;

    public string? CreatedByUserId { get; set; }

    [ForeignKey("CreatedByUserId")] public virtual ApplicationUser? CreatedByUser { get; set; }

    public string? LastUpdatedByUserId { get; set; }

    [ForeignKey("LastUpdatedByUserId")] public virtual ApplicationUser? LastUpdatedByUser { get; set; }
}