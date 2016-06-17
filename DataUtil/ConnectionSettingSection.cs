using System.Collections.Generic;
using System.Configuration;

namespace DataUtil
{
    public class ConnectionSettingSection : ConfigurationSection
    {
        [ConfigurationProperty("TNS", DefaultValue = "localhost", IsRequired = true)]
        public string TNS
        {
            get
            {
                return (string)this["TNS"];
            }
            set
            {
                this["TNS"] = value;
            }
        }

        [ConfigurationProperty("User", DefaultValue = "orcl", IsRequired = true)]
        public string User
        {
            get
            {
                return (string)this["User"];
            }
            set
            {
                this["User"] = value;
            }
        }

        [ConfigurationProperty("Password", DefaultValue = "", IsRequired = true)]
        public string Password
        {
            get
            {
                return (string)this["Password"];
            }
            set
            {
                this["Password"] = value;
            }
        }

        [ConfigurationProperty("MaxPoolSize", DefaultValue = "10", IsRequired = false)]
        [IntegerValidator(ExcludeRange = false, MinValue = 1)]
        public int MaxPoolSize
        {
            get
            {
                return (int)this["MaxPoolSize"];
            }
            set
            {
                this["MaxPoolSize"] = value;
            }
        }

        [ConfigurationProperty("MinPoolSize", DefaultValue = "1", IsRequired = false)]
        [IntegerValidator(ExcludeRange = false, MinValue = 1)]
        public int MinPoolSize
        {
            get
            {
                return (int)this["MinPoolSize"];
            }
            set
            {
                this["MinPoolSize"] = value;
            }
        }

        [ConfigurationProperty("InitialStatements", IsRequired = false)]
        [ConfigurationCollection(typeof(InitialStatement), AddItemName = "Statement", ClearItemsName = "clear", RemoveItemName = "remove")]
        public GenericConfigurationElementCollection<InitialStatement> InitialStatements
        {
            get
            {
                return (GenericConfigurationElementCollection<InitialStatement>)this["InitialStatements"];
            }
        }

        public string doSomthing()
        { return ""; }
    }

    public class InitialStatement : ConfigurationElement
    {
        public InitialStatement() { }

        public InitialStatement(string statement)
        {
            Value = statement;
        }

        [ConfigurationProperty("Value", DefaultValue = "", IsRequired = true)]
        public string Value
        {
            get
            {
                return (string)this["Value"];
            }

            set
            {
                this["Value"] = value;
            }
        }

    }

    public class GenericConfigurationElementCollection<T> : ConfigurationElementCollection, IEnumerable<T> where T : ConfigurationElement, new()
    {
        List<T> _elements = new List<T>();

        protected override ConfigurationElement CreateNewElement()
        {
            T newElement = new T();
            _elements.Add(newElement);
            return newElement;
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return _elements.Find(e => e.Equals(element));
        }

        public new IEnumerator<T> GetEnumerator()
        {
            return _elements.GetEnumerator();
        }
    }

}
