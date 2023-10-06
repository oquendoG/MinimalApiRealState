namespace MinimalApiRealState.Feats.Properties.Dtos;

public class UpdatePropertyDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; } = string.Empty;
    public string? Location { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public DateTimeOffset? CreationDate { get; set; } = DateTimeOffset.UtcNow;
}
