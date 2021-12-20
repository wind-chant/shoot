
using shootBLL;
using shootModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shoot.UI
{
    #region 登录界面
    public partial class FrmStart : Form
    {
        #region 参数
        public FrmLogin frmLogin;
        public FrmMain frmMain;
        public FrmRank frmRank;
        public User user;
        /// <summary>
        /// 窗口宽度
        /// </summary>
        private readonly int width = int.Parse(UpdateManager.getAtt("width"));
        /// <summary>
        /// 窗口高度
        /// </summary>
        private readonly int height = int.Parse(UpdateManager.getAtt("height"));
        #endregion

        #region 方法
        public FrmStart(FrmLogin frmLogin, User user)
        {
            InitializeComponent();
            this.user = user;
            this.frmLogin = frmLogin;
        }

        private void FrmStart_Load(object sender, EventArgs e)
        {
            this.Width = width;//设置窗口的宽度
            this.Height = height;//设置窗口的高度

        }
        /// <summary>
        /// 开始游戏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            frmMain = new FrmMain(this);
            frmMain.Show();
            this.Hide();
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            frmLogin.flashPwd();
            this.Hide();
            frmLogin.Show();
        }

        private void FrmStart_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmLogin.Close();
        }

        private void btnRank_Click(object sender, EventArgs e)
        {
            frmRank = new FrmRank(this);
            this.Hide();
            frmRank.Show();
        }
        public void save_game()
        {
            IFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            formatter.Serialize(stream, UpdateManager.GetInstance());
            stream.Position = 0;
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            stream.Flush();
            stream.Close();
            user.data = Convert.ToBase64String(buffer);
            UserManager.ModifyUser(user);
        }
        private void restore_game(object sender, EventArgs e)
        {
            if (user.data == "")
            {
                MessageBox.Show("无存档信息");
                return;
            }
            IFormatter formatter = new BinaryFormatter();
            byte[] buffer = Convert.FromBase64String(user.data);
            MemoryStream stream = new MemoryStream(buffer);
            UpdateManager.SetInstance((UpdateManager)formatter.Deserialize(stream));
            stream.Flush();
            stream.Close();
            //restore_pic();
            frmMain = new FrmMain(this);
            frmMain.Show();
            this.Hide();
        }
        #endregion
    }
    #endregion
}
