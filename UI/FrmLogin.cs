using shootBLL;
using shootDAL;
using shootModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shoot.UI
{
    #region 登陆界面
    public partial class FrmLogin : Form
    {
        FrmStart frmStart;

        /// <summary>
        /// 登出后清空密码
        /// </summary>
        public void flashPwd()
        {
            this.txtPassword.Text = "";
        }
        
        public FrmLogin()
        {
            InitializeComponent();
            frmStart = new FrmStart(this, null);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            User user = UserManager.register(this.txtName.Text, this.txtPassword.Text);

            if (user != null)
            {
                this.Hide();
                frmStart.user = user;
                frmStart.Show();
            }
            else
            {
                MessageBox.Show("用户名存在");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            User user = UserManager.login(this.txtName.Text, this.txtPassword.Text);

            if (user != null)
            {
                this.Hide();
                frmStart.user = user;
                frmStart.Show();
            }
            else
            {
                MessageBox.Show("用户名或密码错误");
            }
        }
    }
    #endregion
}
