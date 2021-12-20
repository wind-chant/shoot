using shootModels.General;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shootModels.Items
{
    [Serializable]
    public class ShootOneBulletByHero : ShootingBehavior
    {
        public ShootOneBulletByHero(SpaceShip ship)
        {
            this.ship = ship;
        }

        public override void Fire()
        {
            int width = int.Parse(UpdateManager.getAtt("HeroBulletWidth"));
            int height = int.Parse(UpdateManager.getAtt("HeroBulletHeight"));
            int speed = int.Parse(UpdateManager.getAtt("HeroBulletSpeed"));
            int power = int.Parse(UpdateManager.getAtt("HeroBulletPower"));
            Bullet b = new Bullet(UpdateManager.GetInstance().Hero, width, height, speed, ship.Faction, BulletDirection.U, power);
            if (ship.Live)
                UpdateManager.GetInstance().AddElement(b);
        }
    }
}
