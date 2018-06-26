using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProduct.Utility
{
    public class ConvertUtil
    {
        public ConvertUtil()
        {

        }

        public static Int16 parseSmallInt(Object str)
        {
            return parseSmallInt(str, 0);
        }

        public static Int16 parseSmallInt(Object str, Int16 defaultValue)
        {
            if ((str == null) || (parseString(str).Equals(String.Empty)))
                return defaultValue;
            else
                return Int16.Parse(str.ToString());
        }

        public static Int32 parseInt(Object str)
        {
            return parseInt(str, 0);
        }

        public static Int32 parseInt(Object str, int defaultValue)
        {
            if ((str == null) || (parseString(str).Equals(String.Empty)))
                return defaultValue;
            else
                return Int32.Parse(str.ToString());
        }

        public static Int64 parseLong(Object str)
        {
            return parseLong(str, 0);
        }

        public static Int64 parseLong(Object str, int defaultValue)
        {
            if ((str == null) || (parseString(str).Equals(String.Empty)))
                return defaultValue;
            else
                return Int64.Parse(str.ToString());
        }

        public static Double parseDouble(Object str)
        {
            return parseDouble(str, 0.0);
        }

        public static Double parseDouble(Object str, double defaultValue)
        {
            if ((str == null) || (parseString(str).Equals(String.Empty)))
                return defaultValue;
            else
            {
                try
                {
                    return Double.Parse(str.ToString());
                }
                catch
                {
                    return 0;
                }

            }
        }

        public static Decimal parseDecimal(Object str)
        {
            return parseDecimal(str, 0);
        }

        public static Decimal parseDecimal(Object str, decimal defaultValue)
        {
            if ((str == null) || (parseString(str).Equals(String.Empty)))
                return defaultValue;
            else
            {
                try
                {
                    return Decimal.Parse(str.ToString());
                }
                catch
                {
                    return 0;
                }
                
            }
        }

        public static String parseString(Object str)
        {
            return parseString(str, String.Empty);
        }

        public static String parseString(Object str, String defaultValue)
        {
            if (str == null)
                return defaultValue;
            if (str.Equals(String.Empty))
                return defaultValue;
            else
                return str.ToString().Trim();
        }

        public static DateTime parseDateTime(Object str)
        {
            DateTime date = new DateTime(1000, 10, 10, 10, 10, 10);
            return parseDateTime(str, date);
        }

        public static DateTime parseDateTime(Object str, DateTime defaultValue)
        {
            if ((str == null) || (parseString(str).Equals(String.Empty)))
                return defaultValue;
            else
                return DateTime.Parse(str.ToString());
        }

        public static string parseDateTimeToEng(Object data, string format)
        {
            StringBuilder strDate = new StringBuilder();

            if (data != null && !parseString(data).Equals(String.Empty))
            {
                DateTime defaultValue = ConvertUtil.parseDateTime(data);
                int year = defaultValue.Date.Year;
                if (year > 2500)
                {
                    year = year - 543;
                }
                else if (year < 2000)
                {
                    year = year + 543;
                }

                if (format.Equals("dd/MM/yyyy"))
                {
                    strDate.Append((defaultValue.Day.ToString().Length < 2) ? "0" + defaultValue.Day.ToString() : defaultValue.Day.ToString()).Append("/").Append((defaultValue.Month.ToString().Length < 2) ? "0" + defaultValue.Month.ToString() : defaultValue.Month.ToString());
                    strDate.Append("/").Append(year);
                }
                else if (format.Equals("dd/MM/yyyy HH:mm:ss"))
                {
                    strDate.Append((defaultValue.Day.ToString().Length < 2) ? "0" + defaultValue.Day.ToString() : defaultValue.Day.ToString()).Append("/").Append((defaultValue.Month.ToString().Length < 2) ? "0" + defaultValue.Month.ToString() : defaultValue.Month.ToString());
                    strDate.Append("/").Append(year).Append(" ");
                    strDate.Append((defaultValue.Hour.ToString().Length < 2) ? "0" + defaultValue.Hour.ToString() : defaultValue.Hour.ToString()).Append(":").Append((defaultValue.Minute.ToString().Length < 2) ? "0" + defaultValue.Minute.ToString() : defaultValue.Minute.ToString());
                    strDate.Append(":").Append((defaultValue.Second.ToString().Length < 2) ? "0" + defaultValue.Second.ToString() : defaultValue.Second.ToString());
                }
            }
            return strDate.ToString();
        }

        public static string parseDateTimeToThai(Object data, string format)
        {
            StringBuilder strDate = new StringBuilder();

            if (data != null && !parseString(data).Equals(String.Empty))
            {
                DateTime defaultValue = ConvertUtil.parseDateTime(data);
                int year = defaultValue.Date.Year;
                if (year < 2500)
                {
                    year = year + 543;
                }
                if (year > 3000)
                {
                    year = year - 543;
                }
                if (format.Equals("dd/MM/yyyy"))
                {
                    strDate.Append((defaultValue.Day.ToString().Length < 2) ? "0" + defaultValue.Day.ToString() : defaultValue.Day.ToString()).Append("/").Append((defaultValue.Month.ToString().Length < 2) ? "0" + defaultValue.Month.ToString() : defaultValue.Month.ToString());
                    strDate.Append("/").Append(year);
                }
                else if (format.Equals("dd/MM/yyyy HH:mm:ss"))
                {
                    strDate.Append((defaultValue.Day.ToString().Length < 2) ? "0" + defaultValue.Day.ToString() : defaultValue.Day.ToString()).Append("/").Append((defaultValue.Month.ToString().Length < 2) ? "0" + defaultValue.Month.ToString() : defaultValue.Month.ToString());
                    strDate.Append("/").Append(year).Append(" ");
                    strDate.Append((defaultValue.Hour.ToString().Length < 2) ? "0" + defaultValue.Hour.ToString() : defaultValue.Hour.ToString()).Append(":").Append((defaultValue.Minute.ToString().Length < 2) ? "0" + defaultValue.Minute.ToString() : defaultValue.Minute.ToString());
                    strDate.Append(":").Append((defaultValue.Second.ToString().Length < 2) ? "0" + defaultValue.Second.ToString() : defaultValue.Second.ToString());
                }
            }
            return strDate.ToString();
        }

        public static Boolean parseBoolean(Object str)
        {
            return parseBoolean(str, false);
        }

        public static Boolean parseBoolean(Object str, Boolean defaultValue)
        {
            if ((str == null) || (parseString(str).Equals(String.Empty)))
                return defaultValue;
            else
                return Boolean.Parse(str.ToString());
        }

        public static float parseFloat(Object str)
        {
            return parseFloat(str, 0);
        }

        public static float parseFloat(Object str, float defaultValue)
        {
            if ((str == null) || (parseString(str).Equals(String.Empty)))
                return defaultValue;
            else
            {
                try
                {
                    return float.Parse(str.ToString());
                }
                catch
                {
                    return 0;
                }
            }
        }

        public static string iso8859_unicode(string src)
        {
            Encoding iso = Encoding.GetEncoding("iso8859-1");
            Encoding unicode = Encoding.UTF8;
            byte[] isoBytes = iso.GetBytes(src);
            return unicode.GetString(isoBytes);
        }

    }
}
