namespace MinimalApiRealState.Feats.Properties.Dtos;

public class CreatePropertyDto
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? Location { get; set; }
    public bool IsActive { get; set; }
    public DateTimeOffset? CreationDate { get; set; }
}
