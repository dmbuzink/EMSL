namespace EMSL.Language.Models
{
    public class EmslValue
    {
        private readonly object _value;

        public EmslValue(object value)
        {
            _value = value;
        }

        public string AsString()
        {
            return (string)_value;
        }

        public int AsInt()
        {
            return (int)_value;
        }

        public MigrationSpecification AsMigrationSpecifications()
        {
            return (MigrationSpecification)_value;
        }

        public MigrationResource AsMigrationResource()
        {
            return (MigrationResource)_value;
        }

        public MigrationCsp AsMigrationCsp()
        {
            return (MigrationCsp)_value;
        }
    }
}