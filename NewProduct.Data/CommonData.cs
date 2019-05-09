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
        private static string _NPD_SELECT_PRODUCT_HAMPER_TEMP_BY_REFERENCE_NO = "npd_select_product_hamper_temp_by_reference_no";
        private static string _NPD_SELECT_PRODUCT_NAME_TH_BY_PRODUCT_ID = "npd_select_product_name_th_by_product_id";
        private static string _NPD_INSERT_PRODUCT_TEMP = "npd_insert_product_temp";
        private static string _NPD_UPDATE_TEMP_STATUS_PRODUCT_TEMP = "npd_update_temp_status_product_temp";
        private static string _NPD_SELECT_PRODUCT_TEMP_BY_FIELDNAME_AND_FIELDVALUE = "npd_select_product_temp_by_fieldname_and_fieldvalue";
        private static string _NPD_SELECT_PRODUCT_TEMP_BY_REFERENCE_NO = "npd_select_product_temp_by_reference_no";
        private static string _NPD_SELECT_PRODUCT_TEMP_BY_PRODUCT_TYPE = "npd_select_product_temp_by_product_type";
        private static string _NPD_SELECT_PRODUCT_TEMP_BY_PRODUCT_NAME_TH_Invoice = "npd_select_product_temp_by_product_name_th_invoice";
        private static string _NPD_SELECT_PRODUCT_TEMP_BY_PRODUCT_NAME_ENG_Invoice = "npd_select_product_temp_by_product_name_eng_invoice";
        private static string _NPD_SELECT_PRODUCT_BY_PRODUCT_ID = "npd_select_product_by_product_id";
        private static string _NPD_SELECT_PRODUCT_BY_PRODUCT_TYPE = "npd_select_product_by_product_type";
        private static string _NPD_SELECT_PRODUCT_BY_PRODUCT_NAME_TH = "npd_select_product_by_product_name_th";
        private static string _NPD_SELECT_PRODUCT_BY_PRODUCT_NAME_ENG = "npd_select_product_by_product_name_eng";
        private static string _NPD_SELECT_ALL_PRODUCT_TEMP_BY_REFERENCE_NO = "npd_select_all_product_temp_by_reference_no";
        private static string _NPD_SELECT_PRODUCT_ITEM_NO2 = "npd_select_product_item_no2";
        private static string _NPD_UPDATE_SHORT_NAME_IN_PRODUCT_TEMP = "npd_update_short_name_in_product_temp";
        private static string _NPD_INSERT_DK_PRODUCT_MAP_TEMP = "npd_insert_dk_product_map_temp";
        private static string _NPD_INSERT_PRODUCT_DIMENSION_TEMP = "npd_insert_product_dimension_temp";
        private static string _NPD_SELECT_ALL_PRODUCT_DIMENSION_TEMP_BY_REFERENCE_NO = "npd_select_all_product_dimension_temp_by_reference_no";
        private static string _NPD_SELECT_ALL_BARCODE_BY_BARCODE = "npd_select_all_barcode_by_barcode";
        private static string _NPD_SELECT_DUPLICATE_BARCODE_BY_BARCODE = "npd_select_duplicate_barcode_by_barcode";
        private static string _NPD_INSERT_PRODUCT_BARCODE_TEMP = "npd_insert_product_barcode_temp";
        private static string _NPD_SELECT_PRODUCT_HAMPER_TEMP_BY_REFERENCE_NO_AND_HAMPER_EXTRA = "npd_select_product_hamper_temp_by_reference_no_and_hamper_extra";
        private static string _NPD_SELECT_ALL_PRODUCT_BARCODE_TEMP_BY_REFERENCE_NO = "npd_select_all_product_barcode_temp_by_reference_no";
        private static string _NPD_SELECT_PRODUCT_ITEM_NO_AND_ITEM_NAME_CODE_BY_TYPE_ID = "npd_select_product_item_no_and_item_name_code_by_type_id";

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

        public CommonDataSet npd_select_product_sell_all_active(bool editpassing)
        {
            try
            {
                SqlParameter[] pm = new SqlParameter[1];

                pm[0] = new SqlParameter("@EDITPASSING", SqlDbType.Bit);
                pm[0].Value = editpassing;

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

        public CommonDataSet npd_select_product_other(bool editpassing)
        {
            try
            {
                SqlParameter[] pm = new SqlParameter[1];

                pm[0] = new SqlParameter("@EDITPASSING", SqlDbType.Bit);
                pm[0].Value = editpassing;

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
            , int sell_qty_bottle, int sell_qty_box, string remark, int shipping_terms_id, bool want_sample
            , string cost_structure_path, string short_name)
        {
            try
            {
                SqlParameter[] pm = new SqlParameter[43];

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

                pm[40] = new SqlParameter("@WANT_SAMPLE", SqlDbType.Bit);
                pm[40].Value = want_sample;

                pm[41] = new SqlParameter("@COST_STRUCTURE_PATH", SqlDbType.VarChar);
                pm[41].Value = cost_structure_path;

                pm[42] = new SqlParameter("@SHORT_NAME", SqlDbType.VarChar);
                pm[42].Value = short_name;

                CommonDataSet ds = new CommonDataSet();

                return (CommonDataSet)DAOFactory.getInstance().getDatabaseDAO().ExcecuteDataSet(ds,
                    ds.NPD_INSERT_PRODUCT_TEMP.TableName, _NPD_INSERT_PRODUCT_TEMP, pm, strConnCommon);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int npd_update_temp_status_product_temp(string reference_no, int temp_status)
        {
            int row = 0;

            try
            {
                SqlParameter[] pm = new SqlParameter[2];

                pm[0] = new SqlParameter("@REFERENCE_NO", SqlDbType.VarChar);
                pm[0].Value = reference_no;

                pm[1] = new SqlParameter("@TEMP_STATUS", SqlDbType.Int);
                pm[1].Value = temp_status;

                row = DAOFactory.getInstance().getDatabaseDAO().NonExcecute(_NPD_UPDATE_TEMP_STATUS_PRODUCT_TEMP, pm,
                    strConnCommon);
                return row;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CommonDataSet npd_select_product_temp_by_fieldname_and_fieldvalue(string fieldname, string fieldvalue)
        {
            try
            {
                SqlParameter[] pm = new SqlParameter[2];

                pm[0] = new SqlParameter("@FIELD_NAME", SqlDbType.VarChar);
                pm[0].Value = fieldname;

                pm[1] = new SqlParameter("@FIELD_VALUE", SqlDbType.VarChar);
                pm[1].Value = fieldvalue;

                CommonDataSet ds = new CommonDataSet();

                return (CommonDataSet)DAOFactory.getInstance().getDatabaseDAO().ExcecuteDataSet(ds,
                    ds.NPD_SELECT_PRODUCT_TEMP_BY_FIELDNAME_AND_FIELDVALUE.TableName, _NPD_SELECT_PRODUCT_TEMP_BY_FIELDNAME_AND_FIELDVALUE, pm, strConnCommon);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CommonDataSet npd_select_product_temp_by_reference_no(string reference_no)
        {
            try
            {
                SqlParameter[] pm = new SqlParameter[1];

                pm[0] = new SqlParameter("@REFERENCE_NO", SqlDbType.VarChar);
                pm[0].Value = reference_no;

                CommonDataSet ds = new CommonDataSet();

                return (CommonDataSet)DAOFactory.getInstance().getDatabaseDAO().ExcecuteDataSet(ds,
                    ds.NPD_SELECT_PRODUCT_TEMP_BY_REFERENCE_NO.TableName, _NPD_SELECT_PRODUCT_TEMP_BY_REFERENCE_NO, pm, strConnCommon);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CommonDataSet npd_select_product_temp_by_product_type(string type_desc_eng)
        {
            try
            {
                SqlParameter[] pm = new SqlParameter[1];

                pm[0] = new SqlParameter("@TYPE_DESC_ENG", SqlDbType.VarChar);
                pm[0].Value = type_desc_eng;

                CommonDataSet ds = new CommonDataSet();

                return (CommonDataSet)DAOFactory.getInstance().getDatabaseDAO().ExcecuteDataSet(ds,
                    ds.NPD_SELECT_PRODUCT_TEMP_BY_PRODUCT_TYPE.TableName, _NPD_SELECT_PRODUCT_TEMP_BY_PRODUCT_TYPE, pm, strConnCommon);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CommonDataSet npd_select_product_temp_by_product_name_th_invoice(string product_name_th_invoice)
        {
            try
            {
                SqlParameter[] pm = new SqlParameter[1];

                pm[0] = new SqlParameter("@PRODUCT_NAME_TH_INVOICE", SqlDbType.VarChar);
                pm[0].Value = product_name_th_invoice;

                CommonDataSet ds = new CommonDataSet();

                return (CommonDataSet)DAOFactory.getInstance().getDatabaseDAO().ExcecuteDataSet(ds,
                    ds.NPD_SELECT_PRODUCT_TEMP_BY_PRODUCT_NAME_TH_Invoice.TableName, _NPD_SELECT_PRODUCT_TEMP_BY_PRODUCT_NAME_TH_Invoice, pm, strConnCommon);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CommonDataSet npd_select_product_temp_by_product_name_eng_invoice(string product_name_eng_invoice)
        {
            try
            {
                SqlParameter[] pm = new SqlParameter[1];

                pm[0] = new SqlParameter("@PRODUCT_NAME_ENG_INVOICE", SqlDbType.VarChar);
                pm[0].Value = product_name_eng_invoice;

                CommonDataSet ds = new CommonDataSet();

                return (CommonDataSet)DAOFactory.getInstance().getDatabaseDAO().ExcecuteDataSet(ds,
                    ds.NPD_SELECT_PRODUCT_TEMP_BY_PRODUCT_NAME_ENG_Invoice.TableName, _NPD_SELECT_PRODUCT_TEMP_BY_PRODUCT_NAME_ENG_Invoice, pm, strConnCommon);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CommonDataSet npd_select_product_by_product_id(string product_id)
        {
            try
            {
                SqlParameter[] pm = new SqlParameter[1];

                pm[0] = new SqlParameter("@PRODUCT_ID", SqlDbType.VarChar);
                pm[0].Value = product_id;

                CommonDataSet ds = new CommonDataSet();

                return (CommonDataSet)DAOFactory.getInstance().getDatabaseDAO().ExcecuteDataSet(ds,
                    ds.NPD_SELECT_PRODUCT_BY_PRODUCT_ID.TableName, _NPD_SELECT_PRODUCT_BY_PRODUCT_ID, pm, strConnCommon);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CommonDataSet npd_select_product_by_product_type(string type_desc_eng)
        {
            try
            {
                SqlParameter[] pm = new SqlParameter[1];

                pm[0] = new SqlParameter("@TYPE_DESC_ENG", SqlDbType.VarChar);
                pm[0].Value = type_desc_eng;

                CommonDataSet ds = new CommonDataSet();

                return (CommonDataSet)DAOFactory.getInstance().getDatabaseDAO().ExcecuteDataSet(ds,
                    ds.NPD_SELECT_PRODUCT_BY_PRODUCT_TYPE.TableName, _NPD_SELECT_PRODUCT_BY_PRODUCT_TYPE, pm, strConnCommon);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CommonDataSet npd_select_product_by_product_name_th(string product_name_th)
        {
            try
            {
                SqlParameter[] pm = new SqlParameter[1];

                pm[0] = new SqlParameter("@PRODUCT_NAME_TH", SqlDbType.VarChar);
                pm[0].Value = product_name_th;

                CommonDataSet ds = new CommonDataSet();

                return (CommonDataSet)DAOFactory.getInstance().getDatabaseDAO().ExcecuteDataSet(ds,
                    ds.NPD_SELECT_PRODUCT_BY_PRODUCT_NAME_TH.TableName, _NPD_SELECT_PRODUCT_BY_PRODUCT_NAME_TH, pm, strConnCommon);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CommonDataSet npd_select_product_by_product_name_eng(string product_name_eng)
        {
            try
            {
                SqlParameter[] pm = new SqlParameter[1];

                pm[0] = new SqlParameter("@PRODUCT_NAME_ENG", SqlDbType.VarChar);
                pm[0].Value = product_name_eng;

                CommonDataSet ds = new CommonDataSet();

                return (CommonDataSet)DAOFactory.getInstance().getDatabaseDAO().ExcecuteDataSet(ds,
                    ds.NPD_SELECT_PRODUCT_BY_PRODUCT_NAME_ENG.TableName, _NPD_SELECT_PRODUCT_BY_PRODUCT_NAME_ENG, pm, strConnCommon);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CommonDataSet npd_select_all_product_temp_by_reference_no(string reference_no)
        {
            try
            {
                SqlParameter[] pm = new SqlParameter[1];

                pm[0] = new SqlParameter("@REFERENCE_NO", SqlDbType.VarChar);
                pm[0].Value = reference_no;

                CommonDataSet ds = new CommonDataSet();

                return (CommonDataSet)DAOFactory.getInstance().getDatabaseDAO().ExcecuteDataSet(ds,
                    ds.NPD_SELECT_ALL_PRODUCT_TEMP_BY_REFERENCE_NO.TableName, _NPD_SELECT_ALL_PRODUCT_TEMP_BY_REFERENCE_NO, pm, strConnCommon);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CommonDataSet npd_select_product_item_no2()
        {
            try
            {
                SqlParameter[] pm = null;

                CommonDataSet ds = new CommonDataSet();

                return (CommonDataSet)DAOFactory.getInstance().getDatabaseDAO().ExcecuteDataSet(ds,
                    ds.NPD_SELECT_PRODUCT_ITEM_NO2.TableName, _NPD_SELECT_PRODUCT_ITEM_NO2, pm, strConnCommon);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int npd_update_short_name_in_product_temp(string reference_no, string short_name)
        {
            int row = 0;

            try
            {
                SqlParameter[] pm = new SqlParameter[2];

                pm[0] = new SqlParameter("@REFERENCE_NO", SqlDbType.VarChar);
                pm[0].Value = reference_no;

                pm[1] = new SqlParameter("@SHORT_NAME", SqlDbType.VarChar);
                pm[1].Value = short_name;

                row = DAOFactory.getInstance().getDatabaseDAO().NonExcecute(_NPD_UPDATE_SHORT_NAME_IN_PRODUCT_TEMP, pm,
                    strConnCommon);
                return row;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CommonDataSet npd_insert_dk_product_map_temp(string reference_no, string mat_code, string product_id)
        {
            try
            {
                SqlParameter[] pm = new SqlParameter[3];

                pm[0] = new SqlParameter("@REFERENCE_NO", SqlDbType.VarChar);
                pm[0].Value = reference_no;

                pm[1] = new SqlParameter("@MAT_CODE", SqlDbType.VarChar);
                pm[1].Value = mat_code;

                pm[2] = new SqlParameter("@PRODUCT_ID", SqlDbType.VarChar);
                pm[2].Value = product_id;

                CommonDataSet ds = new CommonDataSet();

                return (CommonDataSet)DAOFactory.getInstance().getDatabaseDAO().ExcecuteDataSet(ds,
                    ds.NPD_INSERT_DK_PRODUCT_MAP_TEMP.TableName, _NPD_INSERT_DK_PRODUCT_MAP_TEMP, pm, strConnCommon);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CommonDataSet npd_insert_product_dimension_temp(string reference_no, string product_id, decimal bottle_width, decimal bottle_length, decimal bottle_height,
            decimal pack_width, decimal pack_length, decimal pack_height, decimal inner_width, decimal inner_length,
            decimal inner_height, decimal case_width, decimal case_length, decimal case_height, decimal bottle_netweight,
            decimal bottle_grossweight, decimal pack_netweight, decimal pack_grossweight, decimal inner_netweight, decimal inner_grossweight,
            decimal case_netweight, decimal case_grossweight, string short_name_factory, string packaging, string techprint_create_date,
            string print_area, string barcode_area, string arranging, string arranging_pallet, string capacity,
            string pack_production_by, string inner_production_by, string case_production_by, string other_production_by, string other)
        {
            try
            {
                SqlParameter[] pm = new SqlParameter[35];

                pm[0] = new SqlParameter("@REFERENCE_NO", SqlDbType.VarChar);
                pm[0].Value = reference_no;

                pm[1] = new SqlParameter("@PRODUCT_ID", SqlDbType.VarChar);
                pm[1].Value = product_id;

                pm[2] = new SqlParameter("@BOTTLE_WIDTH", SqlDbType.Decimal);
                pm[2].Value = bottle_width;

                pm[3] = new SqlParameter("@BOTTLE_LENGTH", SqlDbType.Decimal);
                pm[3].Value = bottle_length;

                pm[4] = new SqlParameter("@BOTTLE_HEIGHT", SqlDbType.Decimal);
                pm[4].Value = bottle_height;

                pm[5] = new SqlParameter("@PACK_WIDTH", SqlDbType.Decimal);
                pm[5].Value = pack_width;

                pm[6] = new SqlParameter("@PACK_LENGTH", SqlDbType.Decimal);
                pm[6].Value = pack_length;

                pm[7] = new SqlParameter("@PACK_HEIGHT", SqlDbType.Decimal);
                pm[7].Value = pack_height;

                pm[8] = new SqlParameter("@INNER_WIDTH", SqlDbType.Decimal);
                pm[8].Value = inner_width;

                pm[9] = new SqlParameter("@INNER_LENGTH", SqlDbType.Decimal);
                pm[9].Value = inner_length;

                pm[10] = new SqlParameter("@INNER_HEIGHT", SqlDbType.Decimal);
                pm[10].Value = inner_height;

                pm[11] = new SqlParameter("@CASE_WIDTH", SqlDbType.Decimal);
                pm[11].Value = case_width;

                pm[12] = new SqlParameter("@CASE_LENGTH", SqlDbType.Decimal);
                pm[12].Value = case_length;

                pm[13] = new SqlParameter("@CASE_HEIGHT", SqlDbType.Decimal);
                pm[13].Value = case_height;

                pm[14] = new SqlParameter("@BOTTLE_NETWEIGHT", SqlDbType.Decimal);
                pm[14].Value = bottle_netweight;

                pm[15] = new SqlParameter("@BOTTLE_GROSSWEIGHT", SqlDbType.Decimal);
                pm[15].Value = bottle_grossweight;

                pm[16] = new SqlParameter("@PACK_NETWEIGHT", SqlDbType.Decimal);
                pm[16].Value = pack_netweight;

                pm[17] = new SqlParameter("@PACK_GROSSWEIGHT", SqlDbType.Decimal);
                pm[17].Value = pack_grossweight;

                pm[18] = new SqlParameter("@INNER_NETWEIGHT", SqlDbType.Decimal);
                pm[18].Value = inner_netweight;

                pm[19] = new SqlParameter("@INNER_GROSSWEIGHT", SqlDbType.Decimal);
                pm[19].Value = inner_grossweight;

                pm[20] = new SqlParameter("@CASE_NETWEIGHT", SqlDbType.Decimal);
                pm[20].Value = case_netweight;

                pm[21] = new SqlParameter("@CASE_GROSSWEIGHT", SqlDbType.Decimal);
                pm[21].Value = case_grossweight;

                pm[22] = new SqlParameter("@SHORT_NAME_FACTORY", SqlDbType.VarChar);
                pm[22].Value = short_name_factory;

                pm[23] = new SqlParameter("@PACKAGING", SqlDbType.VarChar);
                pm[23].Value = packaging;

                pm[24] = new SqlParameter("@TECHPRINT_CREATE_DATE", SqlDbType.VarChar);
                pm[24].Value = techprint_create_date;

                pm[25] = new SqlParameter("@PRINT_AREA", SqlDbType.VarChar);
                pm[25].Value = print_area;

                pm[26] = new SqlParameter("@BARCODE_AREA", SqlDbType.VarChar);
                pm[26].Value = barcode_area;

                pm[27] = new SqlParameter("@ARRANGING", SqlDbType.VarChar);
                pm[27].Value = arranging;

                pm[28] = new SqlParameter("@ARRANGING_PALLET", SqlDbType.VarChar);
                pm[28].Value = arranging_pallet;

                pm[29] = new SqlParameter("@CAPACITY", SqlDbType.VarChar);
                pm[29].Value = capacity;

                pm[30] = new SqlParameter("@PACK_PRODUCTION_BY", SqlDbType.VarChar);
                pm[30].Value = pack_production_by;

                pm[31] = new SqlParameter("@INNER_PRODUCTION_BY", SqlDbType.VarChar);
                pm[31].Value = inner_production_by;

                pm[32] = new SqlParameter("@CASE_PRODUCTION_BY", SqlDbType.VarChar);
                pm[32].Value = case_production_by;

                pm[33] = new SqlParameter("@OTHER_PRODUCTION_BY", SqlDbType.VarChar);
                pm[33].Value = other_production_by;

                pm[34] = new SqlParameter("@OTHER", SqlDbType.VarChar);
                pm[34].Value = other;

                CommonDataSet ds = new CommonDataSet();

                return (CommonDataSet)DAOFactory.getInstance().getDatabaseDAO().ExcecuteDataSet(ds,
                    ds.NPD_INSERT_PRODUCT_DIMENSION_TEMP.TableName, _NPD_INSERT_PRODUCT_DIMENSION_TEMP, pm, strConnCommon);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CommonDataSet npd_select_all_product_dimension_temp_by_reference_no(string reference_no)
        {
            try
            {
                SqlParameter[] pm = new SqlParameter[1];

                pm[0] = new SqlParameter("@REFERENCE_NO", SqlDbType.VarChar);
                pm[0].Value = reference_no;

                CommonDataSet ds = new CommonDataSet();

                return (CommonDataSet)DAOFactory.getInstance().getDatabaseDAO().ExcecuteDataSet(ds,
                    ds.NPD_SELECT_ALL_PRODUCT_DIMENSION_TEMP_BY_REFERENCE_NO.TableName, _NPD_SELECT_ALL_PRODUCT_DIMENSION_TEMP_BY_REFERENCE_NO, pm, strConnCommon);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CommonDataSet npd_select_all_barcode_by_barcode(string barcode, string unit)
        {
            try
            {
                SqlParameter[] pm = new SqlParameter[2];

                pm[0] = new SqlParameter("@BARCODE", SqlDbType.VarChar);
                pm[0].Value = barcode;

                pm[1] = new SqlParameter("@UNIT", SqlDbType.VarChar);
                pm[1].Value = unit;

                CommonDataSet ds = new CommonDataSet();

                return (CommonDataSet)DAOFactory.getInstance().getDatabaseDAO().ExcecuteDataSet(ds,
                    ds.NPD_SELECT_ALL_BARCODE_BY_BARCODE.TableName, _NPD_SELECT_ALL_BARCODE_BY_BARCODE, pm, strConnCommon);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CommonDataSet npd_select_duplicate_barcode_by_barcode(string barcode_box, string barcode_subbox, string barcode_pack, string barcode_bottle)
        {
            try
            {
                SqlParameter[] pm = new SqlParameter[4];

                pm[0] = new SqlParameter("@BARCODE_BOX", SqlDbType.VarChar);
                pm[0].Value = barcode_box;

                pm[1] = new SqlParameter("@BARCODE_SUBBOX", SqlDbType.VarChar);
                pm[1].Value = barcode_subbox;

                pm[2] = new SqlParameter("@BARCODE_PACK", SqlDbType.VarChar);
                pm[2].Value = barcode_pack;

                pm[3] = new SqlParameter("@BARCODE_BOTTLE", SqlDbType.VarChar);
                pm[3].Value = barcode_bottle;

                CommonDataSet ds = new CommonDataSet();

                return (CommonDataSet)DAOFactory.getInstance().getDatabaseDAO().ExcecuteDataSet(ds,
                    ds.NPD_SELECT_DUPLICATE_BARCODE_BY_BARCODE.TableName, _NPD_SELECT_DUPLICATE_BARCODE_BY_BARCODE, pm, strConnCommon);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CommonDataSet npd_insert_product_barcode_temp(string reference_no, string product_id, string barcode_box
            , string barcode_subbox, string barcode_pack, string barcode_bottle, string remark, string emp_create)
        {
            try
            {
                SqlParameter[] pm = new SqlParameter[8];

                pm[0] = new SqlParameter("@REFERENCE_NO", SqlDbType.VarChar);
                pm[0].Value = reference_no;

                pm[1] = new SqlParameter("@PRODUCT_ID", SqlDbType.VarChar);
                pm[1].Value = product_id;

                pm[2] = new SqlParameter("@BARCODE_BOX", SqlDbType.VarChar);
                pm[2].Value = barcode_box;

                pm[3] = new SqlParameter("@BARCODE_SUBBOX", SqlDbType.VarChar);
                pm[3].Value = barcode_subbox;

                pm[4] = new SqlParameter("@BARCODE_PACK", SqlDbType.VarChar);
                pm[4].Value = barcode_pack;

                pm[5] = new SqlParameter("@BARCODE_BOTTLE", SqlDbType.VarChar);
                pm[5].Value = barcode_bottle;

                pm[6] = new SqlParameter("@REMARK", SqlDbType.VarChar);
                pm[6].Value = remark;

                pm[7] = new SqlParameter("@EMP_CREATE", SqlDbType.VarChar);
                pm[7].Value = emp_create;

                CommonDataSet ds = new CommonDataSet();

                return (CommonDataSet)DAOFactory.getInstance().getDatabaseDAO().ExcecuteDataSet(ds,
                    ds.NPD_INSERT_PRODUCT_BARCODE_TEMP.TableName, _NPD_INSERT_PRODUCT_BARCODE_TEMP, pm, strConnCommon);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CommonDataSet npd_select_product_hamper_temp_by_reference_no_and_hamper_extra(string reference_no, int hamper_extra)
        {
            try
            {
                SqlParameter[] pm = new SqlParameter[2];

                pm[0] = new SqlParameter("@REFERENCE_NO", SqlDbType.VarChar);
                pm[0].Value = reference_no;

                pm[1] = new SqlParameter("@HAMPER_EXTRA", SqlDbType.Int);
                pm[1].Value = hamper_extra;

                CommonDataSet ds = new CommonDataSet();

                return (CommonDataSet)DAOFactory.getInstance().getDatabaseDAO().ExcecuteDataSet(ds,
                    ds.NPD_SELECT_PRODUCT_HAMPER_TEMP_BY_REFERENCE_NO_AND_HAMPER_EXTRA.TableName, _NPD_SELECT_PRODUCT_HAMPER_TEMP_BY_REFERENCE_NO_AND_HAMPER_EXTRA, pm, strConnCommon);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CommonDataSet npd_select_all_product_barcode_temp_by_reference_no(string reference_no)
        {
            try
            {
                SqlParameter[] pm = new SqlParameter[1];

                pm[0] = new SqlParameter("@REFERENCE_NO", SqlDbType.VarChar);
                pm[0].Value = reference_no;

                CommonDataSet ds = new CommonDataSet();

                return (CommonDataSet)DAOFactory.getInstance().getDatabaseDAO().ExcecuteDataSet(ds,
                    ds.NPD_SELECT_ALL_PRODUCT_BARCODE_TEMP_BY_REFERENCE_NO.TableName, _NPD_SELECT_ALL_PRODUCT_BARCODE_TEMP_BY_REFERENCE_NO, pm, strConnCommon);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CommonDataSet npd_select_product_item_no_and_item_name_code_by_type_id(int type_id, int id)
        {
            try
            {
                SqlParameter[] pm = new SqlParameter[2];

                pm[0] = new SqlParameter("@TYPE_ID", SqlDbType.Int);
                pm[0].Value = type_id;

                pm[1] = new SqlParameter("@ID", SqlDbType.Int);
                pm[1].Value = id;

                CommonDataSet ds = new CommonDataSet();

                return (CommonDataSet)DAOFactory.getInstance().getDatabaseDAO().ExcecuteDataSet(ds,
                    ds.NPD_SELECT_PRODUCT_ITEM_NO_AND_ITEM_NAME_CODE_BY_TYPE_ID.TableName, _NPD_SELECT_PRODUCT_ITEM_NO_AND_ITEM_NAME_CODE_BY_TYPE_ID, pm, strConnCommon);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
