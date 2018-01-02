using System;
using System.Collections.Generic;
using System.Text;

using SCOTCH.DBManager.dao;

namespace SCOTCH.DBManager.odbc
{
    public class SQLDAOFactory : DAOFactory
    {
        public override DatabaseDAO getDatabaseDAO()
        {
            return new DatabaseDAOImpl();
        }
    }
}
