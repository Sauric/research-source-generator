using System.Text;

namespace Research.Source.Genarator;

partial class ProductContainer
{
    public string Stringify()
    {
        var sb = new StringBuilder();
        sb.Append('{');
        sb.Append($"{{Guid, Id, {this.Id}}},{{Product, InnerProduct, {this.InnerProduct}}}");
        sb.Append('}');
        return sb.ToString();
    }
}
