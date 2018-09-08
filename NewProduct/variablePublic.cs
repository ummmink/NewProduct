using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProduct
{
    class variablePublic
    {
        public static int type_id;
        public static string item_no;
        public static int item_no2;
        public static string productPrefix;
        public static string channel;
        public static int sell_id;
        public static string user_group_id;
        public static string product_other_name;
        public static int product_other_id;
        //Image
        public static string saveImagePath = @"E:\My Work\Programming\progress\NPD\NewProductSystem\NPD_Images";
        public static string imagePath;
        //Price
        public static float productMainPrice; //ราคาสินค้าปกติ
        public static float productFreePrice; //ราคาสินค้าแถม
        public static float productTotalPackPrice; //ราคาแนะนำแพ็ค
        public static float productTotalCasePrice; //ราคาแนะนำลัง
        //Qty
        public static int productMainQty; //จำนวนสินค้าปกติ
        public static int productFreeQty; //จำนวนสินค้าแถม
        public static int productTotalQty; //จำนวนสินค้ารวม
        //Packing
        public static int productBottleQty;
        public static int productPackQty;
        public static int productInnerBoxQty;
        public static int productCaseQty;
    }
}
