using shootModels.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shootModels.Items
{
    [Serializable]
    public class ShootBulletByBoss : ShootingBehavior
    {
        public ShootBulletByBoss(SpaceShip ship)
        {
            this.ship = ship;
        }

        public override void Fire()
        {
            int width = int.Parse(UpdateManager.getAtt("EnemyBossBulletWidth"));
            int height = int.Parse(UpdateManager.getAtt("EnemyBossBulletHeight"));
            int speed = int.Parse(UpdateManager.getAtt("EnemyBossBulletSpeed"));
            int power = int.Parse(UpdateManager.getAtt("EnemyBossBulletPower"));
            Bullet b;
            switch (UpdateManager.random.Next(3))
            {
                case 0:
                    b = new Bullet(ship, width, height, speed, ship.Faction, BulletDirection.U, power);
                    UpdateManager.GetInstance().AddElement(b);
                    b = new Bullet(ship, width, height, speed, ship.Faction, BulletDirection.D, power);
                    UpdateManager.GetInstance().AddElement(b);
                    b = new Bullet(ship, width, height, speed, ship.Faction, BulletDirection.L, power);
                    UpdateManager.GetInstance().AddElement(b);
                    b = new Bullet(ship, width, height, speed, ship.Faction, BulletDirection.R, power);
                    UpdateManager.GetInstance().AddElement(b);
                    break;
                case 1:
                    b = new Bullet(ship, width, height, speed, ship.Faction, BulletDirection.RU, power);
                    UpdateManager.GetInstance().AddElement(b);
                    b = new Bullet(ship, width, height, speed, ship.Faction, BulletDirection.UR, power);
                    UpdateManager.GetInstance().AddElement(b);
                    b = new Bullet(ship, width, height, speed, ship.Faction, BulletDirection.LD, power);
                    UpdateManager.GetInstance().AddElement(b);
                    b = new Bullet(ship, width, height, speed, ship.Faction, BulletDirection.DL, power);
                    UpdateManager.GetInstance().AddElement(b);
                    b = new Bullet(ship, width, height, speed, ship.Faction, BulletDirection.RD, power);
                    UpdateManager.GetInstance().AddElement(b);
                    b = new Bullet(ship, width, height, speed, ship.Faction, BulletDirection.DR, power);
                    UpdateManager.GetInstance().AddElement(b);
                    b = new Bullet(ship, width, height, speed, ship.Faction, BulletDirection.LU, power);
                    UpdateManager.GetInstance().AddElement(b);
                    b = new Bullet(ship, width, height, speed, ship.Faction, BulletDirection.UL, power);
                    UpdateManager.GetInstance().AddElement(b);
                    break;
                case 2:
                    b = new Bullet(ship, width, height, speed, ship.Faction, BulletDirection.U, power);
                    UpdateManager.GetInstance().AddElement(b);
                    b = new Bullet(ship, width, height, speed, ship.Faction, BulletDirection.D, power);
                    UpdateManager.GetInstance().AddElement(b);
                    b = new Bullet(ship, width, height, speed, ship.Faction, BulletDirection.L, power);
                    UpdateManager.GetInstance().AddElement(b);
                    b = new Bullet(ship, width, height, speed, ship.Faction, BulletDirection.R, power);
                    UpdateManager.GetInstance().AddElement(b);
                    b = new Bullet(ship, width, height, speed, ship.Faction, BulletDirection.RU, power);
                    UpdateManager.GetInstance().AddElement(b);
                    b = new Bullet(ship, width, height, speed, ship.Faction, BulletDirection.UR, power);
                    UpdateManager.GetInstance().AddElement(b);
                    b = new Bullet(ship, width, height, speed, ship.Faction, BulletDirection.LD, power);
                    UpdateManager.GetInstance().AddElement(b);
                    b = new Bullet(ship, width, height, speed, ship.Faction, BulletDirection.DL, power);
                    UpdateManager.GetInstance().AddElement(b);
                    b = new Bullet(ship, width, height, speed, ship.Faction, BulletDirection.RD, power);
                    UpdateManager.GetInstance().AddElement(b);
                    b = new Bullet(ship, width, height, speed, ship.Faction, BulletDirection.DR, power);
                    UpdateManager.GetInstance().AddElement(b);
                    b = new Bullet(ship, width, height, speed, ship.Faction, BulletDirection.LU, power);
                    UpdateManager.GetInstance().AddElement(b);
                    b = new Bullet(ship, width, height, speed, ship.Faction, BulletDirection.UL, power);
                    break;
                default: break;
            }
        }
    }
}
