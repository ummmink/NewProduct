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

        public CommonDataSet npd_select_product_sell_all_active()
        {
            try
            {
                return commonData.npd_select_product_sell_all_active();
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
    }
}
