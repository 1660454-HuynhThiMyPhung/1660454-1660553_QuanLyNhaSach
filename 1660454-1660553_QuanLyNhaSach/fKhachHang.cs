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
    public partial class fKhachHang : Form
    {
        public fKhachHang()
        {
            InitializeComponent();
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            if (sdtkh.Text == "" || tenkh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên hoặc số điện thoại");
            }
            else
            {
                if (ClientDAO.Instance.GetItemsByID(sdtkh.Text) == null)
                {
                    if (ClientDAO.Instance.InsertClient(tenkh.Text, sdtkh.Text, egmailkh.Text, dckh.Text, cbgtkh.Text))
                    {
                        MessageBox.Show("Thêm thành công");
                        if (updateClient != null)
                        {
                            updateClient(this, new ClientEvent(ClientDAO.Instance.GetItemsByID(sdtkh.Text)));
                        }
                        this.Close();
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
        private event EventHandler<ClientEvent> updateClient;
        public event EventHandler<ClientEvent> UpdateClient
        {
            add { updateClient += value; }
            remove { updateClient -= value; }
        }
    }
    public class ClientEvent : EventArgs
    {
        private Client clients;

        internal Client Clients { get => clients; set => clients = value; }
        public ClientEvent(Client clients)
        {
            this.Clients = clients;
        }
    }
}
