using shootModels.General;
using shootModels.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace shootModels.Characters
{
    public class EnemyOne : SpaceShip
    {
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
        private static double COS45 = 0.707;
        /// <summary>
        /// 图片路径
        /// </summary>
        static string imgPath = @"../../Resources/Images/enemy1.png";
        /// <summary>
        /// 图片
        /// </summary>
        private Image img = Image.FromFile(imgPath);
        public EnemyOne(int x, int y, bool faction, int width, int height, int speed, int life) : base(x, y, faction, width, height, speed, life)
        {
            Array values = (Enum.GetValues(typeof(SpaceShipDirection)));
            Direction = (SpaceShipDirection)values.GetValue(new Random().Next(2,values.Length -1 ));
            SetShootBehavior(new ShootBulletByEnemy(this));
        }
        public override void Draw(System.Drawing.Graphics g)
        {
            if (Live == false)
            {
                UpdateManager.GetInstance().RemoveElement(this);
                return;
            }

            this.Move();
            base.Draw(g, img, X, Y);
        }

        protected override void Move()
        {
            int frmWidth = int.Parse(UpdateManager.getatt("width"));
            int frmHeight = int.Parse(UpdateManager.getatt("height"));
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
                if (new Random().Next(0, 100)%10 == 5 )
                {
                    Fire();
                }
            }
        }
    }
}
