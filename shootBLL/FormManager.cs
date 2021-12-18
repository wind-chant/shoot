using shootDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shootBLL
{
    public class FormManager
    {
        private FormService fs = new FormService();
        /// <summary>
        /// 窗口宽度
        /// </summary>
        public static int getWidth()
        {
            return FormService.getWidth();
        }
        /// <summary>
        /// 窗口高度
        /// </summary>
        public static int getHeight()
        {
            return FormService.getHeight();
        }
    }
}
