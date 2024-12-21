using Antlr4.Runtime;
using EMSL.Language.Models;

namespace EMSL.Language
{
    public class EmslManager
    {
        private readonly EsmlEvaluator _evaluator = new EsmlEvaluator();
        
        public MigrationSpecification ParseInput(string input)
        {
            var inputStream = CharStreams.fromString(input);
            var lexer = new EMSLLexer(inputStream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new EMSLParser(tokens);
            var specificationTree = parser.specification();
            var result = _evaluator.Visit(specificationTree).AsMigrationSpecification();
            return result;
        }
    }
}