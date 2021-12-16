using shootModels.General;
using shootModels.Items;
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
        //飞船方向， 默认停止
        private SpaceShipDirection direction = SpaceShipDirection.STOP;
        //射击工具类
        private ShootingBehavior shootBehavior;

        protected SpaceShip(int x, int y, bool faction, int width, int height, int x_speed, int y_speed) : base(x, y, faction, width, height, x_speed, y_speed)
        {

        }
    }
}
