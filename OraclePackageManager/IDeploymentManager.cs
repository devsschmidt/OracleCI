using System;
using System.ServiceModel;

namespace OraclePackageManager
{
    [ServiceContract]
    public interface IDeploymentManager
    {
        [OperationContract]
        void deployPackage(Guid PackageId, Guid ConnectionId);
    }
}
