using System;
using System.Collections.Generic;
using System.Text;

using SCOTCH.DBManager.odbc;

namespace SCOTCH.DBManager.dao
{
    public abstract class DAOFactory
    {
        private static DAOFactory singleton;

        public static DAOFactory getInstance()
        {
            //DAOFactory newDAO = null;
            try
            {
                if (singleton == null)
                {
                    singleton = new SQLDAOFactory();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return singleton;
        }

        public abstract DatabaseDAO getDatabaseDAO();
    }
}
