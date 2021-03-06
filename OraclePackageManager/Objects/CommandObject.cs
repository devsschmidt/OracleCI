﻿using System;

namespace OraclePackageManager.Objects
{
    public class CommandObject
    {
        public Guid Id { get; set; }
        public CommandType Type { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int SortIndex { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
    }
}