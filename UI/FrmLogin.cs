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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

     

        private void btnRegister_Click(object sender, EventArgs e)
        {
            User user = new User(this.txtName.Text, this.txtPassword.Text);


            user = UserService.register(user);

            if (user != null)
            {
                MessageBox.Show("注册成功");
                this.Hide();
                FrmStart f = new FrmStart(user);
                f.Show();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            User user = new User(this.txtName.Text, this.txtPassword.Text);


            user = UserService.login(user);

            if (user != null)
            {
                MessageBox.Show("登录成功");
                this.Hide();
                FrmStart f = new FrmStart(user);
                f.Show();
            }
        }
    }
}
