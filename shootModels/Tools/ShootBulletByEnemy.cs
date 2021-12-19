using shootModels.General;
using shootModels.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shootModels.Tools
{
    public class ShootBulletByEnemy : ShootingBehavior
    {
        public ShootBulletByEnemy(SpaceShip ship)
        {
            this.ship = ship;
        }
        public override void Fire()
        {
            Bullet b = new Bullet(ship, 15, 37, 25, ship.Faction, BulletDirection.D, 10);
            UpdateManager.GetInstance().AddElement(b);
        }
    }
}
