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
    public class ShootBulletByEnemy : ShootingBehavior
    {
        public ShootBulletByEnemy(SpaceShip ship)
        {
            this.ship = ship;
        }
        public override void Fire()
        {
            int width = int.Parse(UpdateManager.getAtt("EnemyBulletWidth"));
            int height = int.Parse(UpdateManager.getAtt("EnemyBulletHeight"));
            int speed = int.Parse(UpdateManager.getAtt("EnemyBulletSpeed"));
            int power = int.Parse(UpdateManager.getAtt("EnemyBulletPower"));
            Bullet b = new Bullet(ship, width, height, speed, ship.Faction, BulletDirection.D, power);
            UpdateManager.GetInstance().AddElement(b);
        }
    }
}
