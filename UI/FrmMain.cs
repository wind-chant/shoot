
using shootBLL;
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
        public static Bitmap backgroundImg = new Bitmap(UpdateManager.getAtt("BackgroundImagPath"));
        /// <summary>
        /// 游戏状态
        /// </summary>
        private GameStatus status = GameStatus.INIT;

        private static int bossWidth = int.Parse(UpdateManager.getAtt("EnemyBossWidth"));
        private static int bossHeight = int.Parse(UpdateManager.getAtt("EnemyBossHeight"));
        private static int bossSpeed = int.Parse(UpdateManager.getAtt("EnemyBossSpeed"));
        private static int bossLife = int.Parse(UpdateManager.getAtt("EnemyBossLife"));
        /// <summary>
        /// boss
        /// </summary>
        private EnemyBoss eBoss = new EnemyBoss(width / 2, 20, false, bossWidth, bossHeight, bossSpeed, bossLife);

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

        private static int heroWidth = int.Parse(UpdateManager.getAtt("HeroWidth"));
        private static int heroHeight = int.Parse(UpdateManager.getAtt("HeroHeight"));
        private static int heroSpeed = int.Parse(UpdateManager.getAtt("HeroSpeed"));
        private static int heroLife = int.Parse(UpdateManager.getAtt("HeroLife"));
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
            UpdateManager.GetInstance().AddElement(new Hero(width/2, height - 50, true, heroWidth, heroHeight, heroSpeed, heroLife));
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
                if (UpdateManager.GetInstance().Hero.blb.NowLife <= 0)      //死亡
                {
                    string gameoverPath = UpdateManager.getAtt("LoseImagPath");
                    Image img = Image.FromFile(gameoverPath);
                    gImg.DrawImage(img, width/2 - img.Width/2, height/2, img.Width, img.Height);
                    frmStart.user.point = Math.Max(frmStart.user.point, UpdateManager.GetInstance().Hero.score);
                    UserManager.ModifyUser(frmStart.user);
                    changePoint("Point:" + UpdateManager.GetInstance().Hero.score);
                    status = GameStatus.FAILED;
                }
                if (eBoss.blb.NowLife <= 0)
                {
                    string gameoverPath = UpdateManager.getAtt("WonImagPath");
                    Image img = Image.FromFile(gameoverPath);
                    gImg.DrawImage(img, width / 2 - img.Width / 2, height / 2, img.Width, img.Height);
                    frmStart.user.point = Math.Max(frmStart.user.point, UpdateManager.GetInstance().Hero.score);
                    UserManager.ModifyUser(frmStart.user);
                    changePoint("Point:" + UpdateManager.GetInstance().Hero.score);
                    status = GameStatus.WON;
                }

                UpdateManager.GetInstance().Draw(gImg);
                this.Invalidate();
                Thread.Sleep(50);
            }
        }

        public void changePoint(string str)
        {
            if (lblPoint.InvokeRequired)
            {
                // 当一个控件的InvokeRequired属性值为真时，说明有一个创建它以外的线程想访问它
                Action<string> actionDelegate = (x) => 
                { 
                    this.lblPoint.Text = x;

                    this.lblPoint.Visible = true;
                    this.btnReturn.Visible = true;
                };
                this.lblPoint.Invoke(actionDelegate, str);
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
            try
            {
                g.DrawImage(backgroundImg, 0, offset - height, width, height);
                g.DrawImage(backgroundImg, 0, offset, width, height);
            }
            catch (Exception ex)
            {
            }

            offset += 3;
            if (offset >= height) offset = 0;
        }

        private void FrmMain_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                e.Graphics.DrawImage(bufferImg, 0, 0);//把画布贴到画面上
            }
            catch (Exception ex)
            { 
            }
        }

        /// <summary>
        /// 清理资源
        /// </summary>
        public void DisResource()
        {
            status = GameStatus.INIT;
            //等待线程结束
            pt.Join();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("退出游戏吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                frmStart.save_game();
                DisResource();
                bufferImg.Dispose();
                gImg.Dispose();
                backgroundImg.Dispose();
                frmStart.frmLogin.Close();
                frmStart.Close();
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

        private void btnReturn_Click(object sender, EventArgs e)
        {
            DisResource();
            UpdateManager.GetInstance().Restart();
            this.Hide();
            frmStart.Show();
        }
    }
}
