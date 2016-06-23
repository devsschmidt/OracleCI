using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using OraclePackageManager.Objects;

namespace OraclePackageManager
{
    public class ConnectionManager : IConnectionManager
    {
        public IList<ConnectionObject> getConnections()
        {
            return new DataControl().getConnections();
        }
    }
}
