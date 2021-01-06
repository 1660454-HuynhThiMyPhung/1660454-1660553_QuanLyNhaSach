using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1660454_1660553_QuanLyNhaSach.DTO
{
    public class Account
    {
        public Account(string userName, string Account, int Role, int ID, string Password = null)
        {
            this.UserName = userName;
            this.Accounts = Account;
            this.Role = Role;
            this.Password = Password;
            this.ID = ID;
        }
        public Account(DataRow row)
        {
            this.UserName = row["name"].ToString().Trim();
            this.Accounts = row["account"].ToString();
            this.Role = (int)row["role"];
            this.Password = row["password"].ToString();
            this.id = (int)row["id"];
        }

        private int role;

        public int Role
        {
            get { return role; }
            set { role = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private string accounts;

        public string Accounts
        {
            get { return accounts; }
            set { accounts = value; }
        }

        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
    }
}
