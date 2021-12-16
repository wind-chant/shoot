using shootModels.General;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shootModels
{
    /// <summary>
    /// 飞船类
    /// </summary>
    public abstract class SpaceShip : Item
    {
        // 生命值
        private int life;

        private SpaceShipDirection direction = SpaceShipDirection.STOP;

        protected SpaceShip(Point p, bool faction, int width, int height, int x_speed, int y_speed) : base(p, faction, width, height, x_speed, y_speed)
        {
        }
    }
}
