using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shootModels.Items
{
    [Serializable]
    /// <summary>
    /// 血条类
    /// </summary>
    public class BlooBar : Base
    {
        /// <summary>
        /// 血条单位宽度
        /// </summary>
        private readonly int width = int.Parse(UpdateManager.getAtt("BlooBarWidth"));
        /// <summary>
        /// 血条高度
        /// </summary>
        private readonly int height = int.Parse(UpdateManager.getAtt("BlooBarHeight"));
        /// <summary>
        /// 所有生命值
        /// </summary>
        private int allLife;
        public int AllLife
        {
            get { return allLife; }
        }
        /// <summary>
        /// 当前生命值
        /// </summary>
        private int nowLife;
        /// <summary>
        /// 飞船宽度/2
        /// </summary>
        private int shipWidth;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="x">x坐标</param>
        /// <param name="y">y坐标</param>
        /// <param name="life">生命值</param>
        public BlooBar(int x, int y, int life, int shipWidth) : base(x, y)
        {
            allLife = life;
            nowLife = life;
            this.shipWidth = shipWidth/2;
        }

        public int NowLife
        {
            get { return nowLife; }
            set { nowLife = value; }
        }

        public override void Draw(Graphics g)
        {
            int nx = X + shipWidth;
            int ny = Y - 18;
            g.DrawString("HP:", new Font("Arial", 10f), new SolidBrush(Color.Red), nx - width * allLife / 2 - 20, ny);
            g.DrawRectangle(new Pen(Color.Red ), nx - width * allLife / 2 + 5, ny, width * allLife, height);
            g.FillRectangle(new SolidBrush(Color.Green), nx - width * allLife / 2 + 6, ny+1, width * nowLife-1, height-1);
        }
    }
}
