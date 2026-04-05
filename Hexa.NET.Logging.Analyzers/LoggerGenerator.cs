namespace Hexa.NET.Logging.Analyzers
{
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    [Generator]
    public class LoggerGenerator : ISourceGenerator
    {
        private const string AttributeName = "Hexa.Protobuf.ProtobufRecordAttribute";

        public void Initialize(GeneratorInitializationContext context)
        {
        }

        public void Execute(GeneratorExecutionContext context)
        {
            var syntaxTrees = context.Compilation.SyntaxTrees;
            foreach (var syntaxTree in syntaxTrees)
            {
                var semanticModel = context.Compilation.GetSemanticModel(syntaxTree);
                var root = syntaxTree.GetRoot();
                var structs = root.DescendantNodes().OfType<StructDeclarationSyntax>();
                var classes = root.DescendantNodes().OfType<ClassDeclarationSyntax>();
                foreach (var structDeclaration in structs)
                {
                    var structSymbol = semanticModel.GetDeclaredSymbol(structDeclaration) as INamedTypeSymbol;
                    if (structSymbol.GetAttributes().Any(ad => ad.AttributeClass.ToDisplayString() == AttributeName))
                    {
                    }
                }

                foreach (var classDeclaration in classes)
                {
                    var classSymbol = semanticModel.GetDeclaredSymbol(classDeclaration) as INamedTypeSymbol;
                    if (classSymbol.GetAttributes().Any(ad => ad.AttributeClass.ToDisplayString() == AttributeName))
                    {
                    }
                }
            }
        }
    }
}