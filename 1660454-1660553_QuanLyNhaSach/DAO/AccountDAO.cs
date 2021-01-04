using _1660454_1660553_QuanLyNhaSach.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1660454_1660553_QuanLyNhaSach.DAO
{
    class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }

        private AccountDAO() { }

        public List<Account> GetListStaff()
        {
            List<Account> list = new List<Account>();

            string query = "select * from userd";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Account account = new Account(item);
                list.Add(account);
            }

            return list;
        }
        public bool login(string user, string pass)
        {
            string query = "select * from userd where account ='" + user + "' and password ='" + pass + "'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result.Rows.Count > 0;
        }
        public Account GetAccountByUserName(string user)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from userd where account = '" + user + "'");

            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }

            return null;
        }
        public bool UpdateAccount(string userName, string newPass, string account)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("UPDATE userd set name = N'" + userName + "' ,password = '" + newPass + "' where account = '" + account + "'");
            return result > 0;
        }
        public bool UpdateAccountName(string userName,string account)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("UPDATE userd set name = N'" + userName + "' where account = '" + account + "'");
            return result > 0;
        }
        public int getDoanhThu(int ID_NV)
        {
            int total = 0;
            DateTime today = DateTime.Today;
            string day = today.ToString("yyyy-MM-dd");
            string query = "select COALESCE(SUM(total),0) as total from Don_Hang where ID_NV = " + ID_NV + " and date = '" + day + "'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                total = int.Parse(item["total"].ToString());
                return total;
            }

            return total;
        }
    }
}
