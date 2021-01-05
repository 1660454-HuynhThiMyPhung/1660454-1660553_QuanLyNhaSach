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
    public partial class fImportDetail : Form
    {
        string check = "0";
        string id = "0";
        public fImportDetail(string edit, string ids)
        {
            check = edit;
            id = ids;


            InitializeComponent();
        }
        List<ItemImport> list_items = new List<ItemImport>();
        Items items_detail;
        int id_detail = 1;
        private void fImportDetail_Load(object sender, EventArgs e)
        {
            //LV PROPERTIES
            listView1.View = View.Details;

            //CONSTRUCT COLUMNS
            listView1.Columns.Add("IMG", 33);
            listView1.Columns.Add("Mã SP", 50);
            listView1.Columns.Add("Tên SP", 95);
            listView1.FullRowSelect = true;
            if (check == "3")
            {
                listView1.Enabled = false;
                save.Enabled = false;
            }
            populate();
            if (check == "3")
            {
                Import import = ImportDAO.Instance.GetImportByID(id);
                if (import == null)
                {
                    MessageBox.Show("Phieu nhap khong ton tai");
                    this.Close();
                }
                else
                {
                    txtnote.Text = import.note;
                    list_items = ImportDAO.Instance.GetImportDetailByID(id);
                }
            }
            LoadDetail();
        }
        private void populate()
        {
            ImageList imgs = new ImageList();
            imgs.ImageSize = new Size(30, 30);
            List<Items> list = new List<Items>();
            list = ItemsDAO.Instance.GetListItems();
            int dem = 0;
            foreach (var path in list)
            {
                imgs.Images.Add(Image.FromFile(path.image));
                ListViewItem lvi = new ListViewItem();
                lvi.SubItems.Add(path.ID);
                lvi.SubItems.Add(path.name.TrimEnd());
                lvi.ImageIndex = dem;
                listView1.Items.Add(lvi);
                dem++;
            }
            listView1.SmallImageList = imgs;
        }
        void LoadDetail()
        {
            BindingSource source = new BindingSource();
            source.DataSource = list_items;
            datadetailimport.DataSource = source;
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Tác vụ";
            btn.Text = "Xóa";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;

            int columnIndex = 0;
            if (datadetailimport.Columns["btn"] == null)
            {
                datadetailimport.Columns.Insert(columnIndex, btn);
            }
            datadetailimport.Refresh();
            this.datadetailimport.Columns["avatar"].Visible = false;

        }

        private void bntthemitemsimport_Click(object sender, EventArgs e)
        {
            if (tonggian.Text == "" || slnhap.Text == "" || listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Bạn chưa nhập số lượng hoặc giá nhập hoặc mặt hàng");

            }
            else
            {
                String selected = listView1.SelectedItems[0].SubItems[1].Text;
                items_detail = ItemsDAO.Instance.GetItemsByID(selected);
                if (items_detail != null)
                {
                    ItemImport import = new ItemImport(id_detail, items_detail.avatar, items_detail.ID, items_detail.name, int.Parse(slnhap.Text), int.Parse(tonggian.Text), (int.Parse(slnhap.Text) * int.Parse(tonggian.Text)));
                    tonggian.Text = "";
                    slnhap.Text = "";
                    list_items.Add(import);
                    LoadDetail();
                    id_detail++;
                }
            }
        }

        private void bnttimitems_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView1.Refresh();
            ImageList imgs = new ImageList();
            imgs.ImageSize = new Size(30, 30);
            List<Items> list = new List<Items>();
            list = ItemsDAO.Instance.GetListItemsByName(txtsearch.Text);
            int dem = 0;
            foreach (var path in list)
            {
                imgs.Images.Add(Image.FromFile(path.image));
                ListViewItem lvi = new ListViewItem();
                lvi.SubItems.Add(path.ID);
                lvi.SubItems.Add(path.name.TrimEnd());
                lvi.ImageIndex = dem;
                listView1.Items.Add(lvi);
                dem++;
            }
            listView1.SmallImageList = imgs;
            listView1.Refresh();
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (ImportDAO.Instance.InsertImport(list_items, txtnote.Text))
            {
                MessageBox.Show("Thêm nhập hàng thành công");
                this.Close();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm nhập hàng");
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
