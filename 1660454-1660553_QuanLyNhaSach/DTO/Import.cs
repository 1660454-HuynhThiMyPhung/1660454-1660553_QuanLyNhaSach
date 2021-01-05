using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1660454_1660553_QuanLyNhaSach.DTO
{
    class Import
    {
        public Import(string ID, DateTime date, int total, string confim_import, string note)
        {
            this.ID = ID;
            this.date = date;
            this.total = total;
            this.confim_import = confim_import;
            this.note = note;
        }
        public Import(DataRow row)
        {
            this.ID = row["ID"].ToString();
            this.date = (DateTime)row["date"];
            this.total = (int)row["total"];
            this.confim_import = row["confim_import"].ToString().Trim();
            this.note = row["note"].ToString().Trim();
        }
        private DateTime dates;

        public DateTime date
        {
            get { return dates; }
            set { dates = value; }
        }


        private int totals;

        public int total
        {
            get { return totals; }
            set { totals = value; }
        }

        private string id;

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        private string confim;

        public string confim_import
        {
            get { return confim; }
            set { confim = value; }
        }
        private string notes;

        public string note
        {
            get { return notes; }
            set { notes = value; }
        }

    }
}
