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
        private int speed;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x">x坐标</param>
        /// <param name="y">y坐标</param>
        /// <param name="faction">好坏类别</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="speed">速度</param>
        public Item(int x, int y, bool faction, int width, int height, int speed) :base(x, y)
        {
            this.faction = faction;
            this.width = width;
            this.height = height;
            this.speed = speed;
        }

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        public int WIDTH
        {
            get { return width; }
        }
        public int HEIGHT
        {
            get { return height; }
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
