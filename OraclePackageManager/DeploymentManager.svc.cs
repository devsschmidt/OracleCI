using OraclePackageManager.Objects;
using System;
using System.Diagnostics;

namespace OraclePackageManager
{
    public class DeploymentManager : IDeploymentManager
    {
        public void deployPackage(Guid PackageId, Guid ConnectionId)
        {
            DataControl DataManager = new DataControl();

            Connection ConnectionData = DataManager.getConnection(ConnectionId);
            Package PackageData = DataManager.getPackage(PackageId);

            Trace.TraceInformation("123");

        }
    }
}
