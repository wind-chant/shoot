using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shootModels.Items
{
    [Serializable]
    public abstract class ShootingBehavior
    {
        //发射方
        protected SpaceShip ship;

        //发射抽象方法
        public abstract void Fire();
    }
}
