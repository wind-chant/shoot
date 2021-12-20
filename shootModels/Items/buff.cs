using shootModels.General;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shootModels.Items
{
    [Serializable]
    public class Buff : Item
    {

        private static string imagesPath = UpdateManager.getAtt("BuffImagPathRoot");

        private static Dictionary<string, Image> images = new Dictionary<string, Image>()
        {
           {"bulletCount",Image.FromFile(imagesPath+"bulletCount.png")},
           {"hp",Image.FromFile(imagesPath+"hp.png")}
        };
        private string name;

        public string Name
        {
            get { return name; }
        }

        public Buff(int x, int y, bool faction, int width, int height, int speed, string name) : base(x, y, faction, width, height, speed)
        {
            this.name = name;
        }
        /// <summary>
        /// 绘制
        /// </summary>
        /// <param name="g">绘图图面</param>
        /// <param name="images">图片</param>
        /// <param name="x">x坐标</param>
        /// <param name="y">y坐标</param>
        protected void Draw(Graphics g, Dictionary<string, Image> images, int x, int y)
        {
            g.DrawImage(images[name], X, Y);
        }

        public override void Draw(Graphics g)
        {
            if (Live == false)
            {
                UpdateManager.GetInstance().RemoveElement(this);
                return;
            }
            this.Move();
            Draw(g, images, X, Y);
        }

        protected override void Move()
        {
            Y = Y + Speed;

            if (Y > int.Parse(UpdateManager.getAtt("height")))
            {
                Live = false;
            }
        }
    }
}
