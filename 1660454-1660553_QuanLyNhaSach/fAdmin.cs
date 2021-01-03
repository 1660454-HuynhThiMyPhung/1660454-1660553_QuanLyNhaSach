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


        public fAdmin()
        {
            InitializeComponent();
            load();
        }

        private void fAdmin_Load(object sender, EventArgs e)
        {
        }
        void load()
        {
            datagvDM.DataSource = CategoryList;
            datagvSP.DataSource = ItemsList;

            QuanLy_Load();

            Adddanhmucbinding();
            Addsanphambinding();

        }
        void QuanLy_Load()
        {
            LoadListCategory();
            LoadListItems();
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
    }
}
