using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shootModels.Items
{
    /// <summary>
    /// 血条类
    /// </summary>
    public class BlooBar : Base
    {
        /// <summary>
        /// 血条单位宽度
        /// </summary>
        private readonly int width = 1;
        /// <summary>
        /// 血条高度
        /// </summary>
        private readonly int height = 10;
        /// <summary>
        /// 所有生命值
        /// </summary>
        private int allLife;
        /// <summary>
        /// 当前生命值
        /// </summary>
        private int nowLife;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="x">x坐标</param>
        /// <param name="y">y坐标</param>
        /// <param name="life">生命值</param>
        public BlooBar(int x, int y, int life) : base(x, y)
        {
            allLife = life;
            nowLife = life;
        }

        public new int X
        {
            get { return X; }
            set { X = value; }
        }
        public new int Y
        {
            get { return Y; }
            set { Y = value; }
        }
        public int NowLife
        {
            get { return NowLife; }
            set { NowLife = value; }
        }

        public override void Draw(Graphics g)
        {
            g.DrawString("生命值:", new Font("Arial", 10f), new SolidBrush(Color.Black), X + 50, Y - 20);
            g.DrawRectangle(new Pen(Color.Red), X + 85, Y - 18, width * allLife, height);
            g.FillRectangle(new SolidBrush(Color.Red), X + 85, Y - 18, width * nowLife, height);
        }
    }
}
