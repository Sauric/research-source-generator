using System.Text;

namespace Research.Source.Genarator;

partial class Product
{
    public string Stringify()
    {
        var sb = new StringBuilder();
        sb.Append('{');
        sb.Append($"{{Guid, Id, {this.Id}}},{{string, Name, {this.Name}}},{{string, Description, {this.Description}}}");
        sb.Append('}');
        return sb.ToString();
    }
}
