using shootModels.General;
using shootModels.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shootModels.Tools
{
    public class ShootThreeBulletByHero:ShootingBehavior
    {
        public ShootThreeBulletByHero(SpaceShip ship)
        {
            this.ship = ship;
        }
        public override void Fire()
        {
            if (ship.Live)
            {
                Bullet b = new Bullet(UpdateManager.GetInstance().Hero, 20, 20, 25, ship.Faction, BulletDirection.UL, 10);
                UpdateManager.GetInstance().AddElement(b);
                b = new Bullet(UpdateManager.GetInstance().Hero, 20, 20, 25, ship.Faction, BulletDirection.UR, 10);
                UpdateManager.GetInstance().AddElement(b);
                b = new Bullet(UpdateManager.GetInstance().Hero, 20, 20, 25, ship.Faction, BulletDirection.U, 10);
                UpdateManager.GetInstance().AddElement(b);
            }
        }
    }
}
