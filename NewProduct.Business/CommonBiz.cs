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
        private CommonData expensesData = new CommonData();

        public CommonDataSet select_category()
        {
            try
            {
                return expensesData.select_product_all_status();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
