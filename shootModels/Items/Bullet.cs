using shootModels.General;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shootModels.Items
{
    /// <summary>
    /// 子弹基类
    /// </summary>
    public abstract class Bullet : Item
    {
        public static BulletDirection[] BulletDirections = new BulletDirection[]
{
            BulletDirection.U,
            BulletDirection.UR,
            BulletDirection.RU,
            BulletDirection.R,
            BulletDirection.RD,
            BulletDirection.DR,
            BulletDirection.D,
            BulletDirection.DL,
            BulletDirection.LD,
            BulletDirection.L,
            BulletDirection.LU,
            BulletDirection.UL
};
        /// <summary>
        /// 攻击力
        /// </summary>
        private int power;
        /// <summary>
        /// 移动方向
        /// </summary>
        private BulletDirection direction;
        private readonly double COS30 = 1.732;
        private readonly double COS60 = 0.577;
        public Bullet(SpaceShip ship, int width, int height, int speed, bool faction, BulletDirection direction, int power) : base(
                    (int)(ship.X + ship.WIDTH / 2 - width / 2),
                    (int)(ship.Y + ship.HEIGHT / 2 - height / 2), faction, width, height, speed)
        {
            this.direction = direction;
            this.power = power;
        }

        public int Power
        {
            get { return power; }
        }
        /// <summary>
        /// 移动
        /// </summary>
        protected override void Move()
        {
            switch (direction)
            {
                case BulletDirection.U:
                    Y -= Speed;
                    break;
                case BulletDirection.UR:
                    X += (int)(COS60 * Speed);
                    Y -= (int)(COS30 * Speed);
                    break;
                case BulletDirection.RU:
                    X += (int)(COS30 * Speed);
                    Y -= (int)(COS60 * Speed);
                    break;
                case BulletDirection.R:
                    X += Speed;
                    break;
                case BulletDirection.RD:
                    X += (int)(COS30 * Speed);
                    Y += (int)(COS60 * Speed);
                    break;
                case BulletDirection.DR:
                    X += (int)(COS60 * Speed);
                    Y += (int)(COS30 * Speed);
                    break;
                case BulletDirection.D:
                    X += Speed;
                    break;
                case BulletDirection.DL:
                    X -= (int)(COS30 * Speed);
                    Y += (int)(COS60 * Speed);
                    break;
                case BulletDirection.LD:
                    X -= (int)(COS60 * Speed);
                    Y += (int)(COS30 * Speed);
                    break;
                case BulletDirection.L:
                    X -= Speed;
                    break;
                case BulletDirection.LU:
                    X -= (int)(COS30 * Speed);
                    Y -= (int)(COS60 * Speed);
                    break;
                case BulletDirection.UL:
                    X -= (int)(COS60 * Speed);
                    Y -= (int)(COS30 * Speed);
                    break;
                default: break;
            }
        }
        /// <summary>
        /// 绘制
        /// </summary>
        /// <param name="g">绘图图面</param>
        /// <param name="images">图片</param>
        /// <param name="x">x坐标</param>
        /// <param name="y">y坐标</param>
        protected void Draw(Graphics g, Dictionary<string, Image> images, int x, int y)
        {
            switch (direction)
            {
                case BulletDirection.U:
                    g.DrawImage(images["U"], x, y);
                    break;
                case BulletDirection.UR:
                    g.DrawImage(images["UR"], x, y);
                    break;
                case BulletDirection.RU:
                    g.DrawImage(images["RU"], x, y);
                    break;
                case BulletDirection.R:
                    g.DrawImage(images["R"], x, y);
                    break;
                case BulletDirection.RD:
                    g.DrawImage(images["RD"], x, y);
                    break;
                case BulletDirection.DR:
                    g.DrawImage(images["DR"], x, y);
                    break;
                case BulletDirection.D:
                    g.DrawImage(images["D"], x, y);
                    break;
                case BulletDirection.DL:
                    g.DrawImage(images["DL"], x, y);
                    break;
                case BulletDirection.LD:
                    g.DrawImage(images["LD"], x, y);
                    break;
                case BulletDirection.L:
                    g.DrawImage(images["L"], x, y);
                    break;
                case BulletDirection.LU:
                    g.DrawImage(images["LU"], x, y);
                    break;
                case BulletDirection.UL:
                    g.DrawImage(images["UL"], x, y);
                    break;
            }
        }
    }
}
