using OraclePackageManager.Objects;
using OraclePackageManager.OracleExecutorService;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace OraclePackageManager
{
    public class DeploymentManager : IDeploymentManager
    {
        private CommandGroup transformCommandGroup(CommandGroupType GroupType, IEnumerable<CommandObject> Commands)
        {
            CommandGroup result = new CommandGroup();
            result.Commands = new List<Command>();
            result.Type = GroupType;

            foreach (CommandObject command in Commands)
                result.Commands.Add(new Command() { Id = command.Id.ToString(), Text = command.Value });

            return result;
        }

        private Package transferPackage(PackageObject PackageData)
        {
            Package result = new Package();
            
            result.Id = PackageData.Id;
            result.CommandGroups = new List<CommandGroup>();

            if (PackageData.Commands.Count > 0)
            {
                result.CommandGroups.Add(transformCommandGroup(CommandGroupType.Pre, PackageData.Commands.Where(elem => elem.Type == CommandType.PRE)));
                result.CommandGroups.Add(transformCommandGroup(CommandGroupType.Main, PackageData.Commands.Where(elem => elem.Type == CommandType.MAIN)));
                result.CommandGroups.Add(transformCommandGroup(CommandGroupType.Post, PackageData.Commands.Where(elem => elem.Type == CommandType.POST)));
            }
            return result;
        }

        public void deployPackage(Guid PackageId, Guid ConnectionId)
        {
            PackageId = Guid.Parse("9e0b2d57-a63b-4493-91a7-7b0504a81923");
            ConnectionId = Guid.Parse("a0154912-5f1a-47f7-b5bb-228f3be29c4d");

            DataControl DataManager = new DataControl();

            ConnectionObject ConnectionData = DataManager.getConnection(ConnectionId);
            PackageObject PackageData = DataManager.getPackage(PackageId);



            SQLExecutorClient ExecutorClient = new SQLExecutorClient();

            ExecutorClient.deployPackageToDB(
                new Connection()
                {
                    Id = ConnectionData.Id,
                    TNS = ConnectionData.TNS,
                    User = ConnectionData.User,
                    Password = ConnectionData.Password,
                    MinPoolSize = ConnectionData.MinPoolSize,
                    MaxPoolSize = ConnectionData.MaxPoolSize
                },
                transferPackage(PackageData)

            );
            
        }

        
    }
}
