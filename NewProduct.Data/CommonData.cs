﻿using System;
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
        private static string _SELECT_PRODUCT_TYPE_ALL = "select_product_type_all";

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

        public CommonDataSet select_product_type_all()
        {
            try
            {
                SqlParameter[] pm = null;

                CommonDataSet ds = new CommonDataSet();

                return (CommonDataSet)DAOFactory.getInstance().getDatabaseDAO().ExcecuteDataSet(ds,
                    ds.SELECT_PRODUCT_TYPE_ALL.TableName, _SELECT_PRODUCT_TYPE_ALL, pm, strConnCommon);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
