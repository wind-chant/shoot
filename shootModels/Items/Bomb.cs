using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shootModels.Items
{
    /// <summary>
    /// 爆炸
    /// </summary>
    public class Bomb:Base
    {
        private int step = 0;//画到第几个图片
        private static string imagesPath = @"../../Resources/Images/";

        private static Image[] images = new Image[]
        {
            Image.FromFile(imagesPath + "blast2_0.gif"),
            Image.FromFile(imagesPath + "blast2_1.gif"),
            Image.FromFile(imagesPath + "blast2_2.gif"),
            Image.FromFile(imagesPath + "blast2_3.gif"),
            Image.FromFile(imagesPath + "blast2_4.gif"),
            Image.FromFile(imagesPath + "blast2_5.gif"),
            Image.FromFile(imagesPath + "blast2_6.gif"),
            Image.FromFile(imagesPath + "blast2_7.gif"),
            Image.FromFile(imagesPath + "blast2_8.gif"),
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
