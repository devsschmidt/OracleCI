using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Configuration;

namespace DataUtil.Tests
{
    [TestClass()]
    public class ConnectionSettingSectionTests
    {
        [TestMethod()]
        public void TestConfiguration()
        {
            try
            {
                ConnectionSettingSection config = (ConnectionSettingSection)ConfigurationManager.GetSection("Database.Connection");

                Trace.TraceInformation(
                        String.Format("\n TNS {0} \n User {1} \n Password {2} \n MinPoolsize {3} - MaxPoolSize {4}",
                            config.TNS,
                            config.User,
                            config.Password,
                            config.MinPoolSize.ToString(),
                            config.MaxPoolSize.ToString()
                            )
                );

                if (
                    !(config.TNS.Equals("mytns") && 
                      config.User.Equals("myuser") && 
                      config.Password.Equals("mypassword") && 
                      config.MinPoolSize == 20 &&
                      config.MaxPoolSize == 100
                     )
                   )
                {
                    Assert.Fail("wrong values");
                }
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}