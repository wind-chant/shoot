using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shootModels.Items
{
    [Serializable]
    /// <summary>
    /// 爆炸
    /// </summary>
    public class Bomb:Base
    {
        private int step = 0;//画到第几个图片

        private static Image[] images = new Image[]
        {
            global::shootModels.Properties.Resources.bomb_0,
            global::shootModels.Properties.Resources.bomb_1,
            global::shootModels.Properties.Resources.bomb_2,
            global::shootModels.Properties.Resources.bomb_3,
            global::shootModels.Properties.Resources.bomb_4,
            global::shootModels.Properties.Resources.bomb_5,
            global::shootModels.Properties.Resources.bomb_6,
            global::shootModels.Properties.Resources.bomb_7,
            global::shootModels.Properties.Resources.bomb_8,
        };

        public Bomb(SpaceShip ship)
            : base(ship.X + ship.WIDTH / 2 - images[0].Width / 2, ship.Y + ship.WIDTH / 2 - images[0].Width / 2)
        {

        }

        public override void Draw(System.Drawing.Graphics g)
        {
            if (step < images.Length)
            {
                g.DrawImage(images[step], X, Y);
                step++;
            }
            else
            {
                Live = false;
            }
        }
    }
}
