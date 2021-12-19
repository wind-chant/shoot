using shootModels.General;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shootModels.Items
{
    public class ShootOneBulletByHero : ShootingBehavior
    {
        public ShootOneBulletByHero(SpaceShip ship)
        {
            this.ship = ship;
        }

        public override void Fire()
        {
            Bullet b = new Bullet(UpdateManager.GetInstance().Hero, 20, 20, 25, ship.Faction, BulletDirection.U, 10);
            if (ship.Live)
                UpdateManager.GetInstance().AddElement(b);
        }
    }
}
