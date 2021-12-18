using shootModels.Items;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shootModels.Characters
{
    public class EnemyBoss : SpaceShip
    {
        bool bu;
        bool br;
        public BlooBar blb;
        public EnemyBoss(int x, int y, bool faction, int width, int height, int speed, int life, bool bu, bool br) : base(x, y, faction, width, height, speed, life)
        {
            this.bu = bu;
            this.br = br;
            blb = new BlooBar(x, y, life);
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
