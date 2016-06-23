using System;
using System.Collections.Generic;

namespace OraclePackageManager.Objects
{
    public class PackageObject
    {
        private IList<CommandObject> _commands = new List<CommandObject>();

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }

        public IList<CommandObject> Commands
        {
            get
            {
                return _commands;
            }
            set
            {
                _commands = value;
            }
        }

    }
}