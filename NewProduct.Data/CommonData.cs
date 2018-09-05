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
        private static string _NPD_SELECT_PRODUCT_TYPE = "npd_select_product_type";
        private static string _NPD_SELECT_PRODUCT_SELL_ALL_ACTIVE = "npd_select_product_sell_all_active";
        private static string _NPD_SELECT_PRODUCT_DEPARTMENT_ROLE_BY_USER_GROUP_ID = "npd_select_product_department_role_by_user_group_id";
        private static string _NPD_SELECT_MAIN_PRODUCT = "npd_select_main_product";
        private static string _NPD_SELECT_PRODUCT_OTHER = "npd_select_product_other";
        private static string _NPD_INSERT_PRODUCT_HAMPER_TEMP = "npd_insert_product_hamper_temp";
        private static string _NPD_DELETE_ALL_PRODUCT_HAMPER_TEMP_BY_REFERENCE_NO = "npd_delete_all_product_hamper_temp_by_reference_no";
        private static string _NPD_SELECT_PRODUCT_HAMPER_TEMP_BY_REFERENCE_NO = "npd_select_product_hamper_temp_by_reference_no";
        private static string _NPD_SELECT_PRODUCT_NAME_TH_BY_PRODUCT_ID = "npd_select_product_name_th_by_product_id";
        private static string _NPD_INSERT_PRODUCT_TEMP = "npd_insert_product_temp";

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

        public CommonDataSet npd_select_product_hamper_temp_by_reference_no(string reference_no)
        {
            try
            {
                SqlParameter[] pm = new SqlParameter[1];

                pm[0] = new SqlParameter("@REFERENCE_NO", SqlDbType.VarChar);
                pm[0].Value = reference_no;

                CommonDataSet ds = new CommonDataSet();

                return (CommonDataSet)DAOFactory.getInstance().getDatabaseDAO().ExcecuteDataSet(ds,
                    ds.NPD_SELECT_PRODUCT_HAMPER_TEMP_BY_REFERENCE_NO.TableName, _NPD_SELECT_PRODUCT_HAMPER_TEMP_BY_REFERENCE_NO, pm, strConnCommon);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CommonDataSet npd_select_product_name_th_by_product_id(string product_id)
        {
            try
            {
                SqlParameter[] pm = new SqlParameter[1];

                pm[0] = new SqlParameter("@PRODUCT_ID", SqlDbType.VarChar);
                pm[0].Value = product_id;

                CommonDataSet ds = new CommonDataSet();

                return (CommonDataSet)DAOFactory.getInstance().getDatabaseDAO().ExcecuteDataSet(ds,
                    ds.NPD_SELECT_PRODUCT_NAME_TH_BY_PRODUCT_ID.TableName, _NPD_SELECT_PRODUCT_NAME_TH_BY_PRODUCT_ID, pm, strConnCommon);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CommonDataSet npd_insert_product_temp(string reference_no, string product_id, string nickname, string item_no
            , int type_id, string product_name_th, string product_unit, string product_name_eng, int packing, int bottle
            , float size, DateTime sell_date, int inner_box, int free, string user_create, string item_no2
            , string product_name_eng_invoice, string product_name_th_invoice, string decorated_area1, string decorated_area2
            , string decorated_area3, string decoration_other_details, string decoration_remarkable_of_box, string decoration1
            , string decoration2, string decoration3, string image_path, int other_id, float price_per_case, float price_recommend
            , string product_prefix, DateTime sample_date, int sample_qty_bottle, int sample_qty_box, string schedule, int sell_id
            , int sell_qty_bottle, int sell_qty_box, string remark, int shipping_terms_id)
        {
            try
            {
                SqlParameter[] pm = new SqlParameter[40];

                pm[0] = new SqlParameter("@REFERENCE_NO", SqlDbType.VarChar);
                pm[0].Value = reference_no;

                pm[1] = new SqlParameter("@PRODUCT_ID", SqlDbType.VarChar);
                pm[1].Value = product_id;

                pm[2] = new SqlParameter("@NICKNAME", SqlDbType.VarChar);
                pm[2].Value = nickname;

                pm[3] = new SqlParameter("@ITEM_NO", SqlDbType.VarChar);
                pm[3].Value = item_no;

                pm[4] = new SqlParameter("@TYPE_ID", SqlDbType.Int);
                pm[4].Value = type_id;

                pm[5] = new SqlParameter("@PRODUCT_NAME_TH", SqlDbType.VarChar);
                pm[5].Value = product_name_th;

                pm[6] = new SqlParameter("@PRODUCT_UNIT", SqlDbType.VarChar);
                pm[6].Value = product_unit;

                pm[7] = new SqlParameter("@PRODUCT_NAME_ENG", SqlDbType.VarChar);
                pm[7].Value = product_name_eng;

                pm[8] = new SqlParameter("@PACKING", SqlDbType.Int);
                pm[8].Value = packing;

                pm[9] = new SqlParameter("@BOTTLE", SqlDbType.Int);
                pm[9].Value = bottle;

                pm[10] = new SqlParameter("@SIZE", SqlDbType.Float);
                pm[10].Value = size;

                pm[11] = new SqlParameter("@SELL_DATE", SqlDbType.DateTime);
                pm[11].Value = sell_date;

                pm[12] = new SqlParameter("@INNER_BOX", SqlDbType.Int);
                pm[12].Value = inner_box;

                pm[13] = new SqlParameter("@FREE", SqlDbType.Int);
                pm[13].Value = free;

                pm[14] = new SqlParameter("@USER_CREATE", SqlDbType.VarChar);
                pm[14].Value = user_create;

                pm[15] = new SqlParameter("@ITEM_NO2", SqlDbType.VarChar);
                pm[15].Value = item_no2;

                pm[16] = new SqlParameter("@PRODUCT_NAME_ENG_Invoice", SqlDbType.VarChar);
                pm[16].Value = product_name_eng_invoice;

                pm[17] = new SqlParameter("@PRODUCT_NAME_TH_Invoice", SqlDbType.VarChar);
                pm[17].Value = product_name_th_invoice;

                pm[18] = new SqlParameter("@DECORATED_AREA1", SqlDbType.VarChar);
                pm[18].Value = decorated_area1;

                pm[19] = new SqlParameter("@DECORATED_AREA2", SqlDbType.VarChar);
                pm[19].Value = decorated_area2;

                pm[20] = new SqlParameter("@DECORATED_AREA3", SqlDbType.VarChar);
                pm[20].Value = decorated_area3;

                pm[21] = new SqlParameter("@DECORATION_OTHER_DETAILS", SqlDbType.VarChar);
                pm[21].Value = decoration_other_details;

                pm[22] = new SqlParameter("@DECORATION_REMARKABLE_OF_BOX", SqlDbType.VarChar);
                pm[22].Value = decoration_remarkable_of_box;

                pm[23] = new SqlParameter("@DECORATION1", SqlDbType.VarChar);
                pm[23].Value = decoration1;

                pm[24] = new SqlParameter("@DECORATION2", SqlDbType.VarChar);
                pm[24].Value = decoration2;

                pm[25] = new SqlParameter("@DECORATION3", SqlDbType.VarChar);
                pm[25].Value = decoration3;

                pm[26] = new SqlParameter("@IMAGE_PATH", SqlDbType.VarChar);
                pm[26].Value = image_path;

                pm[27] = new SqlParameter("@OTHER_ID", SqlDbType.Int);
                pm[27].Value = other_id;

                pm[28] = new SqlParameter("@PRICE_PER_CASE", SqlDbType.Float);
                pm[28].Value = price_per_case;

                pm[29] = new SqlParameter("@PRICE_RECOMMEND", SqlDbType.Float);
                pm[29].Value = price_recommend;

                pm[30] = new SqlParameter("@PRODUCT_PREFIX", SqlDbType.VarChar);
                pm[30].Value = product_prefix;

                pm[31] = new SqlParameter("@SAMPLE_DATE", SqlDbType.DateTime);
                pm[31].Value = sample_date;

                pm[32] = new SqlParameter("@SAMPLE_QTY_BOTTLE", SqlDbType.Int);
                pm[32].Value = sample_qty_bottle;

                pm[33] = new SqlParameter("@SAMPLE_QTY_BOX", SqlDbType.Int);
                pm[33].Value = sample_qty_box;

                pm[34] = new SqlParameter("@SCHEDULE", SqlDbType.VarChar);
                pm[34].Value = schedule;

                pm[35] = new SqlParameter("@SELL_ID", SqlDbType.Int);
                pm[35].Value = sell_id;

                pm[36] = new SqlParameter("@SELL_QTY_BOTTLE", SqlDbType.Int);
                pm[36].Value = sell_qty_bottle;

                pm[37] = new SqlParameter("@SELL_QTY_BOX", SqlDbType.Int);
                pm[37].Value = sell_qty_box;

                pm[38] = new SqlParameter("@REMARK", SqlDbType.VarChar);
                pm[38].Value = remark;

                pm[39] = new SqlParameter("@SHIPPING_TERMS_ID", SqlDbType.Int);
                pm[39].Value = shipping_terms_id;

                CommonDataSet ds = new CommonDataSet();

                return (CommonDataSet)DAOFactory.getInstance().getDatabaseDAO().ExcecuteDataSet(ds,
                    ds.NPD_INSERT_PRODUCT_TEMP.TableName, _NPD_INSERT_PRODUCT_TEMP, pm, strConnCommon);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
