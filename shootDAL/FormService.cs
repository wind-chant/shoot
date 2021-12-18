using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shootDAL
{
    public class FormService
    {
        /// <summary>
        /// 窗口宽度
        /// </summary>
        public static int getWidth()
        {
            return int.Parse(ConfigurationManager.AppSettings["width"].ToString());
        }
        /// <summary>
        /// 窗口高度
        /// </summary>
        public static int getHeight()
        {
            return int.Parse(ConfigurationManager.AppSettings["height"].ToString());
        }
    }
}
