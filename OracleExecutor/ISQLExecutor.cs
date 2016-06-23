using OracleExecutor.Objects;
using System.ServiceModel;

namespace OracleExecutor
{
    [ServiceContract]
    public interface ISQLExecutor
    {
        [OperationContract]
        Output deployPackageToDB(Connection ConnectionData, Package Package);


    }
}
