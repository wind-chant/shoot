using shootModels.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shootModels.Items
{
    public class ShootBulletByBoss : ShootingBehavior
    {
        public ShootBulletByBoss(SpaceShip ship)
        {
            this.ship = ship;
        }

        public override void Fire()
        {
            Bullet b;
            switch (UpdateManager.random.Next(0, 3))
            {
                case 0:
                    b = new Bullet(ship, 20, 20, 20, ship.Faction, BulletDirection.U, 10);
                    UpdateManager.GetInstance().AddElement(b);
                    b = new Bullet(ship, 20, 20, 20, ship.Faction, BulletDirection.D, 10);
                    UpdateManager.GetInstance().AddElement(b);
                    b = new Bullet(ship, 20, 20, 20, ship.Faction, BulletDirection.L, 10);
                    UpdateManager.GetInstance().AddElement(b);
                    b = new Bullet(ship, 20, 20, 20, ship.Faction, BulletDirection.R, 10);
                    UpdateManager.GetInstance().AddElement(b);
                    break;
                case 1:
                    b = new Bullet(ship, 20, 20, 20, ship.Faction, BulletDirection.RU, 10);
                    UpdateManager.GetInstance().AddElement(b);
                    b = new Bullet(ship, 20, 20, 20, ship.Faction, BulletDirection.UR, 10);
                    UpdateManager.GetInstance().AddElement(b);
                    b = new Bullet(ship, 20, 20, 20, ship.Faction, BulletDirection.LD, 10);
                    UpdateManager.GetInstance().AddElement(b);
                    b = new Bullet(ship, 20, 20, 20, ship.Faction, BulletDirection.DL, 10);
                    UpdateManager.GetInstance().AddElement(b);
                    b = new Bullet(ship, 20, 20, 20, ship.Faction, BulletDirection.RD, 10);
                    UpdateManager.GetInstance().AddElement(b);
                    b = new Bullet(ship, 20, 20, 20, ship.Faction, BulletDirection.DR, 10);
                    UpdateManager.GetInstance().AddElement(b);
                    b = new Bullet(ship, 20, 20, 20, ship.Faction, BulletDirection.LU, 10);
                    UpdateManager.GetInstance().AddElement(b);
                    b = new Bullet(ship, 20, 20, 20, ship.Faction, BulletDirection.UL, 10);
                    UpdateManager.GetInstance().AddElement(b);
                    break;
                case 2:
                    b = new Bullet(ship, 20, 20, 20, ship.Faction, BulletDirection.U, 10);
                    UpdateManager.GetInstance().AddElement(b);
                    b = new Bullet(ship, 20, 20, 20, ship.Faction, BulletDirection.D, 10);
                    UpdateManager.GetInstance().AddElement(b);
                    b = new Bullet(ship, 20, 20, 20, ship.Faction, BulletDirection.L, 10);
                    UpdateManager.GetInstance().AddElement(b);
                    b = new Bullet(ship, 20, 20, 20, ship.Faction, BulletDirection.R, 10);
                    UpdateManager.GetInstance().AddElement(b);
                    b = new Bullet(ship, 20, 20, 20, ship.Faction, BulletDirection.RU, 10);
                    UpdateManager.GetInstance().AddElement(b);
                    b = new Bullet(ship, 20, 20, 20, ship.Faction, BulletDirection.UR, 10);
                    UpdateManager.GetInstance().AddElement(b);
                    b = new Bullet(ship, 20, 20, 20, ship.Faction, BulletDirection.LD, 10);
                    UpdateManager.GetInstance().AddElement(b);
                    b = new Bullet(ship, 20, 20, 20, ship.Faction, BulletDirection.DL, 10);
                    UpdateManager.GetInstance().AddElement(b);
                    b = new Bullet(ship, 20, 20, 20, ship.Faction, BulletDirection.RD, 10);
                    UpdateManager.GetInstance().AddElement(b);
                    b = new Bullet(ship, 20, 20, 20, ship.Faction, BulletDirection.DR, 10);
                    UpdateManager.GetInstance().AddElement(b);
                    b = new Bullet(ship, 20, 20, 20, ship.Faction, BulletDirection.LU, 10);
                    UpdateManager.GetInstance().AddElement(b);
                    b = new Bullet(ship, 20, 20, 20, ship.Faction, BulletDirection.UL, 10);
                    break;
                default: break;
            }
        }
    }
}
