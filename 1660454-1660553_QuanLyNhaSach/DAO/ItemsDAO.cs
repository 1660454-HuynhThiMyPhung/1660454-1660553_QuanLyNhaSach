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
    class ItemsDAO
    {
        private static ItemsDAO instance;

        internal static ItemsDAO Instance { get { if (instance == null) instance = new ItemsDAO(); return ItemsDAO.instance; } set => ItemsDAO.instance = value; }
    
        private ItemsDAO() { }

        public List<Items> GetListItems(string id = "")
        {
            List<Items> list = new List<Items>();
            string text = "";
            if (id != "")
            {
                text += " where San_Pham.Ten_SP LIKE N'%" + id + "%'";
            }
            string query = "select * from San_Pham " + text;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            data.Columns.Add("avatar", Type.GetType("System.Byte[]"));
            foreach (DataRow item in data.Rows)
            {
                string url = @"img\none.jpg";
                if ((item["image"].ToString() != ""))
                {
                    url = @"img\" + item["image"].ToString();
                }
                item["avatar"] = File.ReadAllBytes(url);
                item["image"] = url;

                Items sp = new Items(item);
                list.Add(sp);
            }

            return list;
        }
        public Items GetItemsByID(string id)
        {
            Items items = null;

            string query = "select * from San_Pham where (Ma_SP = '" + id + "' or Ten_SP = '" + id + "')";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            data.Columns.Add("avatar", Type.GetType("System.Byte[]"));

            foreach (DataRow item in data.Rows)
            {
                string url = @"img\none.jpg";
                if (item["image"].ToString() != "")
                {
                    url = @"img\" + item["image"].ToString();
                }
                item["avatar"] = File.ReadAllBytes(url);

                items = new Items(item);
                return items;
            }

            return items;
        }

        
        public List<Items> GetListItemsByName(string id)
        {
            List<Items> list = new List<Items>();

            //string query = "select * from San_Pham";
            string query = "select * from San_Pham where (Ma_SP LIKE '%" + id + "%' or Ten_SP LIKE '%" + id + "%')";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            data.Columns.Add("avatar", Type.GetType("System.Byte[]"));
            foreach (DataRow item in data.Rows)
            {
                string url = @"img\none.jpg";
                if (item["image"].ToString() != "")
                {
                    url = @"img\" + item["image"].ToString();
                }
                item["avatar"] = File.ReadAllBytes(url);
                item["image"] = url;

                Items sp = new Items(item);
                list.Add(sp);
            }

            return list;
        }
        public bool InsertItems(string name, string note, string Ma_DM, int Price, string stock_mini,string txtlinkhinh)
        {
            string id = ItemsDAO.Instance.Getprefix();
            string query = string.Format("INSERT into San_Pham values ('" + id + "',N'" + name + "',NULL,N'" + note + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + Ma_DM + "','" + Price + "',0,'" + stock_mini + "')");
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            if (txtlinkhinh != "")
            {
                string FileName = Session.RandomString(5) + "_" + Path.GetFileName(txtlinkhinh);
                File.Copy(txtlinkhinh, @"img\" + FileName, true);
                DataProvider.Instance.ExecuteNonQuery("UPDATE San_Pham set Image = '" + FileName + "' where Ma_SP = '" + id + "'");
            }
            return result > 0;
        }
        public bool UpdateItems(string name, string note, string Ma_DM, int Price, string stock_mini,string id)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("UPDATE San_Pham set Ten_SP = N'" + name + "',Note = N'" + note + "',Ma_DM = N'" + Ma_DM + "',Price = N'" + Price + "',stock_mini = N'" + stock_mini + "' where Ma_SP = '" + id + "'");
            return result > 0;
        }
        public bool UpdateImage(string image, string id)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("UPDATE San_Pham set Image = '" + image + "' where Ma_SP = '" + id + "'");
            return result > 0;
        }
        public bool DeleteSP(string id)
        {
            string query = string.Format("Delete San_Pham where Ma_SP = '" + id + "'");
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool TestSP(string id)
        {
            string query = "select * from SO_detail where MA_SP = '" + id + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            if(data.Rows.Count > 0)
            {
                return true;
            }
            string querys = "select * from ImportDetail where MA_SP = '" + id + "'";
            DataTable datas = DataProvider.Instance.ExecuteQuery(querys);
            if (datas.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public string Getprefix()

        {
            string query = "select * from San_Pham";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            string g = "";

            if ((data.Rows.Count <= 0))
            {
                return "SP01";
            }
            else
            {
                int k;
                g = "SP";
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
