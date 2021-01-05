using _1660454_1660553_QuanLyNhaSach.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1660454_1660553_QuanLyNhaSach.DAO
{
    class ImportDAO
    {
        private static ImportDAO instance;

        public static ImportDAO Instance
        {
            get { if (instance == null) instance = new ImportDAO(); return instance; }
            private set { instance = value; }
        }
        private ImportDAO() { }
        public bool Comgim_import(string id, string action)
        {

            string query = "select SoLuong,MA_SP from ImportDetail where id_import = '" + id + "'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                if (action == "+")
                {
                    DataProvider.Instance.ExecuteNonQuery("UPDATE San_Pham set stock = (stock + '" + item["SoLuong"] + "') where MA_SP = '" + item["MA_SP"] + "'");
                }
                else
                {
                    DataProvider.Instance.ExecuteNonQuery("UPDATE San_Pham set stock = (stock - '" + item["SoLuong"] + "') where MA_SP = '" + item["MA_SP"] + "'");
                }
            }
            if (action == "+")
            {
                DataProvider.Instance.ExecuteNonQuery("UPDATE Imports set confim_import = N'Đã Duyệt' where ID = '" + id + "'");
            }
            else
            {
                DataProvider.Instance.ExecuteNonQuery("UPDATE Imports set confim_import = N'Chưa Duyệt' where ID = '" + id + "'");

            }
            return true;
        }
        public List<Import> GetListImport()
        {
            List<Import> list = new List<Import>();

            string query = "select * from Imports";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Import import = new Import(item);
                list.Add(import);
            }

            return list;
        }
        public Import GetImportByID(string id)
        {
            Import import = null;

            string query = "select * from Imports where ID = '" + id + "'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                import = new Import(item);
                return import;
            }

            return import;
        }
        public List<ItemImport> GetImportDetailByID(string id)
        {
            List<ItemImport> list = new List<ItemImport>();

            string query = "select ide.SoLuong,ide.Gia,ide.MA_SP,ps.Ten_SP,ps.Image from ImportDetail ide,San_Pham ps where ide.MA_SP = ps.Ma_SP AND ide.id_import = '" + id + "'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            int dem = 0;
            foreach (DataRow item in data.Rows)
            {
                dem++;
                string url = @"img\none.jpg";
                if (item["image"].ToString() != "")
                {
                    url = @"img\" + item["image"].ToString();
                }
                Byte[] avatar = File.ReadAllBytes(url);
                ItemImport import = new ItemImport(dem, avatar, item["MA_SP"].ToString(), item["Ten_SP"].ToString(), int.Parse(item["SoLuong"].ToString()), int.Parse(item["Gia"].ToString()), (int.Parse(item["SoLuong"].ToString()) * int.Parse(item["Gia"].ToString())));
                list.Add(import);
            }
            return list;
        }
        public bool InsertImport(List<ItemImport> list, string note)
        {
            string id = ImportDAO.Instance.Getprefix();
            string query = string.Format("INSERT into Imports values ('" + id + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + 0 + "',N'" + note + "',N'Chưa Duyệt')");
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            int total = 0;
            foreach (var item in list)
            {
                query = string.Format("INSERT into ImportDetail values ('" + id + "','" + item.id_items + "','" + item.Quanliti + "','" + item.price + "')");
                DataProvider.Instance.ExecuteNonQuery(query);
                total += item.totalSub;
            }
            DataProvider.Instance.ExecuteNonQuery("UPDATE Imports set total = '" + total + "' where ID = '" + id + "'");
            return result > 0;
        }
        public bool delete_import(string id)
        {
            string query = string.Format("Delete Imports where ID = '" + id + "'");
            DataProvider.Instance.ExecuteNonQuery(query);
            string querys = string.Format("Delete ImportDetail where id_import = '" + id + "'");
            int result = DataProvider.Instance.ExecuteNonQuery(querys);
            return result > 0;
        }
        public string Getprefix()

        {
            string query = "select * from Imports";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            string g = "";

            if ((data.Rows.Count <= 0))
            {
                return "NK01";
            }
            else
            {
                int k;
                g = "NK";
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
