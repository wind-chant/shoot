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
        private static string imagesPath = UpdateManager.getAtt("BombImagPathRoot");

        private static Image[] images = new Image[]
        {
            Image.FromFile(imagesPath + "bomb_0.gif"),
            Image.FromFile(imagesPath + "bomb_1.gif"),
            Image.FromFile(imagesPath + "bomb_2.gif"),
            Image.FromFile(imagesPath + "bomb_3.gif"),
            Image.FromFile(imagesPath + "bomb_4.gif"),
            Image.FromFile(imagesPath + "bomb_5.gif"),
            Image.FromFile(imagesPath + "bomb_6.gif"),
            Image.FromFile(imagesPath + "bomb_7.gif"),
            Image.FromFile(imagesPath + "bomb_8.gif"),
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
