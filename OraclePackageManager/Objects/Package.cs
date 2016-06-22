using System;
using System.Collections.Generic;

namespace OraclePackageManager.Objects
{
    public class Package
    {
        private IList<Command> _commands = new List<Command>();

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }

        public IList<Command> Commands
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