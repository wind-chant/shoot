using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shootModels.General
{
    /// <summary>
    /// 物体类, 飞船, 子弹等
    /// </summary>
    public abstract class Item:Base
    {
        // 是否玩家类别
        private bool faction;
        private int width;
        private int height;
        private int x_speed;
        private int y_speed;
        public Item(Point p, bool faction, int width, int height, int x_speed, int y_speed) :base(p)
        {
            this.faction = faction;
            this.width = width;
            this.height = height;
            this.x_speed = x_speed;
            this.y_speed = y_speed;
        }

        public bool Faction
        {
            set { faction = value; }
            get { return faction; }
        }

        /// <summary>
        /// 获取碰撞箱
        /// </summary>
        /// <returns></returns>
        public Rectangle GetRectangle()
        {
            return new Rectangle(X, Y, width, height);
        }

        /// <summary>
        /// 移动方法
        /// </summary>
        protected abstract void Move();
    }
}
