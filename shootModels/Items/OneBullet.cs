using shootModels.General;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shootModels.Items
{
    public class OneBullet : Bullet
    {
        public OneBullet(SpaceShip ship, int width, int height, int speed, bool faction, BulletDirection direction, int power) : base(ship, width, height, speed, faction, direction, power)
        {
        }

        public override void Draw(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}
