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
    }
}
