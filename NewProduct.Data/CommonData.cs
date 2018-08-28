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
        private static string _NPD_SELECT_PRODUCT_OTHER = "npd_select_product_other";
        private static string _NPD_INSERT_PRODUCT_HAMPER_TEMP = "npd_insert_product_hamper_temp";
        private static string _NPD_DELETE_ALL_PRODUCT_HAMPER_TEMP_BY_REFERENCE_NO = "npd_delete_all_product_hamper_temp_by_reference_no";

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

        public CommonDataSet npd_select_product_other()
        {
            try
            {
                SqlParameter[] pm = null;

                CommonDataSet ds = new CommonDataSet();

                return (CommonDataSet)DAOFactory.getInstance().getDatabaseDAO().ExcecuteDataSet(ds,
                    ds.NPD_SELECT_PRODUCT_OTHER.TableName, _NPD_SELECT_PRODUCT_OTHER, pm, strConnCommon);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CommonDataSet npd_insert_product_hamper_temp(string reference_no, string product_id,
            string product_sub_id, int quantity, int hamper_extra, float price)
        {
            try
            {
                SqlParameter[] pm = new SqlParameter[6];

                pm[0] = new SqlParameter("@REFERENCE_NO", SqlDbType.VarChar);
                pm[0].Value = reference_no;

                pm[1] = new SqlParameter("@PRODUCT_ID", SqlDbType.VarChar);
                pm[1].Value = product_id;

                pm[2] = new SqlParameter("@PRODUCT_SUB_ID", SqlDbType.VarChar);
                pm[2].Value = product_sub_id;

                pm[3] = new SqlParameter("@QUANTITY", SqlDbType.Int);
                pm[3].Value = quantity;

                pm[4] = new SqlParameter("@HAMPER_EXTRA", SqlDbType.Int);
                pm[4].Value = hamper_extra;

                pm[5] = new SqlParameter("@PRICE", SqlDbType.Float);
                pm[5].Value = price;

                CommonDataSet ds = new CommonDataSet();

                return (CommonDataSet)DAOFactory.getInstance().getDatabaseDAO().ExcecuteDataSet(ds,
                    ds.NPD_INSERT_PRODUCT_HAMPER_TEMP.TableName, _NPD_INSERT_PRODUCT_HAMPER_TEMP, pm, strConnCommon);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CommonDataSet npd_delete_all_product_hamper_temp_by_reference_no(string reference_no)
        {
            try
            {
                SqlParameter[] pm = new SqlParameter[1];

                pm[0] = new SqlParameter("@REFERENCE_NO", SqlDbType.VarChar);
                pm[0].Value = reference_no;

                CommonDataSet ds = new CommonDataSet();

                return (CommonDataSet)DAOFactory.getInstance().getDatabaseDAO().ExcecuteDataSet(ds,
                    ds.NPD_DELETE_ALL_PRODUCT_HAMPER_TEMP_BY_REFERENCE_NO.TableName, 
                    _NPD_DELETE_ALL_PRODUCT_HAMPER_TEMP_BY_REFERENCE_NO, pm, strConnCommon);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
