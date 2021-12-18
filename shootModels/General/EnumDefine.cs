using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shootModels.General
{
    /// <summary>
    /// 飞船方向
    /// </summary>
    public enum SpaceShipDirection
    {
        U, D, L, R, LU, RU, LD, RD, STOP
    }

    /// <summary>
    /// 子弹方向
    /// </summary>
    public enum BulletDirection
    {
        U, D, L, R, LU, UL, RU, UR, LD, DL, RD, DR, STOP
    }
    /// <summary>
    /// 游戏状态
    /// </summary>
    public enum GameStatus { INIT, PLAYING, WON, FAILED }
}
