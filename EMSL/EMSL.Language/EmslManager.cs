using Antlr4.Runtime;
using EMSL.Language.Models;

namespace EMSL.Language
{
    public static class EmslManager
    {
        public static MigrationSpecification ParseInput(string input)
        {
            var inputStream = CharStreams.fromString(input);
            var lexer = new EMSLLexer(inputStream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new EMSLParser(tokens);
            var errorListener = new EmslErrorListener();
            parser.AddErrorListener(errorListener);
            var specificationTree = parser.specification();
            var evaluator = new EsmlEvaluator();
            var result = evaluator.Visit(specificationTree).AsMigrationSpecification();
            errorListener.ThrowIfSyntaxError();
            return result;
        }
    }
}