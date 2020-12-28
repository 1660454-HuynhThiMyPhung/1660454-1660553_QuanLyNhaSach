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
        public fAdmin()
        {
            InitializeComponent();
    
        }

        private void fAdmin_Load(object sender, EventArgs e)
        {
        }

        private void button20_Click(object sender, EventArgs e)
        {
            fImportDetail f = new fImportDetail();
            f.ShowDialog();
        }
    }
}
