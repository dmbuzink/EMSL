using System.Collections.Generic;

namespace EMSL.Language.Models
{
    /// <summary>
    /// Exclusively used as an intermediate version, because during parsing all
    /// resources have not yet been retrieved. 
    /// </summary>
    internal class IntermediateMigrationResource
    {
        public string Name { get; set; }
        public MigrationResourceType Type { get; set; }
        public MigrationCsp SourceCsp { get; set; }
        public MigrationCsp TargetCsp { get; set; }
        public IEnumerable<string> RequiredResourceNames { get; set; }
        public IEnumerable<MigrationResource> RequiredResources { get; set; } = [];
    }
}