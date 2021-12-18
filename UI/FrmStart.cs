using shootBLL;
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
    public partial class FrmStart : Form
    {
        /// <summary>
        /// 窗口宽度
        /// </summary>
        private readonly int width = FormManager.getWidth();
        /// <summary>
        /// 窗口高度
        /// </summary>
        private readonly int height = FormManager.getHeight();
        public FrmStart()
        {
            InitializeComponent();
        }

        private void FrmStart_Load(object sender, EventArgs e)
        {
            this.Width = width;//设置窗口的宽度
            this.Height = height;//设置窗口的高度

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            FrmMain form = new FrmMain(this);
            form.Show();
            this.Hide();
        }
    }
}
