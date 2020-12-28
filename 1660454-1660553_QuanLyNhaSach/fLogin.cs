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
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (login(dangnhap.Text, Session.GetMD5(matkhau.Text)))
            {
                Account loginAccount = AccountDAO.Instance.GetAccountByUserName(dangnhap.Text);
                this.Hide();
                fPos f = new fPos(loginAccount);
                f.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mặt khẩu");
            }
        }
        bool login(string username, string password)
        {
            return AccountDAO.Instance.login(username,password);
        }
        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if(MessageBox.Show("Bạn có thực sự muốn thoát?","Thông báo",MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            //{
            //    e.Cancel = true;
            //}login.Rows[0]["name"].ToString();
        }

        private void dangnhap_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
