namespace Research.Source.Genarator;

class Program
{
    static void Main(string[] args)
    {
        var product = new Product()
        {
            Id = Guid.Parse("a12fb586-ed89-4be3-8418-fdb69666a4d7"),
            Name = "TV",
            Description = "Sumsung OLED 75'"
        };
        var str = product.Stringify();
        Console.WriteLine(str);
        Console.WriteLine(product);

        Console.BackgroundColor = ConsoleColor.DarkCyan;
        var productContainer = new ProductContainer()
        {
            Id = Guid.Parse("a12fb586-ed89-4be3-8418-fdb69666a4d7"),
            InnerProduct = product
        };
        Console.WriteLine();
        Console.WriteLine(productContainer.Stringify());
        Console.BackgroundColor = ConsoleColor.Black;

    }
}