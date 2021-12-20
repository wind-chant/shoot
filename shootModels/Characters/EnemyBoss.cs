using shootModels.General;
using shootModels.Items;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shootModels.Characters
{
    #region boss
    /// <summary>
    /// boss类
    /// </summary>
    [Serializable]
    public class EnemyBoss : SpaceShip
    {
        #region 参数
        /// <summary>
        /// 碰到上下边转向
        /// </summary>
        private static Dictionary<SpaceShipDirection, SpaceShipDirection> changeud = new Dictionary<SpaceShipDirection, SpaceShipDirection>()
        {
            {SpaceShipDirection.U, SpaceShipDirection.D },
            {SpaceShipDirection.RU, SpaceShipDirection.RD },
            {SpaceShipDirection.R, SpaceShipDirection.L },
            {SpaceShipDirection.RD, SpaceShipDirection.LU },
            {SpaceShipDirection.D, SpaceShipDirection.U },
            {SpaceShipDirection.LD, SpaceShipDirection.RU },
            {SpaceShipDirection.L, SpaceShipDirection.R },
            {SpaceShipDirection.LU, SpaceShipDirection.RD },
        };
        /// <summary>
        /// 碰到左右边转向
        /// </summary>
        private static Dictionary<SpaceShipDirection, SpaceShipDirection> changelr = new Dictionary<SpaceShipDirection, SpaceShipDirection>()
        {
            {SpaceShipDirection.U, SpaceShipDirection.D },
            {SpaceShipDirection.RU, SpaceShipDirection.LU },
            {SpaceShipDirection.R, SpaceShipDirection.L },
            {SpaceShipDirection.RD, SpaceShipDirection.LD },
            {SpaceShipDirection.D, SpaceShipDirection.U },
            {SpaceShipDirection.LD, SpaceShipDirection.RD },
            {SpaceShipDirection.L, SpaceShipDirection.R },
            {SpaceShipDirection.LU, SpaceShipDirection.RU },
        };
        /// <summary>
        /// 图片路径
        /// </summary>
        static string imgPath = UpdateManager.getAtt("EnemyBossImagPathRoot");
        /// <summary>
        /// 图片
        /// </summary>
        private Image img = Image.FromFile(imgPath);
        public BlooBar blb;
        #endregion
        public EnemyBoss(int x, int y, bool faction, int width, int height, int speed, int life) : base(x, y, faction, width, height, speed, life)
        {
            Array values = (Enum.GetValues(typeof(SpaceShipDirection)));
            Direction = (SpaceShipDirection)values.GetValue(new Random().Next(2, values.Length - 1));
            SetShootBehavior(new ShootBulletByBoss(this));
            blb = new BlooBar(x, y, life,width);
        }

        public override void Draw(System.Drawing.Graphics g)
        {
            blb.NowLife = Life;
            if (Live == false)
            {
                UpdateManager.GetInstance().RemoveElement(this);
                return;
            }

            this.Move();
            blb.Draw(g);
            base.Draw(g, img, X, Y);
        }

        protected override void Move()
        {
            int frmWidth = int.Parse(UpdateManager.getAtt("width"));
            int frmHeight = int.Parse(UpdateManager.getAtt("height"));
            base.Move();

            //超出边界检测
            if (X < 0)
            {
                X = 0;
                Direction = changeud[Direction];
            }
            if (Y < 0)
            {
                Y = 0;
                Direction = changeud[Direction];
            }
            if (X + WIDTH + 18 > frmWidth)
            {
                X = frmWidth - 18 - this.WIDTH;
                Direction = changelr[Direction];
            }
            if (Y + HEIGHT + 37 > frmHeight)
            {
                Y = frmHeight - 37 - this.HEIGHT;
                Direction = changelr[Direction];
            }
            {
                int rate = int.Parse(UpdateManager.getAtt("BossShootRate"));
                if (new Random().Next(100) % rate == 1)
                {
                    Fire();
                    Fire();
                }
            }

            blb.X = X;
            blb.Y = Y;
        }
    }
    #endregion
}
