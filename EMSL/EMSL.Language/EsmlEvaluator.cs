using System.Collections.Generic;
using System.Linq;
using EMSL.Language.Models;

namespace EMSL.Language
{
    internal class EsmlEvaluator : EMSLBaseVisitor<EmslValue>
    {
        private MigrationCsp DefaultSourceCsp;
        private MigrationCsp DefaultTargetCsp;

        private Dictionary<string, MigrationCsp> SourceCsps;
        private Dictionary<string, MigrationCsp> TargetCsps;
        
        public override EmslValue VisitSpecification(EMSLParser.SpecificationContext context)
        {
            var name = Visit(context.name_definition());
            
            // Source CSPs
            var sourceCspValues = context.source_definition().Select(Visit);
            var sourceCsps = sourceCspValues
                .Select(sourceCsp => sourceCsp.AsMigrationCsp())
                .ToList();
            if (sourceCsps.Count == 1)
            {
                DefaultSourceCsp = sourceCsps.First();
            }
            SourceCsps = sourceCsps.ToDictionary(csp => csp.Name);
            
            // Target CSPs
            var targetCspValues = context.target_definition().Select(Visit);
            var targetCsps = targetCspValues
                .Select(targetCsp => targetCsp.AsMigrationCsp())
                .ToList();
            if (targetCsps.Count == 1)
            {
                DefaultTargetCsp = targetCsps.First();
            }
            TargetCsps = targetCsps.ToDictionary(csp => csp.Name);

            // Required resources
            var resourceValues = context.resource_definition().Select(Visit).ToList();
            var intermediateResources = resourceValues.Select(value => 
                value.AsIntermediateMigrationResource());
            var requiredResources = AsMigrationResource(intermediateResources);

            var migrationSpecification = new MigrationSpecification()
            {
                Name = name.AsString(),
                SourceCsps = sourceCsps,
                TargetCsps = targetCsps,
                Resources = requiredResources
            };
            return new EmslValue(migrationSpecification);
        }
        
        public override EmslValue VisitName_definition(EMSLParser.Name_definitionContext context)
        {
            var node = context.STRING_LITERAL();
            var symbol = node.Symbol;
            var text = symbol.Text;
            return new EmslValue(text);
        }

        public override EmslValue VisitSource_definition(EMSLParser.Source_definitionContext context)
        {
            var name = context.STRING_LITERAL()[0].Symbol.Text;
            var hostname = context.STRING_LITERAL()[1].Symbol.Text;
            var port = int.Parse(context.INT_LITERAL().Symbol.Text);

            var migrationCsp = new MigrationCsp()
            {
                Name = name,
                Hostname = hostname,
                Port = port
            };

            return new EmslValue(migrationCsp);
        }

        public override EmslValue VisitTarget_definition(EMSLParser.Target_definitionContext context)
        {
            var name = context.STRING_LITERAL()[0].Symbol.Text;
            var hostname = context.STRING_LITERAL()[1].Symbol.Text;
            var port = int.Parse(context.INT_LITERAL().Symbol.Text);

            var migrationCsp = new MigrationCsp()
            {
                Name = name,
                Hostname = hostname,
                Port = port
            };

            return new EmslValue(migrationCsp);
        }

        public override EmslValue VisitResource_definition(EMSLParser.Resource_definitionContext context)
        {
            var name = context.STRING_LITERAL()[0].Symbol.Text;
            var type = AsMigrationResourceType(context.RESOURCE_TYPE().Symbol.Text);
            MigrationCsp sourceCsp;
            
            var hasSpecifiedSource = context.FROM() != null;
            if (hasSpecifiedSource)
            {
                var sourceCspName = context.STRING_LITERAL()[1].Symbol.Text;
                var sourceCspHasBeenDefined = SourceCsps.TryGetValue(sourceCspName, out sourceCsp);
                if (!sourceCspHasBeenDefined)
                {
                    throw new EmslUndefinedSourceException(sourceCspName);
                }
            }
            else
            {
                sourceCsp = DefaultSourceCsp;
            }
            
            MigrationCsp targetCsp;
            var hasSpecifiedTarget = context.TO() != null;
            if (hasSpecifiedTarget)
            {
                var targetCspName = context.STRING_LITERAL().Skip(1 + (hasSpecifiedSource ? 1 : 0)).First().Symbol.Text;
                var targetCspHasBeenDefined = TargetCsps.TryGetValue(targetCspName, out targetCsp);
                if (!targetCspHasBeenDefined)
                {
                    throw new EmslUndefinedSourceException(targetCspName);
                }
            }
            else
            {
                targetCsp = DefaultTargetCsp;
            }

            var requiredResources = context.requires_definition_value() is not null ?
                Visit(context.requires_definition_value()).AsStringIEnumerable() :
                [];

            var resource = new IntermediateMigrationResource()
            {
                Name = name,
                Type = type,
                SourceCsp = sourceCsp,
                TargetCsp = targetCsp,
                RequiredResourceNames = requiredResources
            };
            return new EmslValue(resource);
        }

        public override EmslValue VisitRequires_definition_value(EMSLParser.Requires_definition_valueContext context)
        {
            var resultList = context.requires_definition_value() != null
                ? Visit(context.requires_definition_value()).AsStringIEnumerable()
                : [];

            resultList = resultList.Append(context.STRING_LITERAL().Symbol.Text);
            return new EmslValue(resultList);
        }

        private static MigrationResourceType AsMigrationResourceType(string rawMigrationResourceType)
        {
            return rawMigrationResourceType switch
            {
                "K8S" => MigrationResourceType.K8S,
                "VM" => MigrationResourceType.VM,
                _ => throw new EmslUnsupportedResourceTypeException(rawMigrationResourceType)
            };
        }

        private static IEnumerable<MigrationResource> AsMigrationResource(
            IEnumerable<IntermediateMigrationResource> intermediateMigrationResources)
        {
            var imrs = intermediateMigrationResources.ToList();
            var resourceDict = imrs
                .Select(imr => new MigrationResource()
                {
                    Name = imr.Name,
                    Type = imr.Type,
                    SourceCsp = imr.SourceCsp,
                    TargetCsp = imr.TargetCsp,
                    RequiredResources = []
                })
                .ToDictionary(imr => imr.Name);

            foreach (var resource in imrs)
            {
                foreach (var rrName in resource.RequiredResourceNames)
                {
                    if (resourceDict.TryGetValue(rrName, out var mr))
                    {
                        resourceDict[resource.Name].RequiredResources = resourceDict[resource.Name].RequiredResources.Append(mr);
                        // mr.RequiredResources = mr.RequiredResources.Append(mr);
                    }
                    else
                    {
                        throw new EmslUndefinedResourceException(rrName);
                    }
                }
            }

            return resourceDict.Values;
        }
        
        
    }
}