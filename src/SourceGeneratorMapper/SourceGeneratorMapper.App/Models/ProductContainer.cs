namespace Research.Source.Genarator;

[Stringable]
public partial class ProductContainer
{
    public Guid Id { get; set; }

    public Product InnerProduct { get; set; } = new Product();
}

