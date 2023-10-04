using System.ComponentModel.DataAnnotations;

namespace MinimalApiRealState.Shared;

public class RsProperty
{
    [Key]
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; } = string.Empty;
    public string? Location { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public DateTimeOffset? CreationDate { get; set; }
}
