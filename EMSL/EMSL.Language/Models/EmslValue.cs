using System.Collections.Generic;

namespace EMSL.Language.Models
{
    internal class EmslValue
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

        public MigrationSpecification AsMigrationSpecification()
        {
            return (MigrationSpecification)_value;
        }

        public MigrationResource AsMigrationResource()
        {
            return (MigrationResource)_value;
        }

        internal IntermediateMigrationResource AsIntermediateMigrationResource()
        {
            return (IntermediateMigrationResource)_value;
        }

        public MigrationCsp AsMigrationCsp()
        {
            return (MigrationCsp)_value;
        }

        public IEnumerable<string> AsStringIEnumerable()
        {
            return (IEnumerable<string>)_value;
        }
    }
}