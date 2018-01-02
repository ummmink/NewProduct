using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

using NewProduct.Entity;
using SCOTCH.DBManager.dao;
using SCOTCH.DBManager.odbc;

namespace NewProduct.Data
{
    public class CommonData
    {
        private static string strConnCommon = ConfigurationManager.ConnectionStrings["SQLConnectionCommon"].ConnectionString;

        private static string _SELECT_PRODUCT_ALL_STATUS = "select_product_all_status";

        public CommonDataSet select_product_all_status()
        {
            try
            {
                SqlParameter[] pm = null;

                CommonDataSet ds = new CommonDataSet();

                return (CommonDataSet)DAOFactory.getInstance().getDatabaseDAO().ExcecuteDataSet(ds,
                    ds.SELECT_PRODUCT_ALL_STATUS.TableName, _SELECT_PRODUCT_ALL_STATUS, pm, strConnCommon);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
