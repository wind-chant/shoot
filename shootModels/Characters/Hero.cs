using shootModels.Items;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shootModels
{
    /// <summary>
    /// 玩家英雄类
    /// </summary>
    public class Hero : SpaceShip
    {
        /// <summary>
        /// 图片路径
        /// </summary>
        string imgPath = "";
        /// <summary>
        /// 图片
        /// </summary>
        private Image img;
        //用户是否按下"上\下\左\右"
        private bool U = false, D = false, L = false, R = false;
        public BlooBar blb = null;
        public Hero(int x, int y, bool faction, int width, int height, int speed, int life) : base(x, y, faction, width, height, speed, life)
        {
            blb = new BlooBar(x, y, life);
            ShootBehavior = new ShootingBehavior(this);
        }


        public override void Draw(Graphics g)
        {
            throw new NotImplementedException();
        }

        protected override void Explosion()
        {
            throw new NotImplementedException();
        }
    }
}
