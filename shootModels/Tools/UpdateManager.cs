using shootModels;
using shootModels.Items;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shootBLL
{
    /// <summary>
    /// 画面更新检测
    /// </summary>
    public class UpdateManager
    {
        private Hero hero = null;
        public Hero Hero
        {
            get { return hero; }
        }
        private List<Bullet> heroBullet = new List<Bullet>();
        private List<SpaceShip> enemy = new List<SpaceShip>();
        private List<Bullet> enemyBullet = new List<Bullet>();
        private List<Base> bombs = new List<Base>();

        /* volatile 关键字表示字段可能被多个并发执行线程修改。声明为 
         * volatile 的字段不受编译器优化（假定由单个线程访问）的限制。
         * 这样可以确保该字段在任何时间呈现的都是最新的值。*/
        private static volatile UpdateManager instance;
        public static UpdateManager GetInstance()
        {
            if (instance == null)
            {
                instance = new UpdateManager();
            }
            return instance;
        }
        /// <summary>
        /// 添加物体
        /// </summary>
        /// <param name="item"></param>
        public void AddElement(Base item)
        {
            if (item is Hero)
            {
                hero = (Hero)item;
                return;
            }

            if (item is Bullet && ((Bullet)item).Faction)
            {
                heroBullet.Add((Bullet)item);
                return;
            }

            if (item is SpaceShip)
            {
                enemy.Add((SpaceShip)item);
                return;
            }

            if (item is Bullet)
            {
                enemyBullet.Add((Bullet)item);
                return;
            }

            if (item is Base)
            {
                bombs.Add(item);
                return;
            }
        }
        /// <summary>
        /// 移除物体
        /// </summary>
        /// <param name="item"></param>
        public void RemoveElement(Base item)
        {
            if (item is Bullet && ((Bullet)item).Faction)
            {
                heroBullet.Remove((Bullet)item);
                return;
            }

            if (item is SpaceShip)
            {
                enemy.Remove((SpaceShip)item);
                return;
            }

            if (item is Bullet)
            {
                enemyBullet.Remove((Bullet)item);
                return;
            }

            if (item is Base)
            {
                bombs.Remove(item);
                return;
            }
        }
        /// <summary>
        /// 绘制图像
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            hero.Draw(g);

            foreach(Bullet b in heroBullet)
            {
                b.Draw(g);
            }

            foreach(SpaceShip spaceShip in enemy)
            {
                spaceShip.Draw(g);
            }

            foreach (Bullet b in enemyBullet)
            {
                b.Draw(g);
            }

            foreach(Base b in bombs)
            {
                b.Draw(g);
            }

        }

        /// <summary>
        /// 碰撞检测
        /// </summary>
        public void DoHitCheck()
        {
            if (hero.Live)
            {
                //检测主人公与敌人是否相交
                for (int i = 0; i < enemy.Count; i++)
                {
                    if (hero.GetRectangle().IntersectsWith(enemy[i].GetRectangle()))
                    {
                        hero.Death();
                        UpdateManager.GetInstance().AddElement(new Bomb(hero));
                    }
                }

                //检测主人公与敌人的子弹是否相交
                foreach(Bullet b in enemyBullet)
                {
                    if (hero.GetRectangle().IntersectsWith(b.GetRectangle()))
                    {
                        hero.Injury(b.Power);
                        if (!hero.Live)
                            UpdateManager.GetInstance().AddElement(new Bomb(hero));
                        b.Live = false;
                    }
                }
            }

            //检测主人公的子弹与敌人是否相交
            foreach(Bullet bullet in heroBullet)
            {
                foreach(SpaceShip spaceShip in enemy)
                {
                    if (bullet.GetRectangle().IntersectsWith(spaceShip.GetRectangle()))
                    {
                        spaceShip.Injury(bullet.Power);
                        if(!spaceShip.Live)
                            UpdateManager.GetInstance().AddElement(new Bomb(spaceShip));
                        hero.score += 10;
                        /*if (hero.score > 100)//当经验值超过某个值得时候，会升级装备
                            hero.SetFireBehavior(new FireWithThreeMissilesByHero(myHero));//策略模式*/
                        bullet.Live = false;
                    }
                }
            }

        }
        public void Restart()//重新开始游戏
        {
            heroBullet = new List<Bullet>();
            enemy = new List<SpaceShip>();
            enemyBullet = new List<Bullet>();
            bombs = new List<Base>();
            hero = null;
        }
    }
}
