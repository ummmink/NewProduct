using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using System.Data.SqlClient;

namespace SCOTCH.DBManager.dao
{
    public interface DatabaseDAO
    {

        DataSet ExcecuteDataSet(DataSet ds, String tableName, String commandText, SqlParameter[] pm, 
            string connectionString);

        int NonExcecute(String commandText, SqlParameter[] pm, string connectionString);

    }
}
 