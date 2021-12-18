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
        /// <summary>
        /// 位置
        /// </summary>
        private int x, y;

        /// <summary>
        /// 是否存在
        /// </summary>
        private bool live;

        public Base(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.Live = true;
        }

        public bool Live
        {
            get { return live; }
            set { live = value; }
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        /// <summary>
        /// 绘图方法
        /// </summary>
        /// <param name="g"></param>
        public abstract void Draw(Graphics g);
    }
}
