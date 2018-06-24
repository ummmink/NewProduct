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
using System.Data;

namespace NewProduct.Data
{
    public class CommonData
    {
        private static string strConnCommon = ConfigurationManager.ConnectionStrings["SQLConnectionCommon"].ConnectionString;

        private static string _SELECT_PRODUCT_ALL_STATUS = "select_product_all_status";
        private static string _NPD_SELECT_PRODUCT_ITEM_NO_DESC_ITEM_NAME_CODE_BY_TYPE_ID = "npd_select_product_item_no_desc_item_name_code_by_type_id";
        private static string _NPD_SELECT_PRODUCT_TYPE = "npd_select_product_type";
        private static string _NPD_SELECT_PRODUCT_SELL_ALL_ACTIVE = "npd_select_product_sell_all_active";
        private static string _NPD_SELECT_PRODUCT_DEPARTMENT_ROLE_BY_USER_GROUP_ID = "npd_select_product_department_role_by_user_group_id";
        private static string _NPD_SELECT_MAIN_PRODUCT = "npd_select_main_product";

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

        public CommonDataSet npd_select_product_item_no_desc_item_name_code_by_type_id(int type_id)
        {
            try
            {
                SqlParameter[] pm = new SqlParameter[1];

                pm[0] = new SqlParameter("@TYPE_ID", SqlDbType.Int);
                pm[0].Value = type_id;

                CommonDataSet ds = new CommonDataSet();

                return (CommonDataSet)DAOFactory.getInstance().getDatabaseDAO().ExcecuteDataSet(ds,
                    ds.NPD_SELECT_PRODUCT_ITEM_NO_DESC_ITEM_NAME_CODE_BY_TYPE_ID.TableName, _NPD_SELECT_PRODUCT_ITEM_NO_DESC_ITEM_NAME_CODE_BY_TYPE_ID, pm, strConnCommon);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CommonDataSet npd_select_product_type()
        {
            try
            {
                SqlParameter[] pm = null;

                CommonDataSet ds = new CommonDataSet();

                return (CommonDataSet)DAOFactory.getInstance().getDatabaseDAO().ExcecuteDataSet(ds,
                    ds.NPD_SELECT_PRODUCT_TYPE.TableName, _NPD_SELECT_PRODUCT_TYPE, pm, strConnCommon);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CommonDataSet npd_select_product_sell_all_active()
        {
            try
            {
                SqlParameter[] pm = null;

                CommonDataSet ds = new CommonDataSet();

                return (CommonDataSet)DAOFactory.getInstance().getDatabaseDAO().ExcecuteDataSet(ds,
                    ds.NPD_SELECT_PRODUCT_SELL_ALL_ACTIVE.TableName, _NPD_SELECT_PRODUCT_SELL_ALL_ACTIVE, pm, strConnCommon);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CommonDataSet npd_select_product_department_role_by_user_group_id(string user_group_id)
        {
            try
            {
                SqlParameter[] pm = new SqlParameter[1];

                pm[0] = new SqlParameter("@USER_GROUP_ID", SqlDbType.VarChar);
                pm[0].Value = user_group_id;

                CommonDataSet ds = new CommonDataSet();

                return (CommonDataSet)DAOFactory.getInstance().getDatabaseDAO().ExcecuteDataSet(ds,
                    ds.NPD_SELECT_PRODUCT_DEPARTMENT_ROLE_BY_USER_GROUP_ID.TableName, _NPD_SELECT_PRODUCT_DEPARTMENT_ROLE_BY_USER_GROUP_ID, pm, strConnCommon);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CommonDataSet npd_select_main_product()
        {
            try
            {
                SqlParameter[] pm = null;

                CommonDataSet ds = new CommonDataSet();

                return (CommonDataSet)DAOFactory.getInstance().getDatabaseDAO().ExcecuteDataSet(ds,
                    ds.NPD_SELECT_MAIN_PRODUCT.TableName, _NPD_SELECT_MAIN_PRODUCT, pm, strConnCommon);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
