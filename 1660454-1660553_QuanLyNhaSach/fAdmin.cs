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
    public partial class fAdmin : Form
    {
        BindingSource CategoryList = new BindingSource();

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
            QuanLy_Load();

            Adddanhmucbinding();
        }
        void QuanLy_Load()
        {
            LoadListCategory();
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
        private void button20_Click(object sender, EventArgs e)
        {
            fImportDetail f = new fImportDetail();
            f.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {

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
    }
}
