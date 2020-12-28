using _1660454_1660553_QuanLyNhaSach.DAO;
using _1660454_1660553_QuanLyNhaSach.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1660454_1660553_QuanLyNhaSach
{
    public partial class fStaff : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get => loginAccount;
            set
            {
                loginAccount = value;
                ChangeAccount();
            }
        }

        public fStaff(Account acc)
        {
            InitializeComponent();
            LoginAccount = acc;

        }
        void ChangeAccount()
        {
            txtTen.Text = LoginAccount.UserName;
        }
        private void fStaff_Load(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable login = new DataTable();
            DataTable login2 = new DataTable();

            if (AccountDAO.Instance.login(LoginAccount.UserName, Session.GetMD5(Txtmkc.Text)))
            {
                MessageBox.Show("Mật khẩu cũ không đúng");
                return;
            }
            if (Txtmkm.Text != "" && Txtmkm.Text != null)
            {
                if (Session.GetMD5(Txtmkc.Text) == Session.GetMD5(Txtmkm.Text))
                {
                    MessageBox.Show("Mật khẩu mới không được trùng với mật khẩu cũ");
                    return;
                }
                if ((Txtmkm.Text) != (Txtnl.Text))
                {
                    MessageBox.Show("Mật khẩu nhập lại không giống mật khẩu mới");
                    return;
                }
                if (AccountDAO.Instance.UpdateAccount(txtTen.Text, Session.GetMD5(Txtmkm.Text), LoginAccount.Accounts))
                {
                    MessageBox.Show("Cập nhật thành công");
                    if (updateAccount != null)
                    {
                        updateAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(LoginAccount.Accounts)));
                    }
                    this.Close();
                }
            }else
            {
                if (AccountDAO.Instance.UpdateAccountName(txtTen.Text, LoginAccount.Accounts))
                {
                    MessageBox.Show("Cập nhật thành công");
                    if (updateAccount != null)
                    {
                        updateAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(LoginAccount.Accounts)));
                    }
                    this.Close();
                }
            }
        }
        private event EventHandler<AccountEvent> updateAccount;
        public event EventHandler<AccountEvent> UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }
    }
    public class AccountEvent : EventArgs
    {
        private Account acc;

        public Account Acc
        {
            get { return acc; }
            set { acc = value; }
        }

        public AccountEvent(Account acc)
        {
            this.Acc = acc;
        }
    }
}
