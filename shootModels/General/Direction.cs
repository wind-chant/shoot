using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shootModels.General
{
    // 飞船方向
    public enum SpaceShipDirection
    {
        U, D, L, R, LU, RU, LD, RD, STOP
    }

    // 子弹方向
    public enum BulletDirection
    {
        U, D, L, R, LU, UL, RU, UR, LD, DL, RD, DR, STOP
    }
}
