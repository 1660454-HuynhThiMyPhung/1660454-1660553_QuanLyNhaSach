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
        BindingSource ImportList = new BindingSource();
        BindingSource ReportStockList = new BindingSource();

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
            imgsp.SizeMode = PictureBoxSizeMode.StretchImage;
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
            dategvImport.DataSource = ImportList;
            datareport_stock.DataSource = ReportStockList;

            QuanLy_Load();

            Adddanhmucbinding();
            Addsanphambinding();
            Addstaffbinding();
            AddClientbinding();
            LoadCategoryIntoCombobox(cbbdmsp);
        }
        void LoadCategoryIntoCombobox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "Name";
            cb.ValueMember = "ID";
        }
        void QuanLy_Load()
        {
            LoadListCategory();
            LoadListStaff();
            LoadListItems();
            LoadListClient();
            LoadListImport();
            LoadListReportDoanhthu();
            LoadListReportStock();

        }
        void LoadListReportStock()
        {
            ReportStockList.DataSource = ReportDAO.Instance.GetListItems();
            this.datareport_stock.Columns["image"].Visible = false;
        }
        void LoadListImport()
        {
            dategvImport.AutoGenerateColumns = false;
            ImportList.DataSource = ImportDAO.Instance.GetListImport();
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Tác vụ";
            btn.Text = "Xóa";
            btn.Name = "btn";
            btn.DisplayIndex = 5;
            btn.UseColumnTextForButtonValue = true;
            int columnIndex = 5;
            if (dategvImport.Columns["btn"] == null)
            {
                dategvImport.Columns.Insert(columnIndex, btn);
            }
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
            ccblocnv.DataSource = AccountDAO.Instance.GetListStaff();
            ccblocnv.DisplayMember = "UserName";
            ccblocnv.ValueMember = "ID";
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
            fImportDetail f = new fImportDetail("0", "");
            f.FormClosed += F_FormClosed;
            f.ShowDialog();
        }
        private void F_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadListImport();
            dategvImport.Update();
            dategvImport.Refresh();
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
            if (MessageBox.Show("Bạn có muốn xóa", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (!CategoryDAO.Instance.TestDM(id))
                {
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
                else
                {
                    MessageBox.Show("Danh mục đã được sử dụng không thể xóa");
                }
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
                if (!ItemsDAO.Instance.TestSP(id))
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
                else
                {
                    MessageBox.Show("Sản phẩm đã được sử dụng không thể xóa");
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
            if (MessageBox.Show("Bạn có muốn xóa", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (!AccountDAO.Instance.TestNV(id))
                {
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
                else
                {
                    MessageBox.Show("Nhân viên đã có dữ liệu bán hàng không thể xóa");
                }
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
                if (!ClientDAO.Instance.TestKH(id))
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
                else
                {
                    MessageBox.Show("Khách hàng đã mua hàng không thể xóa");
                }
            }
        }

        private void btnview_import_Click(object sender, EventArgs e)
        {
            int id = dategvImport.CurrentCell.RowIndex;
            string ld = dategvImport.Rows[id].Cells[0].Value.ToString();
            fImportDetail f = new fImportDetail("3", ld);
            f.ShowDialog();
        }

        private void dategvImport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                string id = dategvImport.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                string idd = dategvImport.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (id == "Chưa Duyệt")
                {
                    if (MessageBox.Show("Bạn có muốn duyệt phiếu", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        if (ImportDAO.Instance.Comgim_import(idd, "+"))
                        {
                            MessageBox.Show("Duyệt thành công");
                            LoadListImport();
                            dategvImport.Update();
                            dategvImport.Refresh();

                            LoadListItems();
                            datagvSP.Update();
                            datagvSP.Refresh();

                            LoadListReportStock();
                            datareport_stock.Update();
                            datareport_stock.Refresh();
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi khi duyệt");
                        }
                    }
                }
                if (id == "Đã Duyệt")
                {
                    if (MessageBox.Show("Bạn có muốn bỏ duyệt phiếu", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        if (ImportDAO.Instance.Comgim_import(idd, "-"))
                        {
                            MessageBox.Show("Bỏ duyệt thành công");
                            LoadListImport();
                            dategvImport.Update();
                            dategvImport.Refresh();

                            LoadListItems();
                            datagvSP.Update();
                            datagvSP.Refresh();

                            LoadListReportStock();
                            datareport_stock.Update();
                            datareport_stock.Refresh();
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi khi bỏ duyệt");
                        }
                    }
                }
            }
            if (e.ColumnIndex == 5)
            {
                string id = dategvImport.Rows[e.RowIndex].Cells[3].Value.ToString();
                if (id == "Đã Duyệt")
                {
                    MessageBox.Show("Phiếu đã duyệt không thể xóa!");
                }
                else
                {
                    if (MessageBox.Show("Bạn có muốn xóa phiếu", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        string idd = dategvImport.Rows[e.RowIndex].Cells[0].Value.ToString();
                        if (ImportDAO.Instance.delete_import(idd))
                        {
                            MessageBox.Show("Xóa thành công");
                            LoadListImport();
                            dategvImport.Update();
                            dategvImport.Refresh();
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi khi xóa phiếu nhập");
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string kh = txtsearchsdttenkh.Text;
            string nv = ccblocnv.SelectedValue.ToString();
            string datestart = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string dateend = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            datareport_doanhthu.DataSource = ReportDAO.Instance.GetListDoanhThu(kh, nv, datestart, dateend);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            datareport_doanhthu.DataSource = ReportDAO.Instance.GetListDoanhThu();

        }

        private void btnsearchreportstock_Click(object sender, EventArgs e)
        {
            string item = txtimitemsreportstock.Text;
            ReportStockList.DataSource = ReportDAO.Instance.GetListItems(item);
            this.datareport_stock.Columns["image"].Visible = false;
        }

        private void bntlocimport_Click(object sender, EventArgs e)
        {
            string item = txtitemsimport.Text;
            string datestart = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string dateend = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            dategvImport.AutoGenerateColumns = false;
            ImportList.DataSource = ImportDAO.Instance.GetListImport(item, datestart, dateend);
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Tác vụ";
            btn.Text = "Xóa";
            btn.Name = "btn";
            btn.DisplayIndex = 5;
            btn.UseColumnTextForButtonValue = true;
            int columnIndex = 5;
            if (dategvImport.Columns["btn"] == null)
            {
                dategvImport.Columns.Insert(columnIndex, btn);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dategvImport.AutoGenerateColumns = false;
            ImportList.DataSource = ImportDAO.Instance.GetListImport();
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Tác vụ";
            btn.Text = "Xóa";
            btn.Name = "btn";
            btn.DisplayIndex = 5;
            btn.UseColumnTextForButtonValue = true;
            int columnIndex = 5;
            if (dategvImport.Columns["btn"] == null)
            {
                dategvImport.Columns.Insert(columnIndex, btn);
            }
        }

        private void bntimsach_Click(object sender, EventArgs e)
        {
            string timsach = txttimsach.Text;
            ItemsList.DataSource = ItemsDAO.Instance.GetListItems(timsach);
            this.datagvSP.Columns["image"].Visible = false;
        }

        private void bntxoarongsp_Click(object sender, EventArgs e)
        {
            txtidsp.Text = "";
            txttensp.Text = "";
            txtprice.Text = "";
            txtnote.Text = "";

            imgsp.Image = null;
            imgsp.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *png)| *.jpg; *.jpeg; *png;";
            if (open.ShowDialog() == DialogResult.OK)
            {
                txtlinkhinh.Text = open.FileName;
                imgsp.Image = new Bitmap(open.FileName);
            }
        }

        private void bnttimkhachhang_Click(object sender, EventArgs e)
        {
            string name = txttimkiemkh.Text;
            ClientList.DataSource = ClientDAO.Instance.GetListClient(name);

        }

        private void bntimnv_Click(object sender, EventArgs e)
        {
            string txttimn = txttimnv.Text;
            StaffList.DataSource = AccountDAO.Instance.GetListStaff(txttimn);
            this.datagvStaff.Columns["Password"].Visible = false;
        }
    }
}
