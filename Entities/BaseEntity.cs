namespace BlazorAppServer;

public class BaseEntity
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Mobile { get; set; }
    public int Age { get; set; }
}
