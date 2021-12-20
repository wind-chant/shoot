using shootModels;
using shootModels.Items;
using shootModels.Tools;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shootModels
{
    [Serializable]
    /// <summary>
    /// 画面更新检测
    /// </summary>
    public class UpdateManager
    {
        public static Random random = new Random();
        private Hero hero = null;
        public Hero Hero
        {
            get { return hero; }
        }
        private List<Bullet> heroBullet = new List<Bullet>();
        private List<SpaceShip> enemy = new List<SpaceShip>();
        private List<Bullet> enemyBullet = new List<Bullet>();
        private List<Base> bombs = new List<Base>();
        private List<Buff> buff = new List<Buff>();

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
        /// 读取配置
        /// </summary>
        /// <param name="str">配置名称</param>
        /// <returns></returns>
        public static string getAtt(string str)
        {
            return ConfigurationManager.AppSettings[str].ToString();
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

            if (item is Buff)
            {
                buff.Add((Buff)item);
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

            if (item is Buff)
            {
                buff.Remove((Buff)item);
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
            for (int i = 0; i < heroBullet.Count; i++)
            {
                heroBullet[i].Draw(g);
            }
            for (int i = 0; i < enemy.Count; i++)
            {
                enemy[i].Draw(g);
            }

            for (int i = 0; i < buff.Count; i++)
            {
                buff[i].Draw(g);
            }

            //画敌人的子弹
            for (int i = 0; i < enemyBullet.Count; i++)
            {
                enemyBullet[i].Draw(g);
            }

            //画所有人的爆炸
            for (int i = 0; i < bombs.Count; i++)
            {
                bombs[i].Draw(g);
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

                //检测主人公与buff是否相交
                foreach (Buff b in buff)
                {
                    if (hero.GetRectangle().IntersectsWith(b.GetRectangle()))
                    {
                        hero.AddBuff(b);
                        b.Live = false;
                    }
                }
            }

            //检测主人公的子弹与敌人是否相交
            for (int i = 0; i < heroBullet.Count; i++)
            {
                for (int j = 0; j < enemy.Count; j++)
                {
                    if (heroBullet[i].GetRectangle().IntersectsWith(enemy[j].GetRectangle()))
                    {
                        enemy[j].Injury(heroBullet[i].Power);
                        if (!enemy[j].Live)
                        {
                            UpdateManager.GetInstance().AddElement(new Bomb(enemy[j]));
                            hero.score += 10;
                        }
                        heroBullet[i].Live = false;
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
            buff = new List<Buff>();
            hero = null;
        }

        public int getEnemyCount()
        {
            return enemy.Count;
        }
    }
}
