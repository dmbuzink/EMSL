namespace EMSL.Language.Models
{
    public class MigrationSpecification
    {
        public string Name { get; set; }
        public MigrationCsp[] SourceCsps { get; set; }
        public MigrationCsp[] TargetCsps { get; set; }
        public MigrationResource Resources { get; set; }
    }
}