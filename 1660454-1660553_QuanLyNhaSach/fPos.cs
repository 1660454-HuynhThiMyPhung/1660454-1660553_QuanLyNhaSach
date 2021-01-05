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
        string a = "1";
        int S, Q, W;
        int lm1, a1, c1;
        double tongtien, d1, cc;
        int id_detail = 1;
        List<POS> list_items = new List<POS>();
        Items items_detail;
        Client clients;
        public fPos(Account acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
            getDoanhThu();  

        }
        void getDoanhThu()
        {
            int total = AccountDAO.Instance.getDoanhThu(loginAccount.ID);
            txttennv.Text = loginAccount.UserName;
            txttotal.Text = String.Format("{0:n0}", total);
        }
        #region Method

        void ChangeAccount(int type)
        {
            adminToolStripMenuItem.Enabled = type == 1;
            //thôngTinTàiKhoảnToolStripMenuItem.Text += " (" + LoginAccount.DisplayName + ")";
        }
        #endregion
        private void bththemkh_Click(object sender, EventArgs e)
        {
            fKhachHang f = new fKhachHang();
            f.UpdateClient += F_UpdateClient1;
            f.ShowDialog();
        }
        private void F_UpdateClient1(object sender, ClientEvent e)
        {
            clients = e.Clients;
            ltenKH.Text = e.Clients.Name;
            lsex.Text = e.Clients.Sex;
            laddress.Text = e.Clients.Address;
            lemailKH.Text = e.Clients.Email;
            txtdiem.Text = e.Clients.Diem.ToString();
        }

        private void bthtimkh_Click(object sender, EventArgs e)
        {
            clients = ClientDAO.Instance.GetItemsByID(txtsdtkh.Text);
            if (clients == null)
            {
                MessageBox.Show("Không Tìm Thấy Khách Hàng");
            }
            else
            {
                ltenKH.Text = clients.Name;
                lsex.Text = clients.Sex;
                laddress.Text = clients.Address;
                lemailKH.Text = clients.Email;
                txtdiem.Text = clients.Diem.ToString();
                if (clients.Diem > 0)
                {
                    Session.discount = 10;
                    LoadPOS();
                }
            }
        }
        void lmhChanged()
        {
            if (slmh.Text == "")
            {
                S = Convert.ToInt32(a);
            }
            else
            {
                S = Convert.ToInt32(slmh.Text);

            }

            Q = Int32.Parse(Giamh.Text);
            W = S * Q;
            tongtien1mh.Text = W.ToString();
        }
        private void mamh_TextChanged(object sender, EventArgs e)
        {
            items_detail = ItemsDAO.Instance.GetItemsByID(mamh.Text);
            if (items_detail != null)
            {
                tenmonhang.Text = items_detail.name;
                Giamh.Text = items_detail.price.ToString();
                slmh.Text = "1";
                lmhChanged();
            }
            else
            {
                tenmonhang.Text = null;
                Giamh.Text = null;
            }
        }

        private void slmh_TextChanged(object sender, EventArgs e)
        {
            lmhChanged();
        }

        private void themmonhang_Click(object sender, EventArgs e)
        {
            if (items_detail != null)
            {
                POS pos = new POS(id_detail, items_detail.avatar, items_detail.ID, items_detail.name, int.Parse(slmh.Text), items_detail.price);
                list_items.Add(pos);
                LoadPOS();
                id_detail++;
                tenmonhang.Text = null;
                Giamh.Text = "0";
                slmh.Text = "0";
                mamh.Text = null;
                tongtien1mh.Text = "0";
                items_detail = null;
            }
        }

        private void txtsdtkh_Enter(object sender, EventArgs e)
        {
            if (txtsdtkh.Text == "Nhập số điện thoại")
            {
                txtsdtkh.Text = "";
                txtsdtkh.ForeColor = Color.Black;
            }
        }

        private void txtsdtkh_Leave(object sender, EventArgs e)
        {
            if (txtsdtkh.Text == "")
            {
                txtsdtkh.Text = "Nhập số điện thoại";
                txtsdtkh.ForeColor = Color.Silver;
            }
        }

        private void hienCTdonhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                string ld = hienCTdonhang.Rows[e.RowIndex].Cells[1].Value.ToString();
                var itemToRemove = list_items.Single(r => r.ID == int.Parse(ld));
                list_items.Remove(itemToRemove);
                LoadPOS();
            }
        }

        private void bthchietkhau_Click(object sender, EventArgs e)
        {
            fDiscount f = new fDiscount();
            f.StartPosition = FormStartPosition.CenterParent;
            f.FormClosed += F_FormClosed;
            f.ShowDialog();
        }
        private void F_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadPOS();
        }

        private void bththanhtoan_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thanh toán", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (list_items != null)
                {
                    if (clients != null)
                    {
                        if (OrderDAO.Instance.InsertOrder(list_items, LoginAccount, clients))
                        {
                            MessageBox.Show("Thêm đơn hàng thành công");
                            clients = null;
                            ltenKH.Text = "";
                            lsex.Text = "";
                            laddress.Text = "";
                            lemailKH.Text = "";
                            txtdiem.Text = "";
                            list_items = new List<POS>();
                            Session.discount = 0;
                            LoadPOS();
                            getDoanhThu();
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi khi thêm đơn hàng");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không có khách hàng");
                    }
                }
                else
                {
                    MessageBox.Show("Không có sản phẩm");
                }
            }
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin(loginAccount);
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
        void LoadPOS()
        {
            BindingSource source = new BindingSource();
            source.DataSource = list_items;
            hienCTdonhang.DataSource = source;
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Tác vụ";
            btn.Text = "Xóa";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;

            int columnIndex = 0;
            if (hienCTdonhang.Columns["btn"] == null)
            {
                hienCTdonhang.Columns.Insert(columnIndex, btn);
            }
            hienCTdonhang.Refresh();
            tongtien = 0;
            foreach (var item in list_items)
            {
                tongtien += item.price * item.Quanliti;
            }
            tongtienpos.Text = tongtien.ToString();
            discountpos.Text = (tongtien * (Session.discount / 100f)).ToString();
            txtthanhtien.Text = (tongtien - (tongtien * (Session.discount / 100f))).ToString();
        }
        private void bnthuyphieu_Click(object sender, EventArgs e)
        {
            clients = null;
            ltenKH.Text = "";
            lsex.Text = "";
            laddress.Text = "";
            lemailKH.Text = "";
            txtdiem.Text = "";
            list_items = new List<POS>();
            Session.discount = 0;
            LoadPOS();
        }
    }
}
