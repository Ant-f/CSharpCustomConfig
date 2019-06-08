using System.Configuration;

namespace CustomConfig
{
    class CustomConfigSection : ConfigurationSection
    {
        private const string CollectionName = "propertyPairCollection";

        [ConfigurationProperty(CollectionName)]
        [ConfigurationCollection(typeof(PropertyPairCollection), AddItemName = "add")]
        public PropertyPairCollection PropertyPairs
        {
            get => (PropertyPairCollection)base[CollectionName];
        }
    }

    public class PropertyPairCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new PropertyPair();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            var col = (PropertyPair)element;
            return col.Id;
        }
    }

    public class PropertyPair : ConfigurationElement
    {
        private const string IdName = "id";
        private const string PropertyOneName = "propertyOne";
        private const string PropertyTwoName = "propertyTwo";

        [ConfigurationProperty(IdName, IsRequired = true)]
        public int Id
        {
            get => (int)this[IdName];
            set => this[IdName] = value;
        }

        [ConfigurationProperty(PropertyOneName, IsRequired = false)]
        public string PropertyOne
        {
            get => this[PropertyOneName] as string;
            set => this[PropertyOneName] = value;
        }

        [ConfigurationProperty(PropertyTwoName, IsRequired = false)]
        public string PropertyTwo
        {
            get => this[PropertyTwoName] as string;
            set => this[PropertyTwoName] = value;
        }
    }
}
