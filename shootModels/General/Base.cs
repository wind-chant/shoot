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
        private Point location;
        
        // 是否存在
        private bool live;

        public Base(Point p)
        {
            this.location = p;
        }

        public bool Live
        {
            get { return live; }
            set { live = value; }
        }

        public int X
        {
            get { return location.X; }
        }

        public int Y
        {
            get { return location.Y; }
        }

        /// <summary>
        /// 绘图方法
        /// </summary>
        /// <param name="g"></param>
        public abstract void Draw(Graphics g);
    }
}
