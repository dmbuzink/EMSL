using EMSL.Language.Models;

namespace EMSL.Language
{
    public class EsmlEvaluator : EMSLBaseVisitor<EmslValue>
    {
        public override EmslValue VisitName_definition(EMSLParser.Name_definitionContext context)
        {
            var name = context.STRING_LITERAL().Symbol.Text;
            return new EmslValue(name);
        }

        public override EmslValue VisitSpecification(EMSLParser.SpecificationContext context)
        {
            var name = this.Visit(context.name_definition());

            var migrationSpecification = new MigrationSpecification()
            {
                Name = name.AsString()
            };
            return new EmslValue(migrationSpecification);
        }
    }
}