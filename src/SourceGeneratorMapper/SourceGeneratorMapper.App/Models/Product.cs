namespace Research.Source.Genarator;

[Stringable]
public partial class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public override string ToString()
    {
        return this.Stringify();
    }
}
