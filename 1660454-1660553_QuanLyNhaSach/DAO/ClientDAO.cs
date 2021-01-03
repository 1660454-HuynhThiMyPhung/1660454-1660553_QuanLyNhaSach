using _1660454_1660553_QuanLyNhaSach.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1660454_1660553_QuanLyNhaSach.DAO
{
    class ClientDAO
    {
        private static ClientDAO instance;

        public static ClientDAO Instance
        {
            get { if (instance == null) instance = new ClientDAO(); return ClientDAO.instance; }
            private set { ClientDAO.instance = value; }
        }
        private ClientDAO() { }

        public Client GetItemsByID(string sdt)
        {
            Client clients = null;
            string query = "select * from Khach_Hang where SDT_KH = '" + sdt + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                clients = new Client(item);
                return clients;
            }
            return clients;
        }
        public bool InsertClient(string name, string sdt, string email, string address, string sex)
        {
            string id = ClientDAO.Instance.Getprefix();
            string query = string.Format("INSERT into Khach_Hang values ('" + id + "',N'" + name + "',N'" + sdt + "',0,N'" + address + "',N'" + sex + "',N'" + email + "')");
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public string Getprefix()

        {
            string query = "select * from Khach_Hang";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            string g = "";

            if ((data.Rows.Count <= 0))
            {
                return "KH01";
            }
            else
            {
                int k;
                g = "KH";
                k = Convert.ToInt32(data.Rows[data.Rows.Count - 1][0].ToString().Substring(2, 2));
                k = k + 1;
                if (k <= 9)
                {
                    g = g + "0";
                    g = g + k.ToString();
                }
                else
                {
                    g = g + k.ToString();
                }
                return g;
            }
        }
    }
}
