using shootModels.General;
using shootModels.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shootModels.Tools
{
    [Serializable]
    public class ShootTwoBulletByHero : ShootingBehavior
    {
        public ShootTwoBulletByHero(SpaceShip ship)
        {
            this.ship = ship;
        }
        public override void Fire()
        {
            if (ship.Live)
            {
                int width = int.Parse(UpdateManager.getAtt("HeroBulletWidth"));
                int height = int.Parse(UpdateManager.getAtt("HeroBulletHeight"));
                int speed = int.Parse(UpdateManager.getAtt("HeroBulletSpeed"));
                int power = int.Parse(UpdateManager.getAtt("HeroBulletPower"));
                Bullet b = new Bullet(UpdateManager.GetInstance().Hero, width, height, speed, ship.Faction, BulletDirection.UL, power);
                UpdateManager.GetInstance().AddElement(b);
                b = new Bullet(UpdateManager.GetInstance().Hero, width, height, speed, ship.Faction, BulletDirection.UR, power);
                UpdateManager.GetInstance().AddElement(b);
            }
        }
    }
}
