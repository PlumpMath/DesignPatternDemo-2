using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public class SqlDbProvider
    {
        private static readonly SqlDbProvider _instance = new SqlDbProvider(); // Singleton

        public static SqlDbProvider Instance
        {
            get { return _instance; }
        }

        private SqlDbProvider()
        {
        }

        public IEnumerable<T> ExecuteQuery<T>(string query)
        {
            throw new NotImplementedException(query);
        }
    }
}
