using shootBLL;
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
    public partial class FrmRank : Form
    {
        FrmStart frmStart;
        public FrmRank(FrmStart frmStart)
        {
            InitializeComponent();
            this.frmStart = frmStart;
        }

        private void FrmRank_Load(object sender, EventArgs e)
        {
            DataTable dt = UserManager.getRankTable();
            DataView dv = dt.DefaultView;
            dv.Sort = "point desc";
            dgvRank.DataSource = dv;
        }

        private void FrmRank_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmStart.Show();
        }
    }
}
