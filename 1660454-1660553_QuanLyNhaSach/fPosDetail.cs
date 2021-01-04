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
    public partial class fPosDetail : Form
    {
        string idd = "";
        string clienta = "";
        string discounts = "1";
        int S, Q, W;
        int lm1, a1, c1;
        double tongtien, d1, cc;
        int id_detail = 1;
        List<POS> list_items = new List<POS>();
        Items items_detail;
        Client clients;

        public fPosDetail(string id, string discount, string client)
        {
            InitializeComponent();
            idd = id;
            clienta = client;
            discounts = discount;
            clients = ClientDAO.Instance.GetItemsByIDs(client);
            ltenKH.Text = clients.Name;
            lsex.Text = clients.Sex;
            laddress.Text = clients.Address;
            lemailKH.Text = clients.Email;
            txtdiem.Text = clients.Diem.ToString();
            txtso.Text = id;
        }
        void LoadPOS()
        {
            BindingSource source = new BindingSource();
            source.DataSource = list_items;
            hienCTdonhang.DataSource = source;
            tongtien = 0;
            foreach (var item in list_items)
            {
                tongtien += item.price * item.Quanliti;
            }
            tongtienpos.Text = tongtien.ToString();
            discountpos.Text = (tongtien * (double.Parse(discounts) / 100f)).ToString();
            txtthanhtien.Text = (tongtien - (tongtien * (double.Parse(discounts) / 100f))).ToString();
        }

        private void fPosDetail_Load(object sender, EventArgs e)
        {

            list_items = OrderDAO.Instance.GetListDetailPOS(idd);
            LoadPOS();
        }
    }
}
