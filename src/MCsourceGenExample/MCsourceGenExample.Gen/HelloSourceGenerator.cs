using Microsoft.CodeAnalysis;
using System.Diagnostics;

namespace Research.Source.Genarator
{
    [Generator]
    public class HelloSourceGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            // Find the main method
            var mainMethod = context.Compilation.GetEntryPoint(context.CancellationToken);

            // Build up the source code
            string source = 
$@" // Auto-generated code
using System;

namespace {mainMethod.ContainingNamespace.ToDisplayString()};

public static partial class {mainMethod.ContainingType.Name}
{{
    static partial void HelloFrom(string name) =>
        Console.WriteLine($""Generator says: Hi from '{{name}}'. Wirtten by Sauric. Scoped namespaces.Debugger"");
}}
";

            var typeName = mainMethod.ContainingType.Name;

            // Add the source code to the compilation
            context.AddSource($"{typeName}.g.cs", source);
        }

        public void Initialize(GeneratorInitializationContext context)
        {
//#if DEBUG
//            if(!Debugger.IsAttached)
//            {
//                Debugger.Launch();
//            }
//#endif
        }
    }
}
