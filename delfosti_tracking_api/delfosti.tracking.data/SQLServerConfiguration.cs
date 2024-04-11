using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delfosti.tracking.data
{
    public class SQLServerConfiguration
    {
        public SQLServerConfiguration(string connectionString) => ConnectionString = ConnectionString;
        public string ConnectionString { get; set; }
    }
}
