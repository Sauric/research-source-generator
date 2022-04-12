using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SourceGeneratorMapper.Gen
{
    [Generator]
    public class MapperGenerator : ISourceGenerator
    {
        private const string nl = "\r\n";
        public void Execute(GeneratorExecutionContext context)
        {
            var syntaxTrees = context.Compilation.SyntaxTrees;
            var models = syntaxTrees.Where(x => x.GetText().ToString().Contains("[Stringable"));
            foreach(var model in models)
            {
                var descendantNodes = model.GetRoot().DescendantNodes();

                var usingsDirectives = descendantNodes.OfType<UsingDirectiveSyntax>();
                var usingsDirectivesAsText = string.Join(nl, usingsDirectives);

                var sourceCodeBuilder = new StringBuilder(usingsDirectivesAsText);
                sourceCodeBuilder.AppendLine("using System.Text;");

                var classDeclarationSyntax = descendantNodes.OfType<ClassDeclarationSyntax>().First();
                var namespaseDeclarationSyntax = descendantNodes.OfType<FileScopedNamespaceDeclarationSyntax>().First();

                var className = classDeclarationSyntax.Identifier.ValueText;
                var namespaceName = namespaseDeclarationSyntax.Name.GetText().ToString();

                var members = classDeclarationSyntax.Members;
                var properties = members
                    .Select(member => member as PropertyDeclarationSyntax)
                    .Where(property => !(property is null));
                var propertiesToString = string.Join(",", 
                    properties
                    .Select(property => $@"{{{{{property.Type}, {property.Identifier}, {{this.{property.Identifier}}}}}}}"));

                sourceCodeBuilder
                    .Append($@"
namespace {namespaceName};

partial class {className}
{{
    public string Stringify()
    {{
        var sb = new StringBuilder();
        sb.Append('{{');
        sb.Append($""{propertiesToString}"");
        sb.Append('}}');
        return sb.ToString();
    }}
}}
");

                var generatedCode =  sourceCodeBuilder.ToString();
                context.AddSource($"{className}Stringifier", SourceText.From(generatedCode, Encoding.UTF8));
            }
        }

        public void Initialize(GeneratorInitializationContext context)
        {
//#if DEBUG
//            if (!Debugger.IsAttached)
//            {
//                Debugger.Launch();
//            }
//#endif
        }

       
    }
}