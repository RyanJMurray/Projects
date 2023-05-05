using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BeautyAndCosmetics
{
    class ConnectionString
    {
        public static SqlConnection Connect = new SqlConnection("server = DESKTOP-NDBK6OS\\SQLEXPRESS; initial catalog =BeautyAndCosmetics_RM; integrated security = true; MultipleActiveResultSets=true; ");
    }
}
