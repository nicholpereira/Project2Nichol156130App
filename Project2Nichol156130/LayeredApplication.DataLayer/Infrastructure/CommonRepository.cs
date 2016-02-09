using LayeredApplication.DataLayer.Infrastructure.DataProvider;
using LayeredApplication.DataLayer.Infrastructure.Repository;
using LayeredApplication.DataLayer.Infrastructure.SqlDataProvider;
using LayeredApplication.Model;
using System.Configuration;

namespace LayeredApplication.DataLayer.Infrastructure
{
    public sealed class RepositoryProvider
    {
        private static IContext<Vehicle> instance { get; set; }

        private RepositoryProvider()
        {

        }

        public static IContext<Vehicle> Instance
        {
            get
            {
                if (instance == null)
                {
                    //NOTE:uncomment this to use sql server for data storage and fetch
                    //var str = ConfigurationManager.ConnectionStrings["LASQLConnection"].ConnectionString;
                    //instance = new SqlRepository(str);

                    ///NOTE:uncomment this to use hardcoded data and in-memory storage and fetch
                    instance = new HardCodedRepository();
                }
                return instance;
            }
        }

    }
}
