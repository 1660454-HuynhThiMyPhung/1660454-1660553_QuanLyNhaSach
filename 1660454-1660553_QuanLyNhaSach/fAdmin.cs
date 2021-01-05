using _1660454_1660553_QuanLyNhaSach.DAO;
using _1660454_1660553_QuanLyNhaSach.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1660454_1660553_QuanLyNhaSach
{
    public partial class fAdmin : Form
    {
        BindingSource CategoryList = new BindingSource();
        BindingSource ItemsList = new BindingSource();
        BindingSource ReportDoanhthuList = new BindingSource();
        BindingSource StaffList = new BindingSource();
        BindingSource ClientList = new BindingSource();

        private Account loginAccount;
        internal Account LoginAccount
        {
            get => loginAccount;
            set
            {
                loginAccount = value;
            }
        }

        public fAdmin(Account acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
            load();
        }

        private void fAdmin_Load(object sender, EventArgs e)
        {
        }
        void load()
        {
            datagvDM.DataSource = CategoryList;
            datagvSP.DataSource = ItemsList;
            datagvStaff.DataSource = StaffList;
            datareport_doanhthu.DataSource = ReportDoanhthuList;
            datagvclient.DataSource = ClientList;

            QuanLy_Load();

            Adddanhmucbinding();
            Addsanphambinding();
            Addstaffbinding();
            AddClientbinding();
        }
        void QuanLy_Load()
        {
            LoadListCategory();
            LoadListStaff();
            LoadListItems();
            LoadListClient();
            LoadListReportDoanhthu();
        }
        void LoadListClient()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            DataRow row = dt.NewRow();
            dt.Columns.Add("ID");
            dt.Columns.Add("Name");
            row["ID"] = "Nam";
            row["Name"] = "Nam";
            dt.Rows.Add(row);
            DataRow rows = dt.NewRow();
            rows["ID"] = "Nữ";
            rows["Name"] = "Nữ";
            dt.Rows.Add(rows);
            cbbsex.DataSource = dt;
            cbbsex.DisplayMember = "Name";
            ClientList.DataSource = ClientDAO.Instance.GetListClient();
        }
        void AddClientbinding()
        {
            txtidkh.DataBindings.Add(new Binding("Text", datagvclient.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txttenkh.DataBindings.Add(new Binding("Text", datagvclient.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txtsdtkh.DataBindings.Add(new Binding("Text", datagvclient.DataSource, "SDT", true, DataSourceUpdateMode.Never));
            txtemail.DataBindings.Add(new Binding("Text", datagvclient.DataSource, "Email", true, DataSourceUpdateMode.Never));
            txtdiachi.DataBindings.Add(new Binding("Text", datagvclient.DataSource, "Address", true, DataSourceUpdateMode.Never));
        }
        void LoadListStaff()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            DataRow row = dt.NewRow();
            dt.Columns.Add("ID");
            dt.Columns.Add("Name");
            row["ID"] = 1;
            row["Name"] = "Admin";
            dt.Rows.Add(row);
            DataRow rows = dt.NewRow();
            rows["ID"] = 2;
            rows["Name"] = "Nhân viên";
            dt.Rows.Add(rows);
            cbbcv.DataSource = dt;
            cbbcv.DisplayMember = "Name";
            StaffList.DataSource = AccountDAO.Instance.GetListStaff();
            this.datagvStaff.Columns["Password"].Visible = false;
        }
        void Addstaffbinding()
        {
            txtidstaff.DataBindings.Add(new Binding("Text", datagvStaff.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txtnamestaff.DataBindings.Add(new Binding("Text", datagvStaff.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txtaccountstaff.DataBindings.Add(new Binding("Text", datagvStaff.DataSource, "Accounts", true, DataSourceUpdateMode.Never));
        }

        void LoadListReportDoanhthu()
        {
            datareport_doanhthu.DataSource = ReportDAO.Instance.GetListDoanhThu();
        }
        void LoadListItems()
        {
            ItemsList.DataSource = ItemsDAO.Instance.GetListItems();
            this.datagvSP.Columns["image"].Visible = false;
        }
        void LoadListCategory()
        {
            CategoryList.DataSource = CategoryDAO.Instance.GetListCategory();
        }
        void Adddanhmucbinding()
        {
            txtiddm.DataBindings.Add(new Binding("Text", datagvDM.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txttendm.DataBindings.Add(new Binding("Text", datagvDM.DataSource, "Name", true, DataSourceUpdateMode.Never));
        }

        void Addsanphambinding()
        {
            txtidsp.DataBindings.Add(new Binding("Text", datagvSP.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txttensp.DataBindings.Add(new Binding("Text", datagvSP.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txtprice.DataBindings.Add(new Binding("Text", datagvSP.DataSource, "Price", true, DataSourceUpdateMode.Never));
            txtnote.DataBindings.Add(new Binding("Text", datagvSP.DataSource, "note", true, DataSourceUpdateMode.Never));
            imgsp.DataBindings.Add(new Binding("Image", datagvSP.DataSource, "avatar", true, DataSourceUpdateMode.Never));
        }
        private void button20_Click(object sender, EventArgs e)
        {
            fImportDetail f = new fImportDetail();
            f.ShowDialog();
        }

       

        private void btnthem_Click(object sender, EventArgs e)
        {
            string name = txttendm.Text;
            if (CategoryDAO.Instance.InsertCategory(name))
            {
                MessageBox.Show("Thêm danh mục thành công");
                LoadListCategory();
                //if (insertFood != null)
                //    insertFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm danh mục");
            }
        }

        private void bntsua_Click(object sender, EventArgs e)
        {
            string name = txttendm.Text;
            string id = txtiddm.Text;

            if (CategoryDAO.Instance.UpdateCategory(id, name))
            {
                MessageBox.Show("Sửa danh mục thành công");
                LoadListCategory();
                //if (updateFood != null)
                //    updateFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa danh mục");
            }
        }

        private void bntxoa_Click(object sender, EventArgs e)
        {
            string id = txtiddm.Text;

            if (CategoryDAO.Instance.DeleteCategory(id))
            {
                MessageBox.Show("Xóa danh mục thành công");
                LoadListCategory();
                //if (deleteFood != null)
                //    deleteFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa danh mục");
            }
        }

        private void btnthemsanpham_Click(object sender, EventArgs e)
        {
            if (txttensp.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên sản phẩm");
                return;
            }
            if (txtprice.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập giá sản phẩm");
                return;
            }
            if (txtprice.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập giá sản phẩm");
                return;
            }
            string selectedIndex = cbbdmsp.SelectedValue.ToString();
            if (ItemsDAO.Instance.InsertItems(txttensp.Text, txtnote.Text, selectedIndex, int.Parse(txtprice.Text), txtstock_mini.Text, txtlinkhinh.Text))
            {
                LoadListItems();
                datagvSP.Update();
                datagvSP.Refresh();
                MessageBox.Show("Thêm sản phẩm thành công");
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm sản phẩm");
            }
        }

        private void btnsuasanpham_Click(object sender, EventArgs e)
        {
            if (txttensp.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên sản phẩm");
                return;
            }
            if (txtprice.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập giá sản phẩm");
                return;
            }
            if (txtprice.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập giá sản phẩm");
                return;
            }
            string selectedIndex = cbbdmsp.SelectedValue.ToString();
            if (ItemsDAO.Instance.UpdateItems(txttensp.Text, txtnote.Text, selectedIndex, int.Parse(txtprice.Text), txtstock_mini.Text, txtidsp.Text))
            {
                if (txtlinkhinh.Text != "")
                {
                    string FileName = Session.RandomString(5) + "_" + Path.GetFileName(txtlinkhinh.Text);
                    File.Copy(txtlinkhinh.Text, @"img\" + FileName, true);
                    ItemsDAO.Instance.UpdateImage(FileName, txtidsp.Text);
                }
                LoadListItems();
                datagvSP.Update();
                datagvSP.Refresh();
                MessageBox.Show("Sửa sản phẩm thành công");
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa sản phẩm");
            }
        }

        private void btnxoasp_Click(object sender, EventArgs e)
        {
            string id = txtidsp.Text;
            if (MessageBox.Show("Bạn có muốn xóa", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (ItemsDAO.Instance.DeleteSP(id))
                {
                    MessageBox.Show("Xóa sản phẩm thành công");
                    LoadListItems();
                    datagvSP.Update();
                    datagvSP.Refresh();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi xóa sản phẩm");
                }
            }
        }

        private void bntxempos_Click(object sender, EventArgs e)
        {
            int id = datareport_doanhthu.CurrentCell.RowIndex;
            string ld = datareport_doanhthu.Rows[id].Cells[0].Value.ToString();
            string discount = datareport_doanhthu.Rows[id].Cells[5].Value.ToString();
            string client = datareport_doanhthu.Rows[id].Cells[1].Value.ToString();


            if (OrderDAO.Instance.GetImportByID(ld) == false)
            {
                MessageBox.Show("Đơn hàng không tồn tại");
            }
            else
            {
                fPosDetail f = new fPosDetail(ld, discount, client);
                f.ShowDialog();
            }
        }

        private void btnxoarongnv_Click(object sender, EventArgs e)
        {
            txtnamestaff.Text = "";
            txtmknv.Text = "";
            txtaccountstaff.Text = "";
            txtidstaff.Text = "";
        }

        private void btnthemnv_Click(object sender, EventArgs e)
        {
            if (txtnamestaff.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên nhân viên");
                return;
            }
            if (txtaccountstaff.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập account nhân viên");
                return;
            }
            if (txtmknv.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu nhân viên");
                return;
            }
            int selectedIndex = cbbcv.SelectedIndex;
            int selectedValue = 2;
            if (selectedIndex == 0)
            {
                selectedValue = 1;
            }
            if (AccountDAO.Instance.AddAccount_main(txtnamestaff.Text, Session.GetMD5(txtmknv.Text), txtaccountstaff.Text, selectedValue))
            {
                LoadListStaff();
                datagvStaff.Update();
                datagvStaff.Refresh();
                MessageBox.Show("Thêm thành công");
                //if (updateAccount != null)
                //{
                //    updateAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(LoginAccount.Accounts)));
                //}
            }
        }

        private void bntsuanv_Click(object sender, EventArgs e)
        {
            if (txtidstaff.Text == "")
            {
                MessageBox.Show("Vui lòng chọn lại nhân viên cần sửa");
                return;
            }
            if (txtnamestaff.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên nhân viên");
                return;
            }
            if (txtaccountstaff.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập account nhân viên");
                return;
            }
            int selectedIndex = cbbcv.SelectedIndex;
            int selectedValue = 2;
            if (selectedIndex == 0)
            {
                selectedValue = 1;
            }
            if (txtmknv.Text != "" && txtmknv.Text != null)
            {
                if (AccountDAO.Instance.UpdateAccount_main(txtnamestaff.Text, Session.GetMD5(txtmknv.Text), txtaccountstaff.Text, selectedValue, int.Parse(txtidstaff.Text)))
                {
                    LoadListStaff();
                    datagvStaff.Update();
                    datagvStaff.Refresh();
                    MessageBox.Show("Cập nhật thành công");
                    //if (updateAccount != null)
                    //{
                    //    updateAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(LoginAccount.Accounts)));
                    //}
                }
            }
            else
            {

                if (AccountDAO.Instance.UpdateAccount_main_nopass(txtnamestaff.Text, txtaccountstaff.Text, selectedValue, int.Parse(txtidstaff.Text)))
                {
                    LoadListStaff();
                    datagvStaff.Update();
                    datagvStaff.Refresh();
                    MessageBox.Show("Cập nhật thành công");
                }
            }
        }

        private void bntxoanv_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtidstaff.Text);
            if (id == loginAccount.ID)
            {
                MessageBox.Show("Bạn không thể xóa bạn");
                return;
            }
            if (AccountDAO.Instance.DeleteNV(id))
            {
                MessageBox.Show("Xóa nhân viên thành công");
                LoadListStaff();
                datagvStaff.Update();
                datagvStaff.Refresh();
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa nhân viên");
            }
        }

        private void bntxoarongkh_Click(object sender, EventArgs e)
        {
            txttenkh.Text = "";
            txtsdtkh.Text = "";
            txtemail.Text = "";
            txtdiachi.Text = "";
            txtidkh.Text = "";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (txtsdtkh.Text == "" || txttenkh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên hoặc số điện thoại");
            }
            else
            {
                if (ClientDAO.Instance.GetItemsByID(txtsdtkh.Text) == null)
                {
                    if (ClientDAO.Instance.InsertClient(txttenkh.Text, txtsdtkh.Text, txtemail.Text, txtdiachi.Text, cbbsex.Text))
                    {
                        MessageBox.Show("Thêm thành công");
                        LoadListClient();
                        datagvclient.Update();
                        datagvclient.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("Thêm không thành công");
                    }
                }
                else
                {
                    MessageBox.Show("Số điện thoại đã tồn tại");
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (txtsdtkh.Text == "" || txttenkh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên hoặc số điện thoại");
                return;
            }
            if (ClientDAO.Instance.UpdateClient(txttenkh.Text, txtsdtkh.Text, txtemail.Text, txtdiachi.Text, cbbsex.Text, txtidkh.Text))
            {
                MessageBox.Show("Sửa thành công");
                LoadListClient();
                datagvclient.Update();
                datagvclient.Refresh();
            }
            else
            {
                MessageBox.Show("Sửa không thành công");
            }
        }

        private void bntxoakh_Click(object sender, EventArgs e)
        {
            string id = txtidkh.Text;
            if (MessageBox.Show("Bạn có muốn xóa", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (ClientDAO.Instance.DeleteKH(id))
                {
                    MessageBox.Show("Xóa khách hàng thành công");
                    LoadListClient();
                    datagvclient.Update();
                    datagvclient.Refresh();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi xóa khách hàng");
                }
            }
        }
    }
}
