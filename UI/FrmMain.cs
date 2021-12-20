
using shootModels;
using shootModels.Characters;
using shootModels.General;
using shootModels.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shoot.UI
{
    public partial class FrmMain : Form
    {
        /// <summary>
        /// 窗口宽度
        /// </summary>
        private static readonly int width = int.Parse(UpdateManager.getAtt("width"));
        /// <summary>
        /// 窗口高度
        /// </summary>
        private static readonly int height = int.Parse(UpdateManager.getAtt("height"));
        /// <summary>
        /// 界面位图
        /// </summary>
        public static Bitmap backgroundImg = new Bitmap(@"../../Resources/Images/background.png");
        /// <summary>
        /// 游戏状态
        /// </summary>
        private GameStatus status = GameStatus.INIT;

        /// <summary>
        /// boss
        /// </summary>
        private EnemyBoss eBoss = new EnemyBoss(width / 2, 20, false, 200, 117, 10, 200);

        ///背景滚动参数
        private int offset = 0;

        //双缓冲用到的变量
        //https://www.cnblogs.com/rainbow70626/p/10622372.html
        /// <summary>
        /// 虚拟画布
        /// </summary>
        private Bitmap bufferImg = null;
        /// <summary>
        /// 内存画布
        /// </summary>
        private Graphics gImg = null;

        Thread pt = null;

        /// <summary>
        /// 用于随机产生敌人
        /// </summary>
        public static Random enemyRandom = new Random();
        /// <summary>
        /// 敌人的总个数
        /// </summary>
        int enemyCount = 0;
        private static int enemyU = 20;
        /// <summary>
        /// 开始界面
        /// </summary>
        public FrmStart frmStart = null;

        public FrmMain(FrmStart frmStart)
        {
            InitializeComponent();
            this.frmStart = frmStart;
            InitForm();
        }
        /// <summary>
        ///  设置窗口
        /// </summary>
        private void InitForm()
        {
            this.Width = width;//设置窗口的宽度
            this.Height = height;//设置窗口的高度

            //设置显示图元控件的几个属性： 必须要设置，否则画面会闪烁
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);
            //创建一张位图,以后就在位图上作画,然后贴到窗口上,达到双缓冲
            bufferImg = new Bitmap(width, height);
            //指定的 Image 返回一个新的 Graphics。
            gImg = Graphics.FromImage(bufferImg);

            //游戏开始
            status = GameStatus.PLAYING;
        }
     
        /// <summary>
        /// 加载窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            //添加背景音乐
            String musicPath = @"../../Resources/music/";
            SoundPlayer backgroundMusic = new SoundPlayer(musicPath + "bgm.wav");//   
            backgroundMusic.PlayLooping();
            //添加Hero
            UpdateManager.GetInstance().AddElement(new Hero(width/2, height - 50, true, 50, 45, 20, 100));
            //窗体加载后,启动线程,刷新界面
            pt = new Thread(new ThreadStart(PaintThread));
            pt.Start();
        }

        /// <summary>
        /// 绘图线程
        /// </summary>
        private void PaintThread()
        {
            //当游戏开始的时候,就开始刷新屏幕
            while (status == GameStatus.PLAYING)
            {
                //画背景图片
                DrawBackground(gImg);

                GetEnemys();

                // 碰撞检测
                UpdateManager.GetInstance().DoHitCheck();
                if (UpdateManager.GetInstance().Hero.blb.NowLife <= 0)
                {
                    if (MessageBox.Show("游戏结束，重新开始吗？", "游戏结束", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //清除所有的角色
                        UpdateManager.GetInstance().Restart();
                        //Hero复活
                        UpdateManager.GetInstance().AddElement(new Hero(width / 2, height - 50, true, 50, 45, 20, 100));
                        //老怪复活
                        eBoss = new EnemyBoss(width / 2, 20, false, 200, 117, 10, 200);
                        //小怪复活
                        enemyCount = 0;
                    }
                    else
                    {
                        status = GameStatus.FAILED;
                    }
                }
                if (eBoss.blb.NowLife <= 0)
                {
                    if (MessageBox.Show("恭喜你，你赢了!还想再玩一局吗？", "胜利", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //清除所有的角色
                        UpdateManager.GetInstance().Restart();
                        //Hero复活
                        UpdateManager.GetInstance().AddElement(new Hero(width / 2, height - 50, true, 50, 45, 20, 100));
                        //老怪复活
                        eBoss = new EnemyBoss(width / 2, 20, false, 100, 58, 10, 200);
                        //小怪复活
                        enemyCount = 0;
                    }
                    else
                    {
                        status = GameStatus.WON;
                    }
                }

                UpdateManager.GetInstance().Draw(gImg);
                this.Invalidate();
                Thread.Sleep(50);
            }
            if (status == GameStatus.FAILED)
            {
                //GameOver gameover = new GameOver(this.Width / 2 - 140, this.Height / 2 - 140);
                //gameover.Draw(gImg);
            }
            if (status == GameStatus.WON)
            {
                //GameWin gameWin = new GameWin(this.Width / 2 - 180, this.Height / 2 - 140);
                //gameWin.Draw(gImg);
            }
        }

        private void GetEnemys()
        {
            if (enemyCount == -1)
            {
                return;
            }
            if (enemyRandom.Next(0, 1000) < 10)
            {
                Buff buff = new Buff(enemyRandom.Next(0, width), 0, true, 50, 50, 5, enemyRandom.Next(0, 2) == 0 ? "hp" : "bulletCount");
                UpdateManager.GetInstance().AddElement(buff);
            }

            if (enemyCount < enemyU && UpdateManager.GetInstance().getEnemyCount()<8)
            {
                SpaceShip enemy;
                if (enemyRandom.Next(0, 200) < 20)
                {
                    enemy = new EnemyOne(enemyRandom.Next(0, width), 0, false, 80, 69, 10, 30);
                    UpdateManager.GetInstance().AddElement(enemy);
                    enemyCount++;
                }
            }
            else if(UpdateManager.GetInstance().getEnemyCount() == 0)
            {

                UpdateManager.GetInstance().AddElement(eBoss);
                enemyCount = -1;
            }
        }

        /// <summary>
        /// 画游戏背景
        /// </summary>
        /// <param name="g"></param>
        private void DrawBackground(Graphics g)
        {
            g.DrawImage(backgroundImg, 0, offset - height, width, height);
            g.DrawImage(backgroundImg, 0, offset, width, height);

            offset += 3;
            if (offset >= height) offset = 0;
        }

        private void FrmMain_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bufferImg, 0, 0);//把画布贴到画面上
        }

        /// <summary>
        /// 清理资源
        /// </summary>
        private void DisResource()
        {
            status = GameStatus.INIT;
            //等待线程结束
            pt.Join();

            bufferImg.Dispose();
            gImg.Dispose();
            backgroundImg.Dispose();
            frmStart.Dispose();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("退出游戏吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                DisResource();
            }
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
             UpdateManager.GetInstance().Hero.KeyDown(e);
        }

        private void FrmMain_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateManager.GetInstance().Hero.KeyUp(e);
        }
    }
}
