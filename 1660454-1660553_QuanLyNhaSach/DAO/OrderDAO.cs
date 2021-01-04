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
    class OrderDAO
    {
        private static OrderDAO instance;

        public static OrderDAO Instance
        {
            get { if (instance == null) instance = new OrderDAO(); return instance; }
            private set { instance = value; }
        }
        public bool InsertOrder(List<POS> list, Account LoginAccount, Client clients)
        {
            int discount = Session.discount;
            string client = clients.ID;
            int ID_NV = LoginAccount.ID;

            string id = OrderDAO.Instance.Getprefix();
            string query = string.Format("INSERT into Don_Hang values ('" + id + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + client + "','" + discount + "',0,0,'" + ID_NV.ToString() + "')");
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            int total = 0;
            foreach (var item in list)
            {
                query = string.Format("INSERT into SO_detail values ('" + id + "','" + item.id_items + "','" + item.Quanliti + "','" + item.price + "','" + (item.Quanliti * item.price) + "')");
                DataProvider.Instance.ExecuteNonQuery(query);

                DataProvider.Instance.ExecuteNonQuery("UPDATE San_Pham set stock = (stock - " + item.Quanliti + ") where Ma_SP = '" + item.id_items + "'");

                total += item.Quanliti * item.price;
            }
            int discountpos = (int)(((total * (discount / 100f))));
            total = total - discountpos;
            DataProvider.Instance.ExecuteNonQuery("UPDATE Don_Hang set total = '" + total + "',total_discount = '" + discountpos + "' where ID = '" + id + "'");
            int dem = total / 1000;
            DataProvider.Instance.ExecuteNonQuery("UPDATE Khach_Hang set DIEM = (DIEM + " + dem + ") where Ma_KH = '" + client + "'");

            return result > 0;
        }
        public bool GetImportByID(string id)
        {
            string query = "select * from Don_Hang where ID = '" + id + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            Console.WriteLine(data.Rows.Count);
            if (data.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public List<POS> GetListDetailPOS(string id)
        {
            //select dh.ID,sp.Image,sp.Ma_SP,sp.Ten_SP,dhd.So_Luong,dhd.total from Don_Hang dh, SO_detail dhd,San_Pham sp where dhd.ID_SO = dh.ID  and sp.Ma_SP = dhd.MA_SP  and dh.ID = 'SO02'
            List<POS> list = new List<POS>();
            string query = "select dh.ID,sp.Image,sp.Ma_SP,sp.Ten_SP,dhd.So_Luong,dhd.total from Don_Hang dh,SO_detail dhd,San_Pham sp where dhd.ID_SO = dh.ID  and dhd.MA_SP = sp.Ma_SP and dh.ID = '" + id + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            data.Columns.Add("avatar", Type.GetType("System.Byte[]"));
            int dem = 1;
            foreach (DataRow item in data.Rows)
            {
                string url = @"img\none.jpg";
                if (item["image"].ToString() != "")
                {
                    url = @"img\" + item["image"].ToString();
                }
                item["avatar"] = File.ReadAllBytes(url);
                item["image"] = url;
                POS sp = new POS(dem, (Byte[])item["avatar"], item["Ma_SP"].ToString(), item["Ten_SP"].ToString(), int.Parse(item["So_Luong"].ToString()), int.Parse(item["total"].ToString()));
                dem++;
                list.Add(sp);
            }
            return list;
        }
        public string Getprefix()

        {
            string query = "select * from Don_Hang";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            string g = "";

            if ((data.Rows.Count <= 0))
            {
                return "SO01";
            }
            else
            {
                int k;
                g = "SO";
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
