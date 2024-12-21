using System.Collections.Generic;

namespace EMSL.Language.Models
{
    public class MigrationResource
    {
        public string Name { get; set; }
        public MigrationResourceType Type { get; set; }
        public MigrationCsp SourceCsp { get; set; }
        public MigrationCsp TargetCsp { get; set; }
        public IEnumerable<MigrationResource> RequiredResources { get; set; }
    }
}