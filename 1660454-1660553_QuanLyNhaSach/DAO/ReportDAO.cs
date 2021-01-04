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
    class ReportDAO
    {
        private static ReportDAO instance;

        internal static ReportDAO Instance { get { if (instance == null) instance = new ReportDAO(); return ReportDAO.instance; } set => ReportDAO.instance = value; }

        private ReportDAO() { }

        public List<Items> GetListItems()
        {
            List<Items> list = new List<Items>();

            string query = "select * from San_Pham where stock < stock_mini";

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
        public List<Report> GetListDoanhThu()
        {
            List<Report> list = new List<Report>();
            string query = "select dh.ID,dh.date,dh.discount,dh.total_discount,dh.total,kh.Ma_KH,kh.Ten_KH as Name_client,nv.name as Name_nv from Don_Hang dh,Khach_Hang kh,userd nv where dh.ID_NV = nv.id and dh.ID_KH = kh.Ma_KH";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Report sp = new Report(item);
                list.Add(sp);
            }
            return list;
        }

    }
}
