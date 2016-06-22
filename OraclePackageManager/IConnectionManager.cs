using OraclePackageManager.Objects;
using System.Collections.Generic;
using System.ServiceModel;

namespace OraclePackageManager
{
    [ServiceContract]
    public interface IConnectionManager
    {
        [OperationContract]
        IList<Connection> getConnections();
    }
}
