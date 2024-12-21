using System.Collections.Generic;

namespace EMSL.Language.Models
{
    public class MigrationSpecification
    {
        public string Name { get; set; }
        public IEnumerable<MigrationCsp> SourceCsps { get; set; }
        public IEnumerable<MigrationCsp> TargetCsps { get; set; }
        public IEnumerable<MigrationResource> Resources { get; set; }
    }
}