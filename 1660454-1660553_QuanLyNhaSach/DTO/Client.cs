using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1660454_1660553_QuanLyNhaSach.DTO
{
    public class Client
    {
        public Client(string ID, string Name, string SDT, int Diem, string email, string address, string sex)
        {
            this.ID = ID;
            this.Name = Name;
            this.SDT = SDT;
            this.Diem = Diem;
            this.Email = email;
            this.Address = address;
            this.Sex = sex;
        }
        public Client(DataRow row)
        {
            this.ID = row["Ma_KH"].ToString();
            this.Name = row["Ten_KH"].ToString().Trim();
            this.SDT = row["SDT_KH"].ToString().Trim();
            this.Diem = (int)row["DIEM"];
            this.Email = row["Email"].ToString().Trim();
            this.Address = row["DiaChi"].ToString().Trim();
            this.Sex = row["Sex"].ToString().Trim();
            this.SDT = row["SDT_KH"].ToString().Trim();
        }
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private string sex;

        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        private int diem;

        public int Diem
        {
            get { return diem; }
            set { diem = value; }
        }

        private string id;

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string sdt;

        public string SDT
        {
            get { return sdt; }
            set { sdt = value; }
        }
    }
}
