using shootModels.General;
using shootModels.Items;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shootModels
{
    [Serializable]
    /// <summary>
    /// 飞船类
    /// </summary>
    public abstract class SpaceShip : Item
    {
        private readonly double COS45 = 1.414;
        // 生命值
        private int life;
        //飞船方向， 默认停止
        private SpaceShipDirection direction = SpaceShipDirection.STOP;
        public SpaceShipDirection Direction
        {
            get { return direction; }
            set { direction = value; }
        }
        //射击工具类
        private ShootingBehavior shootBehavior;

        public ShootingBehavior ShootBehavior
        {
            get { return shootBehavior; }
            set { shootBehavior = value; }
        }

        public SpaceShip(int x, int y, bool faction, int width, int height, int speed, int life) : base(x, y, faction, width, height, speed)
        {
            this.life = life;
        }

        public int Life
        {
            set { life = value; }
            get { return life; }
        }
        /// <summary>
        /// 死亡
        /// </summary>
        public void Death()
        {
            life = 0;
            Live = false;
        }
        /// <summary>
        /// 受到伤害
        /// </summary>
        /// <param name="i">伤害值</param>
        public virtual void Injury(int i)
        {
            if(Live)
            {
                life -= i;
            }
            if(life <= 0)
            {
                Death();
            }
            if (life <= 0)
            {
                Death();
            }
        }
        /// <summary>
        /// 攻击
        /// </summary>
        public void Fire()
        {
            shootBehavior.Fire();
        }
        /// <summary>
        /// 移动
        /// </summary>
        protected override void Move()
        {
            switch(direction)
            {
                case SpaceShipDirection.U:
                    Y -= Speed;
                    break;
                case SpaceShipDirection.RU:
                    X += (int)(Speed * COS45);
                    Y -= (int)(Speed * COS45);
                    break;
                case SpaceShipDirection.R:
                    X += Speed;
                    break;
                case SpaceShipDirection.RD:
                    X += (int)(Speed * COS45);
                    Y += (int)(Speed * COS45);
                    break;
                case SpaceShipDirection.D:
                    Y += Speed;
                    break;
                case SpaceShipDirection.LD:
                    X -= (int)(Speed * COS45);
                    Y += (int)(Speed * COS45);
                    break;
                case SpaceShipDirection.L:
                    X -= Speed;
                    break;
                case SpaceShipDirection.LU:
                    X -= (int)(Speed * COS45);
                    Y -= (int)(Speed * COS45);
                    break;
                default: break;
            }
        }
        protected void Draw(Graphics g, Image img, int x, int y)
        {
            try
            {
                g.DrawImage(img, x, y);
            }
            catch { }
        }

        public void SetShootBehavior(ShootingBehavior shootBehavior)
        {
            this.shootBehavior = shootBehavior;
        }
    }
}
