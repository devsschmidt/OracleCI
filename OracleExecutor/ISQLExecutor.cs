using OracleExecutor.Objects;
using System.ServiceModel;

namespace OracleExecutor
{
    [ServiceContract]
    public interface ISQLExecutor
    {
        [OperationContract]
        Output deployPackageToDB(ConnectionData ConnectionData, Package Package);


    }
}
