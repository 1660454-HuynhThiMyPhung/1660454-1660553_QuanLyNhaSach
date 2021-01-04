using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1660454_1660553_QuanLyNhaSach.DTO
{
    class Report
    {
        public Report(string id, string name_client, string name_nv, DateTime date, string dicount, int total_discount, int total, string Ma_KH)
        {
            this.ID = id;
            this.Name_client = name_client;
            this.Name_nv = name_nv;
            this.Date = date;
            this.Discount = dicount;
            this.Total_discount = total_discount;
            this.Ma_KH = Ma_KH;
            this.Total = total;
        }
        public Report(DataRow row)
        {
            this.ID = row["ID"].ToString().Trim();
            this.Name_client = row["Name_client"].ToString().Trim();
            this.Name_nv = row["Name_nv"].ToString().Trim();
            this.Date = (DateTime)row["date"];
            this.Discount = row["discount"].ToString().Trim();
            this.Ma_KH = row["Ma_KH"].ToString().Trim();
            this.Total_discount = (int)row["total_discount"];
            this.Total = (int)row["total"];
        }
        private string id;
        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        private string Ma_kh;
        public string Ma_KH
        {
            get { return Ma_kh; }
            set { Ma_kh = value; }
        }

        private string name_client;
        public string Name_client
        {
            get { return name_client; }
            set { name_client = value; }
        }


        private string name_nv;
        public string Name_nv
        {
            get { return name_nv; }
            set { name_nv = value; }
        }

        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        private string dicount;
        public string Discount
        {
            get { return dicount; }
            set { dicount = value; }
        }
        private int total_discount;
        public int Total_discount
        {
            get { return total_discount; }
            set { total_discount = value; }
        }
        private int total;
        public int Total
        {
            get { return total; }
            set { total = value; }
        }


    }
}
