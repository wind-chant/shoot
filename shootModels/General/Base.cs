using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shootModels
{
    /// <summary>
    /// 所有物品的基类
    /// </summary>
    public abstract class Base
    {
        // 位置
        private int x;
        private int y;

        // 是否存在
        private bool live;

        public Base(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public bool Live
        {
            get { return live; }
            set { live = value; }
        }

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }

        /// <summary>
        /// 绘图方法
        /// </summary>
        /// <param name="g"></param>
        public abstract void Draw(Graphics g);
    }
}
