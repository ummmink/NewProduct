using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NewProduct.Data;
using NewProduct.Entity;

namespace NewProduct.Business
{
    public class CommonBiz
    {
        private CommonData commonData = new CommonData();

        public CommonDataSet select_product_all_status()
        {
            try
            {
                return commonData.select_product_all_status();
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
                return commonData.npd_select_product_item_no_desc_item_name_code_by_type_id(type_id);
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
                return commonData.npd_select_product_type();
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
                return commonData.npd_select_product_sell_all_active(editpassing);
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
                return commonData.npd_select_product_department_role_by_user_group_id(user_group_id);
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
                return commonData.npd_select_main_product();
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
                return commonData.npd_select_product_other();
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
                return commonData.npd_insert_product_hamper_temp(reference_no, product_id, product_sub_id,
                    quantity, hamper_extra, price);
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
                return commonData.npd_delete_all_product_hamper_temp_by_reference_no(reference_no);
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
                return commonData.npd_select_product_hamper_temp_by_reference_no(reference_no);
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
                return commonData.npd_select_product_name_th_by_product_id(product_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CommonDataSet npd_insert_product_temp(string reference_no, string product_id, string nickname, string item_no
            , int type_id, string product_name_th, string product_unit, string product_name_eng, int packing, int bottle, float size
            , DateTime sell_date, int inner_box, int free, string user_create, string item_no2, string product_name_eng_invoice
            , string product_name_th_invoice, string decorated_area1, string decorated_area2, string decorated_area3
            , string decoration_other_details, string decoration_remarkable_of_box, string decoration1, string decoration2
            , string decoration3, string image_path, int other_id, float price_per_case, float price_recommend, string product_prefix
            , DateTime sample_date, int sample_qty_bottle, int sample_qty_box, string schedule, int sell_id, int sell_qty_bottle
            , int sell_qty_box, string remark, int shipping_terms_id, bool want_sample)
        {
            try
            {
                return commonData.npd_insert_product_temp(reference_no, product_id, nickname, item_no, type_id, product_name_th
                    , product_unit, product_name_eng, packing, bottle, size, sell_date, inner_box, free, user_create, item_no2
                    , product_name_eng_invoice, product_name_th_invoice, decorated_area1, decorated_area2, decorated_area3
                    , decoration_other_details, decoration_remarkable_of_box, decoration1, decoration2, decoration3, image_path
                    , other_id, price_per_case, price_recommend, product_prefix, sample_date, sample_qty_bottle, sample_qty_box
                    , schedule, sell_id, sell_qty_bottle, sell_qty_box, remark, shipping_terms_id, want_sample);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int npd_update_temp_status_product_temp(string reference_no, int temp_status)
        {
            try
            {
                return commonData.npd_update_temp_status_product_temp(reference_no, temp_status);
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
                return commonData.npd_select_product_temp_by_fieldname_and_fieldvalue(fieldname, fieldvalue);
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
                return commonData.npd_select_product_temp_by_reference_no(reference_no);
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
                return commonData.npd_select_product_temp_by_product_type(type_desc_eng);
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
                return commonData.npd_select_product_temp_by_product_name_th_invoice(product_name_th_invoice);
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
                return commonData.npd_select_product_temp_by_product_name_eng_invoice(product_name_eng_invoice);
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
                return commonData.npd_select_product_by_product_id(product_id);
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
                return commonData.npd_select_product_by_product_type (type_desc_eng);
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
                return commonData.npd_select_product_by_product_name_th(product_name_th);
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
                return commonData.npd_select_product_by_product_name_eng(product_name_eng);
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
                return commonData.npd_select_all_product_temp_by_reference_no(reference_no);
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
                return commonData.npd_select_product_item_no2();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int npd_update_short_name_in_product_temp(string reference_no, string short_name)
        {
            try
            {
                return commonData.npd_update_short_name_in_product_temp(reference_no, short_name);
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
                return commonData.npd_insert_dk_product_map_temp(reference_no, mat_code, product_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
