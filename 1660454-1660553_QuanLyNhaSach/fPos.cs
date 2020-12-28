using _1660454_1660553_QuanLyNhaSach.DAO;
using _1660454_1660553_QuanLyNhaSach.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1660454_1660553_QuanLyNhaSach
{
    public partial class fPos : Form
    {
        private Account loginAccount;

        internal Account LoginAccount
        {
            get => loginAccount;
            set
            {
                loginAccount = value;
                ChangeAccount(loginAccount.Role);
            }
        }
        public fPos(Account acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;

        }
        #region Method

        void ChangeAccount(int type)
        {
            adminToolStripMenuItem.Enabled = type == 1;
            //thôngTinTàiKhoảnToolStripMenuItem.Text += " (" + LoginAccount.DisplayName + ")";
        }
        #endregion
        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.ShowDialog();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fStaff f = new fStaff(loginAccount);
            f.UpdateAccount += F_UpdateAccount;
            f.ShowDialog();
        }
        private void F_UpdateAccount(object sender, AccountEvent e)
        {
            Account sAccount = AccountDAO.Instance.GetAccountByUserName(loginAccount.Accounts);
            this.LoginAccount = sAccount;
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
            fLogin f = new fLogin();
            f.ShowDialog();
        }
    }
}
